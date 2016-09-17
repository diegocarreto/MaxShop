using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PosUtilities;

namespace PosBusiness
{
    [Serializable]
    public class Configuration : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Line { get; set; }

        public string Text { get; set; }

        #endregion

        #region Builder

        public Configuration()
        {

        }

        #endregion

        #region Methods

        public T GetValue<T>(string Name)
        {
            var value = this.AccessMsSql.Pos.Getconfiguration.ExeScalar<string>(Name);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public bool CreateBackUpDataBase(string Path)
        {
            var pathdt = DateTime.Now.ToString("ddMMyyyyhhmmss");
            var directory = Path + "\\" + pathdt;
            var zipFile = directory + "\\" + pathdt + ".zip";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            this.CreateBackUpTable(directory);
            this.CreateBackUpProcedures(directory);

            using (var zip = new ZipFile())
            {
                zip.AddDirectory(directory);
                zip.Comment = "BackUp de la base de datos [Pos]. Creado el " + System.DateTime.Now.ToString("G");
                zip.Save(zipFile);
            }

            var ftp = new Ftp();

            var server = this.GetValue<string>("ftpServer");
            var user = this.GetValue<string>("ftpUser");
            var password = this.GetValue<string>("ftpPassword");
            var timeOut = this.GetValue<int>("ftpTimeout");
            var directoryFtp = this.GetValue<string>("ftpDirectoryBackUp");

            ftp.Upload(server, user, password, zipFile, directoryFtp, pathdt + ".zip", timeOut);

            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            this.LastBackUp();

            return true;
        }

        private void CreateBackUpTable(string Directory)
        {
            var tables = this.AccessMsSql.Pos.Backupgettables.ExeList<Configuration>();

            foreach (var table in tables)
            {
                using (TextWriter tw = new StreamWriter(Directory + "\\table_" + table.Name + ".sql", true))
                {
                    var txts = this.AccessMsSql.Pos.Backupgettabletext.ExeList<Configuration>(table.Name);

                    foreach (var txt in txts)
                    {
                        tw.WriteLine(txt.Line);
                    }

                    tw.Close();
                }

                if (!table.Name.Equals("image"))
                {
                    using (TextWriter tw = new StreamWriter(Directory + "\\table_" + table.Name + "_Info.sql", true))
                    {
                        var txts = this.AccessMsSql.Pos.Backupgetinfo.ExeList<Configuration>("dbo." + table.Name + " where 1=1");

                        foreach (var txt in txts)
                        {
                            tw.WriteLine(txt.Line);
                        }

                        tw.Close();
                    }
                }
            }
        }

        private void CreateBackUpProcedures(string Directory)
        {
            var procedures = this.AccessMsSql.Pos.Backupgetprocedures.ExeList<Configuration>();

            foreach (var proc in procedures)
            {
                using (TextWriter tw = new StreamWriter(Directory + "\\storedprocedure_" + proc.Name + ".sql", true))
                {
                    var txts = this.AccessMsSql.Pos.Backupgetproceduretext.ExeList<Configuration>(proc.Name);

                    foreach (var txt in txts)
                    {
                        tw.WriteLine(txt.Line);
                    }

                    tw.Close();
                }
            }
        }

        public void LastBackUp()
        {
            this.AccessMsSql.Pos.Lastbackup.ExeNonQuery();
        }

        public bool CreateBakUp()
        {
            return this.AccessMsSql.Pos.Createbackup.ExeScalar<bool>();
        }

        #endregion
    }
}

