namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Adddetailexpense.
	/// </summary>
	public partial class Adddetailexpense : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idExpense = null, Decimal? amount = null, DateTime? date = null, String name = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetListBase<T>("pos", "addDetailExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idExpense = null, Decimal? amount = null, DateTime? date = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteScalar<T>("pos", "addDetailExpense",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idExpense = null, Decimal? amount = null, DateTime? date = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteNonQuery("pos", "addDetailExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idExpense = null, Decimal? amount = null, DateTime? date = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetReader("pos", "addDetailExpense",parameters.ToArray());
        }

	#endregion
	}
}