using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class PM : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public bool? Freight { get; set; }

        public string Alias { get; set; }

        public string FreightString { get; set; }

        public string Location { get; set; }

        public int? IdProvider { get; set; }

        public int? IdLocation { get; set; }

        public int? TypeLike { get; set; }

        public decimal Price { get; set; }

        public int? IdProduct { get; set; }

        public int? IdMeasure { get; set; }

        public int? IdMeasure2 { get; set; }

        public int? IdGroup { get; set; }

        public double? AmountMeasure2 { get; set; }

        public int? IdBrand { get; set; }

        public string BarCode { get; set; }

        public string Measure { get; set; }

        public string Brand { get; set; }

        public double Stock { get; set; }

        public int? Max { get; set; }

        public int? Min { get; set; }

        public int? Buy { get; set; }

        public string Material { get; set; }

        public string ClientName { get; set; }

        public byte[] Image { get; set; }

        public string HasImage { get; set; }

        public bool? HasImageFilter { get; set; }

        public string CodeVendor { get; set; }

        public int? IdCompany { get; set; }

        public bool? Highlight { get; set; }

        public string ColorHex { get; set; }

        #endregion

        #region Builder

        public PM()
        {
        }

        #endregion

        #region Methods

        public double GetPriceForBarCode()
        {
            return this.AccessMsSql.Pos.Getpricebarcode.ExeScalar<double>(this.Id);
        }

        public string GetNameForBarCode()
        {
            return this.AccessMsSql.Pos.Getnamebarcode.ExeScalar<string>(this.Id);
        }

        public decimal GetPricePMFreight(int IdDestination, double Amount)
        {
            return this.AccessMsSql.Pos.Getpricepmfreight.ExeScalar<decimal>(this.Id, IdDestination, Amount);
        }

        public string RequireFreight()
        {
            return this.AccessMsSql.Pos.Requirefreight.ExeScalar<string>(this.Id);
        }

        public string GetBarCode()
        {
            return this.AccessMsSql.Pos.Getbarcode.ExeScalar<string>(this.Id);
        }

        public string SetBarCode()
        {
            return this.AccessMsSql.Pos.Setbarcode.ExeScalar<string>(this.Id, this.BarCode);
        }

        public bool Get(int? Id = null, bool IsItForSale = false)
        {
            try
            {
                PM oPM = this.List(Id, IsItForSale).First();

                this.IdMeasure = oPM.IdMeasure;
                this.IdMeasure2 = oPM.IdMeasure2;
                this.AmountMeasure2 = oPM.AmountMeasure2;
                this.IdProduct = oPM.IdProduct;
                this.IdBrand = oPM.IdBrand;
                this.Price = oPM.Price;
                this.BarCode = oPM.BarCode;
                this.Name = oPM.Name;
                this.CodeVendor = oPM.CodeVendor;
                this.Freight = oPM.Freight;
                this.IdLocation = oPM.IdLocation;
                this.Alias = oPM.Alias;
                this.Max = oPM.Max;
                this.Min = oPM.Min;
                this.IdCompany = oPM.IdCompany;
                this.Highlight = oPM.Highlight;
                this.ColorHex = oPM.ColorHex;

                this.Active = oPM.Active;

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existpm.ExeScalar<int>(this.Id, this.IdProduct, this.IdMeasure, this.IdBrand).Equals(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PM> List(int? Id = null, bool IsItForSale = false, string BarCode = "")
        {
            if (IsItForSale)
            {
                return this.AccessMsSql.Pos.Listpmventas.ExeList<PM>(Id, this.Aux2, this.Aux, BarCode);
            }
            else
            {
                return this.AccessMsSql.Pos.Listpm.ExeList<PM>(this.Id, this.Name, this.HasImageFilter, this.IdBrand, this.IdGroup, this.TypeLike, this.IdCompany);
            }
        }

        public List<PM> ListByCode()
        {
            return this.AccessMsSql.Pos.Listpmbycode.ExeList<PM>(this.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PM> ListStock()
        {
            return this.AccessMsSql.Pos.Listpmstock.ExeList<PM>(this.IdProvider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PM> ListClients()
        {
            return this.AccessMsSql.Pos.Getclientname.ExeList<PM>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PM> ListForCombo()
        {
            return this.AccessMsSql.Pos.Listpmcombo.ExeList<PM>();
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
                    this.AccessMsSql.Pos.Updatepm.ExeScalar<int>(this.Id, this.IdProduct, this.IdMeasure, this.IdMeasure2, this.AmountMeasure2, this.IdBrand, this.Price, this.Active, this.BarCode, this.CodeVendor, this.Freight, this.IdLocation, this.Name, this.Max, this.Min, this.IdCompany);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addpm.ExeScalar<int>(this.IdProduct, this.IdMeasure, this.IdMeasure2, this.AmountMeasure2, this.IdBrand, this.Price, this.Active, this.BarCode, this.CodeVendor, this.Freight, this.IdLocation, this.Name, this.Max, this.Min, this.IdCompany);
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
                this.AccessMsSql.Pos.Deletepm.ExeNonQuery(this.Id);

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
        public int GetIdByName()
        {
            this.Id = this.AccessMsSql.Pos.Getidbynamepm.ExeScalar<int>(this.Name);

            return this.Id.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetLocationByName()
        {
            return this.AccessMsSql.Pos.Getlocationbynamepm.ExeScalar<string>(this.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetIdCompany()
        {
            return this.AccessMsSql.Pos.Getidcompanybynamepm.ExeScalar<int>(this.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsItForSale"></param>
        /// <returns></returns>
        public double GetStock(bool IsItForSale = false)
        {
            return this.AccessMsSql.Pos.Stockforsale.ExeScalar<double>(this.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public bool SaveImage(byte[] Image)
        {
            this.AccessMsSql.Pos.Addimage.ExeNonQuery(this.Id, "PM", Image);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public bool SaveColor(bool WithColor, string Color = "")
        {
            this.AccessMsSql.Pos.Updatecolorpm.ExeNonQuery(this.Id, WithColor, Color);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public byte[] GetImage()
        {
            List<PM> lPM = this.AccessMsSql.Pos.Getimagepm.ExeList<PM>(this.Id, "PM");

            if (lPM.Count > 0)
                return lPM.First().Image;
            else
                return null;
        }

        #endregion
    }
}