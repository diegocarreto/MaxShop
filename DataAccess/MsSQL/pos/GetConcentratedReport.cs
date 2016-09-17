namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Getconcentratedreport.
	/// </summary>
	public partial class Getconcentratedreport : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String type = null, DateTime? startDate = null, DateTime? endDate = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@type", SqlDbType.VarChar, type, 8).Add("@startDate", SqlDbType.Date, startDate, null).Add("@endDate", SqlDbType.Date, endDate, null);

        	return this.GetListBase<T>("pos", "GetConcentratedReport",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String type = null, DateTime? startDate = null, DateTime? endDate = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@type", SqlDbType.VarChar, type, 8).Add("@startDate", SqlDbType.Date, startDate, null).Add("@endDate", SqlDbType.Date, endDate, null);

        	return this.ExecuteScalar<T>("pos", "GetConcentratedReport",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String type = null, DateTime? startDate = null, DateTime? endDate = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@type", SqlDbType.VarChar, type, 8).Add("@startDate", SqlDbType.Date, startDate, null).Add("@endDate", SqlDbType.Date, endDate, null);

        	return this.ExecuteNonQuery("pos", "GetConcentratedReport",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String type = null, DateTime? startDate = null, DateTime? endDate = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@type", SqlDbType.VarChar, type, 8).Add("@startDate", SqlDbType.Date, startDate, null).Add("@endDate", SqlDbType.Date, endDate, null);

        	return this.GetReader("pos", "GetConcentratedReport",parameters.ToArray());
        }

	#endregion
	}
}