using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MSSQL;

namespace PosBusiness
{
    [Serializable]
    public abstract class EntityBase : IDisposable
    {
        #region Members

        /// <summary>
        /// Miembro de acceso Microsoft SQL.
        /// </summary>
        [NonSerialized]
        private MsSQL accessMsSql;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeleteDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Aux { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Aux2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Gestiona la comunicación entre la aplicación y Microsoft SQL Server.
        /// </summary>
        public MsSQL AccessMsSql
        {
            get
            {
                if (accessMsSql == null)
                    accessMsSql = new MsSQL();

                return accessMsSql;
            }
            set
            {
                accessMsSql = value;
            }
        }

        #endregion

        #region Builder

        public EntityBase()
        {
        }

        #endregion

        #region Methods

        protected void SetError(string ErrorMessage = "")
        {
            this.ErrorMessage = ErrorMessage;

            IsCorrect = string.IsNullOrEmpty(this.ErrorMessage);
        }

        protected void SetError(Exception Ex = null)
        {
            if (Ex != null)
                this.SetError(Ex.Message);
        }

        public void Dispose()
        {
            if (this.AccessMsSql != null)
                this.AccessMsSql.Dispose();
        }

        #endregion
    }
}


