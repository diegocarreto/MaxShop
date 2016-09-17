namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addpayment.
	/// </summary>
	public partial class Addpayment : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idLoan = null, Decimal? amount = null, DateTime? date = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null);

        	return this.GetListBase<T>("pos", "addPayment",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idLoan = null, Decimal? amount = null, DateTime? date = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null);

        	return this.ExecuteScalar<T>("pos", "addPayment",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idLoan = null, Decimal? amount = null, DateTime? date = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null);

        	return this.ExecuteNonQuery("pos", "addPayment",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idLoan = null, Decimal? amount = null, DateTime? date = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null);

        	return this.GetReader("pos", "addPayment",parameters.ToArray());
        }

	#endregion
	}
}