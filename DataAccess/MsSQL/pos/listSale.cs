namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listsale.
	/// </summary>
	public partial class Listsale : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(DateTime? startDate = null, DateTime? finishDate = null, int? idCompany = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetListBase<T>("pos", "listSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(DateTime? startDate = null, DateTime? finishDate = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteScalar<T>("pos", "listSale",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(DateTime? startDate = null, DateTime? finishDate = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteNonQuery("pos", "listSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(DateTime? startDate = null, DateTime? finishDate = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetReader("pos", "listSale",parameters.ToArray());
        }

	#endregion
	}
}