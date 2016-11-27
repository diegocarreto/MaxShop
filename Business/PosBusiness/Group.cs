using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Group : EntityBase
    {
        #region Members

        public List<Group> Groups { get; set; }

        #endregion

        #region Properties

        public int Period { get; set; }

        public double Total { get; set; }

        public double Soporte { get; set; }

        public double PeriodoPorTotal { get; set; }

        public double PeriodoCuadrado { get; set; }

        public double Prediccion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; set; }

        #endregion

        #region Builder

        public Group()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existgroup.ExeScalar<int>(this.Name).Equals(1);
        }

        public int GetIdByNameGroup()
        {
            return this.AccessMsSql.Pos.Getidbynamegroup.ExeScalar<int>(this.Name);
        }

        public bool ExistPrefix()
        {
            return this.AccessMsSql.Pos.Existgroupbyprefix.ExeScalar<int>(this.Prefix).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Group oGroup = this.List().First();

                this.Name = oGroup.Name;
                this.Prefix = oGroup.Prefix;
                this.Active = oGroup.Active;

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Group> List()
        {
            return this.AccessMsSql.Pos.Listgroup.ExeList<Group>(this.Id, this.Name, this.Prefix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                if (this.Id.HasValue)
                {
                    this.AccessMsSql.Pos.Updategroup.ExeScalar<int>(this.Id, this.Name, this.Prefix, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addgroup.ExeScalar<int>(this.Name, this.Prefix);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            try
            {
                this.AccessMsSql.Pos.Deletegroup.ExeNonQuery(this.Id);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        public List<Group> GetStatistics(int IdCompany, int? IdGroup = null)
        {
            List<Group> groups = null;

            using (PosBusiness.Group group = new PosBusiness.Group())
            {
                groups = group.List();

                if (IdGroup.HasValue)
                {
                    groups = groups.FindAll(p => p.Id.Equals(IdGroup));
                }

                foreach (var g in groups)
                {
                    g.Groups = new List<PosBusiness.Group>();

                    for (int i = 1; i <= 52; i++)
                    {
                        var startDate = this.FirstDateOfWeek(2016, i);
                        var endDate = startDate.AddDays(6);

                        var sg = this.AccessMsSql.Pos.Getstatisticsgroup.ExeList<Group>(1, IdCompany, startDate, endDate, IdGroup);

                        if (sg.Any())
                        {
                            g.Groups.Add(new PosBusiness.Group
                            {
                                Period = i,
                                Total = sg[0].Total
                            });
                        }
                        else
                        {
                            g.Groups.Add(new PosBusiness.Group
                            {
                                Period = i,
                                Total = 0
                            });
                        }
                    }

                    g.Groups.ForEach(x =>
                    {
                        x.PeriodoPorTotal = x.Period * x.Total;
                        x.PeriodoCuadrado = x.Period * x.Period;
                    });

                    double n = g.Groups.Count,
                           promedioPeriodo = g.Groups.Sum(x => x.Period) / n,
                           promedioCantidad = g.Groups.Sum(x => x.Total) / n,
                           sumaPeriodoPorcantidad = g.Groups.Sum(x => x.PeriodoPorTotal),
                           sumaPeriodoCuadrado = g.Groups.Sum(x => x.PeriodoCuadrado);

                    double BA = sumaPeriodoPorcantidad - (n * promedioPeriodo * promedioCantidad);
                    double BB = sumaPeriodoCuadrado - (n * (promedioPeriodo * promedioPeriodo));

                    double B1 = BA / BB;
                    double B0 = promedioCantidad - (B1 * promedioPeriodo);

                    g.Groups.ForEach(x =>
                    {
                        x.Prediccion = B0 + (B1 * x.Period);
                    });
                }
            }

            return groups;
        }

        public DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var firstDate = new DateTime(year, 1, 4);
            //first thursday of the week defines the first week (https://en.wikipedia.org/wiki/ISO_8601)
            //Wiki: the 4th of january is always in the first week
            while (firstDate.DayOfWeek != DayOfWeek.Monday)
                firstDate = firstDate.AddDays(-1);

            return firstDate.AddDays((weekOfYear - 1) * 7);
        }

        #endregion
    }
}
