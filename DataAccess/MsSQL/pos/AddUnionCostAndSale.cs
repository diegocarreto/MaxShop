namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addunioncostandsale.
	/// </summary>
	public partial class Addunioncostandsale : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idDetailSale = null, int? idDetailPurchase = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idDetailSale", SqlDbType.Int, idDetailSale, null).Add("@idDetailPurchase", SqlDbType.Int, idDetailPurchase, null);

        	return this.GetListBase<T>("pos", "AddUnionCostAndSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idDetailSale = null, int? idDetailPurchase = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idDetailSale", SqlDbType.Int, idDetailSale, null).Add("@idDetailPurchase", SqlDbType.Int, idDetailPurchase, null);

        	return this.ExecuteScalar<T>("pos", "AddUnionCostAndSale",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idDetailSale = null, int? idDetailPurchase = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idDetailSale", SqlDbType.Int, idDetailSale, null).Add("@idDetailPurchase", SqlDbType.Int, idDetailPurchase, null);

        	return this.ExecuteNonQuery("pos", "AddUnionCostAndSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idDetailSale = null, int? idDetailPurchase = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idDetailSale", SqlDbType.Int, idDetailSale, null).Add("@idDetailPurchase", SqlDbType.Int, idDetailPurchase, null);

        	return this.GetReader("pos", "AddUnionCostAndSale",parameters.ToArray());
        }

	#endregion
	}
}