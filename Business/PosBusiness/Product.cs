using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Product : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public int? IdLabel { get; set; }

        public string LabelName { get; set; }

        public int? IdMaterial { get; set; }

        public string MaterialName { get; set; }

        public int? IdGroup { get; set; }

        public string GroupName { get; set; }

        public string PathImage { get; set; }

        #endregion

        #region Builder

        public Product()
        {
        }

        #endregion

        #region Methods

        public bool Get()
        {
            try
            {
                Product product = this.List().First();

                this.IdLabel = product.IdLabel;
                this.IdMaterial = product.IdMaterial;
                this.IdGroup = product.IdGroup;
                this.Active = product.Active;

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
            return this.AccessMsSql.Pos.Existproduct.ExeScalar<int>(this.IdLabel, this.IdMaterial).Equals(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> List()
        {
            return this.AccessMsSql.Pos.Listproduct.ExeList<Product>(this.Id, this.Name, this.IdGroup,this.IdLabel);
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
                    this.AccessMsSql.Pos.Updateproduct.ExeScalar<int>(this.Id, this.IdGroup, this.IdLabel, this.IdMaterial, this.PathImage, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addproduct.ExeScalar<int>(this.IdGroup, this.IdLabel, this.IdMaterial, this.PathImage, this.Active);
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
                this.AccessMsSql.Pos.Deleteproduct.ExeNonQuery(this.Id);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        #endregion
    }
}
