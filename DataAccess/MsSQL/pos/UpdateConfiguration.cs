namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Updateconfiguration.
	/// </summary>
	public partial class Updateconfiguration : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String key = null, String value = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50).Add("@value", SqlDbType.VarChar, value, 8000);

        	return this.GetListBase<T>("pos", "UpdateConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String key = null, String value = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50).Add("@value", SqlDbType.VarChar, value, 8000);

        	return this.ExecuteScalar<T>("pos", "UpdateConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String key = null, String value = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50).Add("@value", SqlDbType.VarChar, value, 8000);

        	return this.ExecuteNonQuery("pos", "UpdateConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String key = null, String value = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50).Add("@value", SqlDbType.VarChar, value, 8000);

        	return this.GetReader("pos", "UpdateConfiguration",parameters.ToArray());
        }

	#endregion
	}
}