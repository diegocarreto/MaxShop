namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Updateemployee.
	/// </summary>
	public partial class Updateemployee : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, String name = null, Decimal? salary = null, String phone = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.GetListBase<T>("pos", "updateEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.ExecuteScalar<T>("pos", "updateEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.ExecuteNonQuery("pos", "updateEmployee",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, String name = null, Decimal? salary = null, String phone = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@salary", SqlDbType.Money, salary, null).Add("@phone", SqlDbType.VarChar, phone, 50);

        	return this.GetReader("pos", "updateEmployee",parameters.ToArray());
        }

	#endregion
	}
}