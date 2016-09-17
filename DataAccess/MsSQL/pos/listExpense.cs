namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listexpense.
	/// </summary>
	public partial class Listexpense : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idCategoryExpense = null, DateTime? startDate = null, DateTime? finishDate = null, String name = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetListBase<T>("pos", "listExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idCategoryExpense = null, DateTime? startDate = null, DateTime? finishDate = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteScalar<T>("pos", "listExpense",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idCategoryExpense = null, DateTime? startDate = null, DateTime? finishDate = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteNonQuery("pos", "listExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idCategoryExpense = null, DateTime? startDate = null, DateTime? finishDate = null, String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@startDate", SqlDbType.Date, startDate, null).Add("@finishDate", SqlDbType.Date, finishDate, null).Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetReader("pos", "listExpense",parameters.ToArray());
        }

	#endregion
	}
}