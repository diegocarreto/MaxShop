﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Sale : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public bool ForReport { get; set; }

        public List<Sale> Sales { get; set; }

        public string PaymentType { get; set; }

        public double Total { get; set; }

        public double Cash { get; set; }

        public double Change { get; set; }

        public double Payment { get; set; }

        public int IdPm { get; set; }

        public string Group { get; set; }

        public double Amount { get; set; }

        public double AvgCost { get; set; }

        public double AvgTotalCost { get; set; }

        public double Unitary { get; set; }

        public double Price { get; set; }

        public double Paid { get; set; }

        public double Gain { get; set; }

        public string ClientName { get; set; }

        public int IdClient { get; set; }

        public bool? Freight { get; set; }

        public List<ProductForAction> Products { get; set; }

        public DateTime? CancelDate { get; set; }

        public int? IdCompany { get; set; }

        public string CompanyName { get; set; }

        public string Reference { get; set; }

        #endregion

        #region Builder

        public Sale()
        {
        }

        #endregion

        #region Methods

        public bool Get(int? Id, int? IdBlock)
        {
            Sale sale = this.AccessMsSql.Pos.Getsale.ExeList<Sale>(Id).First();

            this.ClientName = sale.ClientName;
            this.PaymentType = sale.PaymentType;
            this.Total = sale.Total;
            this.Payment = sale.Payment;
            this.CreatedDate = sale.CreatedDate;
            this.IdClient = sale.IdClient;
            this.Freight = sale.Freight;
            this.Reference = sale.Reference;
            this.Paid = sale.Paid;
            this.Amount = sale.Amount;
            this.Change = sale.Change;
            this.Cash = sale.Cash;

            this.Products = this.AccessMsSql.Pos.Listdetailsale.ExeList<ProductForAction>(Id);

            return true;
        }

        public bool Cancel(int? Id)
        {
            this.AccessMsSql.Pos.Cancelsale.ExeNonQuery(Id);

            var products = this.AccessMsSql.Pos.Listdetailsale.ExeList<ProductForAction>(Id);
            var name = this.AccessMsSql.Pos.Getnameforrefillcancelsale.ExeScalar<string>(Id);

            var ids = products.Select(x => x.IdCompany).Distinct().ToList();

            for (var i = 0; i < ids.Count; i++)
            {
                var id = ids[i];

                var productsCompany = products.FindAll(p => p.IdCompany.Equals(id));

                foreach (var pc in productsCompany)
                {
                    var cost = this.AccessMsSql.Pos.Getpurchasecost.ExeScalar<decimal>(int.Parse(pc.Code));

                    if (cost.Equals(0))
                        cost = (decimal).1;

                    if (cost > (decimal)pc.Unitary)
                        cost = (decimal).1;

                    pc.Unitary = cost;

                    pc.Price = (decimal)(pc.Unitary * (decimal)pc.Amount);

                    pc.Id = int.Parse(pc.Code);
                }

                using (Purchase purchase = new Purchase
                {
                    IdCompany = id
                })
                {
                    var nameCompany = ". Compañia: " + this.AccessMsSql.Pos.Listcompany.ExeList<Company>(id).First().Name;

                    purchase.Name = name + nameCompany;
                    purchase.CreatedDate = DateTime.Now;
                    purchase.Id = null;

                    var result = purchase.Charge(productsCompany);

                    this.AccessMsSql.Pos.Addpurchasefather.ExeNonQuery(purchase.Id, Id);
                }
            }

            return true;
        }

        public void AddFather(int IdSale, int IdFather)
        {
            this.AccessMsSql.Pos.Addsalefather.ExeNonQuery(IdSale, IdFather);
        }

        public List<Sale> List(DateTime StartDate, DateTime FinishDate)
        {
            this.Sales = new List<Sale>();

            List<Sale> ls1;

            if (string.IsNullOrEmpty(this.Name))
                ls1 = this.AccessMsSql.Pos.Listsale.ExeList<Sale>(StartDate, FinishDate, this.IdCompany);
            else
                ls1 = this.AccessMsSql.Pos.Listsale2.ExeList<Sale>(StartDate, FinishDate, this.Name, this.IdCompany);

            //foreach (Sale sale in ls1)
            //{
            //    sale.Sales = this.AccessMsSql.Pos.Listdetailsale.ExeList<Sale>(sale.Id);
            //}

            return ls1;
        }

        public void GetDetailSale()
        {
            this.Sales = this.AccessMsSql.Pos.Listdetailsale.ExeList<Sale>(this.Id);
        }

        public void Pay(int IdSale, string Type, decimal Amount, decimal Cash, decimal Change, DateTime Date)
        {
            this.AccessMsSql.Pos.Addpaymentsale.ExeNonQuery(IdSale, Type, Amount, Cash, Change, Date);
        }

        public bool Charge(List<ProductForAction> Products, int IdClient, string PaymentType, double Payment, double OnAccount, double Change, bool Freight = false, int? IdCompany = null, string Reference = "", bool Block = false)
        {
            try
            {
                double total = (double)Products.Sum(item => item.Price);

                if (!total.Equals(0))
                {
                    this.Id = this.AccessMsSql.Pos.Addsale.ExeScalar<int>(total, IdClient, PaymentType, Payment, Freight, OnAccount, Change, IdCompany, Reference, Block);

                    foreach (ProductForAction p in Products)
                    {
                        int idDetailSale = this.AccessMsSql.Pos.Adddetailsale.ExeScalar<int>(this.Id, p.Id, p.Amount, p.Unitary, p.Price);

                        for (double i = 1; i <= p.Amount; i++)
                        {
                            int idDetailPurchase = this.AccessMsSql.Pos.Getpurchasecostforsale.ExeScalar<int>(p.Id);

                            this.AccessMsSql.Pos.Addunioncostandsale.ExeNonQuery(idDetailSale, idDetailPurchase);
                        }
                    }

                    return true;
                }
                else
                {
                    this.ErrorMessage = "La venta no puedo ser por importe $0.00 ó cero productos.";

                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;

                return false;
            }
        }

        #endregion
    }
}
