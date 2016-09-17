namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Checkpmindetailpurchase.
	/// </summary>
	public partial class Checkpmindetailpurchase : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idPurchase = null, int? idPm = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPurchase", SqlDbType.Int, idPurchase, null).Add("@idPm", SqlDbType.Int, idPm, null);

        	return this.GetListBase<T>("pos", "CheckPmInDetailPurchase",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idPurchase = null, int? idPm = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPurchase", SqlDbType.Int, idPurchase, null).Add("@idPm", SqlDbType.Int, idPm, null);

        	return this.ExecuteScalar<T>("pos", "CheckPmInDetailPurchase",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idPurchase = null, int? idPm = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPurchase", SqlDbType.Int, idPurchase, null).Add("@idPm", SqlDbType.Int, idPm, null);

        	return this.ExecuteNonQuery("pos", "CheckPmInDetailPurchase",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idPurchase = null, int? idPm = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPurchase", SqlDbType.Int, idPurchase, null).Add("@idPm", SqlDbType.Int, idPm, null);

        	return this.GetReader("pos", "CheckPmInDetailPurchase",parameters.ToArray());
        }

	#endregion
	}
}