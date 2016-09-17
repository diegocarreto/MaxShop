namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listexpensedetail.
	/// </summary>
	public partial class Listexpensedetail : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idExpense = null, int? id = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@id", SqlDbType.Int, id, null);

        	return this.GetListBase<T>("pos", "listExpenseDetail",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idExpense = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@id", SqlDbType.Int, id, null);

        	return this.ExecuteScalar<T>("pos", "listExpenseDetail",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idExpense = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@id", SqlDbType.Int, id, null);

        	return this.ExecuteNonQuery("pos", "listExpenseDetail",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idExpense = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idExpense", SqlDbType.Int, idExpense, null).Add("@id", SqlDbType.Int, id, null);

        	return this.GetReader("pos", "listExpenseDetail",parameters.ToArray());
        }

	#endregion
	}
}