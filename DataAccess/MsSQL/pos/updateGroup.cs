namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Updategroup.
	/// </summary>
	public partial class Updategroup : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, String name = null, String prefix = null, Boolean? active = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@prefix", SqlDbType.VarChar, prefix, 10).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetListBase<T>("pos", "updateGroup",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, String name = null, String prefix = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@prefix", SqlDbType.VarChar, prefix, 10).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteScalar<T>("pos", "updateGroup",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, String name = null, String prefix = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@prefix", SqlDbType.VarChar, prefix, 10).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteNonQuery("pos", "updateGroup",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, String name = null, String prefix = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@prefix", SqlDbType.VarChar, prefix, 10).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetReader("pos", "updateGroup",parameters.ToArray());
        }

	#endregion
	}
}