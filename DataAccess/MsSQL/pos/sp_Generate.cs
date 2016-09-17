namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados SpGenerate.
	/// </summary>
	public partial class SpGenerate : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String tableName = null, Boolean? eliminarSiExisten = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@tableName", SqlDbType.VarChar, tableName, 100).Add("@eliminarSiExisten", SqlDbType.Bit, eliminarSiExisten, null);

        	return this.GetListBase<T>("pos", "sp_Generate",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String tableName = null, Boolean? eliminarSiExisten = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@tableName", SqlDbType.VarChar, tableName, 100).Add("@eliminarSiExisten", SqlDbType.Bit, eliminarSiExisten, null);

        	return this.ExecuteScalar<T>("pos", "sp_Generate",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String tableName = null, Boolean? eliminarSiExisten = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@tableName", SqlDbType.VarChar, tableName, 100).Add("@eliminarSiExisten", SqlDbType.Bit, eliminarSiExisten, null);

        	return this.ExecuteNonQuery("pos", "sp_Generate",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String tableName = null, Boolean? eliminarSiExisten = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@tableName", SqlDbType.VarChar, tableName, 100).Add("@eliminarSiExisten", SqlDbType.Bit, eliminarSiExisten, null);

        	return this.GetReader("pos", "sp_Generate",parameters.ToArray());
        }

	#endregion
	}
}