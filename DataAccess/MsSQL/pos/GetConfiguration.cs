namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Getconfiguration.
	/// </summary>
	public partial class Getconfiguration : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String key = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50);

        	return this.GetListBase<T>("pos", "GetConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String key = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50);

        	return this.ExecuteScalar<T>("pos", "GetConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String key = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50);

        	return this.ExecuteNonQuery("pos", "GetConfiguration",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String key = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@key", SqlDbType.VarChar, key, 50);

        	return this.GetReader("pos", "GetConfiguration",parameters.ToArray());
        }

	#endregion
	}
}