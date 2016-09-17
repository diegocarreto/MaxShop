namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Backupgetinfo.
	/// </summary>
	public partial class Backupgetinfo : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String Query = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@Query", SqlDbType.VarChar, Query, -1);

        	return this.GetListBase<T>("pos", "BackUpGetInfo",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String Query = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@Query", SqlDbType.VarChar, Query, -1);

        	return this.ExecuteScalar<T>("pos", "BackUpGetInfo",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String Query = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@Query", SqlDbType.VarChar, Query, -1);

        	return this.ExecuteNonQuery("pos", "BackUpGetInfo",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String Query = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@Query", SqlDbType.VarChar, Query, -1);

        	return this.GetReader("pos", "BackUpGetInfo",parameters.ToArray());
        }

	#endregion
	}
}