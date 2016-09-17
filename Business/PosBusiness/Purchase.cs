using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Extensions;

namespace PosBusiness
{
    [Serializable]
    public class Purchase : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Path { get; set; }

        public List<Purchase> Purchases { get; set; }

        public double Total { get; set; }

        public DateTime? Date { get; set; }

        public List<ProductForAction> Products { get; set; }

        #endregion

        #region Builder

        public Purchase()
        {
        }

        #endregion

        #region Methods

        public List<Purchase> List(DateTime StartDate, DateTime FinishDate)
        {
            this.Purchases = new List<Purchase>();

            List<Purchase> ls1;

            if (string.IsNullOrEmpty(this.Name))
                ls1 = this.AccessMsSql.Pos.Listpurchase.ExeList<Purchase>(StartDate, FinishDate);
            else
                ls1 = this.AccessMsSql.Pos.Listpurchase2.ExeList<Purchase>(StartDate, FinishDate, this.Name);

            //foreach (Sale sale in ls1)
            //{
            //    sale.Sales = this.AccessMsSql.Pos.Listdetailsale.ExeList<Sale>(sale.Id);
            //}

            return ls1;
        }

        public bool SaveFile()
        {
            try
            {
                this.AccessMsSql.Pos.Addfiletopurchase.ExeNonQuery(this.Id, this.Path);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Charge(List<ProductForAction> Products)
        {
            try
            {
                double total = (double)Products.Sum(item => item.Price);

                if (!total.Equals(0))
                {
                    if (!this.Id.HasValue)
                    {
                        this.Id = this.AccessMsSql.Pos.Addpurchase.ExeScalar<int>(this.Name, this.CreatedDate, total);

                        foreach (ProductForAction p in Products)
                        {
                            this.AccessMsSql.Pos.Adddetailpurchase.ExeNonQuery(this.Id, p.Id, (double)p.Amount, p.Unitary, p.Price);
                        }
                    }
                    else
                    {
                        int hoursSpent = this.AccessMsSql.Pos.Getnumberhourspurchase.ExeScalar<int>(this.Id);
                        int hoursMax = this.AppSet<int>("MaxHoursModifyPurchase");

                        if (hoursSpent <= hoursMax)
                        {
                            this.Id = this.AccessMsSql.Pos.Updatepurchase.ExeScalar<int>(this.Id, this.Name, this.CreatedDate, total);

                            foreach (ProductForAction p in Products)
                            {
                                if (this.AccessMsSql.Pos.Checkpmindetailpurchase.ExeScalar<int>(this.Id, int.Parse(p.Code)).Equals(1))
                                {
                                    this.AccessMsSql.Pos.Updatedetailpurchase.ExeNonQuery(int.Parse(p.Code), (double)p.Amount, p.Unitary, p.Price);
                                }
                                else
                                {
                                    this.AccessMsSql.Pos.Adddetailpurchase.ExeNonQuery(this.Id, p.Id, (double)p.Amount, p.Unitary, p.Price);
                                }
                            }
                        }
                        else
                        {
                            this.ErrorMessage = "El tiempo máximo de " + hoursMax + " horas para poder modificar una compra ya fue superado.";

                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    this.ErrorMessage = "La compra no puedo ser por importe $0.00 ó cero productos.";

                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;

                return false;
            }
        }

        public bool Get(int? Id)
        {
            Purchase purchase = this.AccessMsSql.Pos.Getpurchase.ExeList<Purchase>(Id).First();

            this.Id = purchase.Id;
            this.Total = purchase.Total;
            this.Date = purchase.Date;
            this.CreatedDate = purchase.CreatedDate;
            this.Name = purchase.Name;

            this.Products = this.AccessMsSql.Pos.Listdetailpurchase.ExeList<ProductForAction>(Id);

            return true;
        }

        #endregion
    }
}
