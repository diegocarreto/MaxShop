namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addexpense.
	/// </summary>
	public partial class Addexpense : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idCategoryExpense = null, String name = null, String description = null, Decimal? amount = null, int? idCompany = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@description", SqlDbType.VarChar, description, 2000).Add("@amount", SqlDbType.Money, amount, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetListBase<T>("pos", "AddExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idCategoryExpense = null, String name = null, String description = null, Decimal? amount = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@description", SqlDbType.VarChar, description, 2000).Add("@amount", SqlDbType.Money, amount, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteScalar<T>("pos", "AddExpense",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idCategoryExpense = null, String name = null, String description = null, Decimal? amount = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@description", SqlDbType.VarChar, description, 2000).Add("@amount", SqlDbType.Money, amount, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteNonQuery("pos", "AddExpense",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idCategoryExpense = null, String name = null, String description = null, Decimal? amount = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idCategoryExpense", SqlDbType.Int, idCategoryExpense, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@description", SqlDbType.VarChar, description, 2000).Add("@amount", SqlDbType.Money, amount, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetReader("pos", "AddExpense",parameters.ToArray());
        }

	#endregion
	}
}