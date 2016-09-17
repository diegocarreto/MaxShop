namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Adddetailsale.
	/// </summary>
	public partial class Adddetailsale : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idSale = null, int? idPM = null, Double? amount = null, Decimal? unitary = null, Decimal? price = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idSale", SqlDbType.Int, idSale, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@amount", SqlDbType.Float, amount, null).Add("@unitary", SqlDbType.Money, unitary, null).Add("@price", SqlDbType.Money, price, null);

        	return this.GetListBase<T>("pos", "AddDetailSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idSale = null, int? idPM = null, Double? amount = null, Decimal? unitary = null, Decimal? price = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idSale", SqlDbType.Int, idSale, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@amount", SqlDbType.Float, amount, null).Add("@unitary", SqlDbType.Money, unitary, null).Add("@price", SqlDbType.Money, price, null);

        	return this.ExecuteScalar<T>("pos", "AddDetailSale",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idSale = null, int? idPM = null, Double? amount = null, Decimal? unitary = null, Decimal? price = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idSale", SqlDbType.Int, idSale, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@amount", SqlDbType.Float, amount, null).Add("@unitary", SqlDbType.Money, unitary, null).Add("@price", SqlDbType.Money, price, null);

        	return this.ExecuteNonQuery("pos", "AddDetailSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idSale = null, int? idPM = null, Double? amount = null, Decimal? unitary = null, Decimal? price = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idSale", SqlDbType.Int, idSale, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@amount", SqlDbType.Float, amount, null).Add("@unitary", SqlDbType.Money, unitary, null).Add("@price", SqlDbType.Money, price, null);

        	return this.GetReader("pos", "AddDetailSale",parameters.ToArray());
        }

	#endregion
	}
}