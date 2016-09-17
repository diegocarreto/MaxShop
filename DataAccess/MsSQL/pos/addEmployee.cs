namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addemployee.
	/// </summary>
	public partial class Addemployee : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String name = null, Decimal? salary = null, String phone = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.GetListBase<T>("pos", "addEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.ExecuteScalar<T>("pos", "addEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.ExecuteNonQuery("pos", "addEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.GetReader("pos", "addEmployee",parameters.ToArray());
        }

	#endregion
	}
}