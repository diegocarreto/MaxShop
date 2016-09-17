namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados SpAlterdiagram.
	/// </summary>
	public partial class SpAlterdiagram : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String diagramname = null, int? owner_id = null, int? version = null, Byte[] definition = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@diagramname", SqlDbType.NVarChar, diagramname, 128).Add("@owner_id", SqlDbType.Int, owner_id, null).Add("@version", SqlDbType.Int, version, null).Add("@definition", SqlDbType.VarBinary, definition, -1);

        	return this.GetListBase<T>("pos", "sp_alterdiagram",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String diagramname = null, int? owner_id = null, int? version = null, Byte[] definition = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@diagramname", SqlDbType.NVarChar, diagramname, 128).Add("@owner_id", SqlDbType.Int, owner_id, null).Add("@version", SqlDbType.Int, version, null).Add("@definition", SqlDbType.VarBinary, definition, -1);

        	return this.ExecuteScalar<T>("pos", "sp_alterdiagram",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String diagramname = null, int? owner_id = null, int? version = null, Byte[] definition = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@diagramname", SqlDbType.NVarChar, diagramname, 128).Add("@owner_id", SqlDbType.Int, owner_id, null).Add("@version", SqlDbType.Int, version, null).Add("@definition", SqlDbType.VarBinary, definition, -1);

        	return this.ExecuteNonQuery("pos", "sp_alterdiagram",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String diagramname = null, int? owner_id = null, int? version = null, Byte[] definition = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@diagramname", SqlDbType.NVarChar, diagramname, 128).Add("@owner_id", SqlDbType.Int, owner_id, null).Add("@version", SqlDbType.Int, version, null).Add("@definition", SqlDbType.VarBinary, definition, -1);

        	return this.GetReader("pos", "sp_alterdiagram",parameters.ToArray());
        }

	#endregion
	}
}