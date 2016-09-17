using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PosUtilities
{
    public class Ftp
    {
        public bool Upload(string server, string user, string pass, string origen, string rutadestino, string nombredestino, int timeOut)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + "/" + rutadestino + "/" + nombredestino);

                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(user, pass);

                request.UsePassive = true;

                request.UseBinary = true;

                request.KeepAlive = true;

                request.Timeout = timeOut;
                request.ReadWriteTimeout = timeOut;

                FileStream stream = File.OpenRead(origen);

                byte[] buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);

                stream.Close();

                Stream reqStream = request.GetRequestStream();

                reqStream.Write(buffer, 0, buffer.Length);

                reqStream.Flush();

                reqStream.Close();

                return true;
            }

            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
