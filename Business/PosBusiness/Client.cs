using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Client : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Address { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Street { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string Colony { get; set; }

        public string Municipality { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Others { get; set; }

        #endregion

        #region Builder

        public Client()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existclient.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Client client = this.List().First();

                this.Name = client.Name;
                this.Phone1 = client.Phone1;
                this.Phone2 = client.Phone2;
                this.Street = client.Street;
                this.Number1 = client.Number1;
                this.Number2 = client.Number2;
                this.Colony = client.Colony;
                this.Municipality = client.Municipality;
                this.State = client.State;
                this.Zip = client.Zip;
                this.Others = client.Others;
                this.Address = client.Address;

                this.Active = client.Active;

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
        public List<Client> List()
        {
            return this.AccessMsSql.Pos.Listclient.ExeList<Client>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updateclient.ExeScalar<int>(this.Id,
                                                                     this.Name,
                                                                     this.Phone1,
                                                                     this.Phone2,
                                                                     this.Street,
                                                                     this.Number1,
                                                                     this.Number2,
                                                                     this.Colony,
                                                                     this.Municipality,
                                                                     this.State,
                                                                     this.Zip,
                                                                     this.Others,
                                                                     this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addclient.ExeScalar<int>(this.Name,
                                                                            this.Phone1,
                                                                            this.Phone2,
                                                                            this.Street,
                                                                            this.Number1,
                                                                            this.Number2,
                                                                            this.Colony,
                                                                            this.Municipality,
                                                                            this.State,
                                                                            this.Zip,
                                                                            this.Others);
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
                this.AccessMsSql.Pos.Deleteclient.ExeNonQuery(this.Id);

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
