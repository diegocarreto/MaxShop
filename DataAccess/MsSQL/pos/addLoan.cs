namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addloan.
	/// </summary>
	public partial class Addloan : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idEmployee = null, Decimal? amount = null, DateTime? date = null, String detail = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idEmployee", SqlDbType.Int, idEmployee, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@detail", SqlDbType.VarChar, detail, 5000);

        	return this.GetListBase<T>("pos", "addLoan",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idEmployee = null, Decimal? amount = null, DateTime? date = null, String detail = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idEmployee", SqlDbType.Int, idEmployee, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@detail", SqlDbType.VarChar, detail, 5000);

        	return this.ExecuteScalar<T>("pos", "addLoan",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idEmployee = null, Decimal? amount = null, DateTime? date = null, String detail = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idEmployee", SqlDbType.Int, idEmployee, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@detail", SqlDbType.VarChar, detail, 5000);

        	return this.ExecuteNonQuery("pos", "addLoan",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idEmployee = null, Decimal? amount = null, DateTime? date = null, String detail = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idEmployee", SqlDbType.Int, idEmployee, null).Add("@amount", SqlDbType.Money, amount, null).Add("@date", SqlDbType.Date, date, null).Add("@detail", SqlDbType.VarChar, detail, 5000);

        	return this.GetReader("pos", "addLoan",parameters.ToArray());
        }

	#endregion
	}
}