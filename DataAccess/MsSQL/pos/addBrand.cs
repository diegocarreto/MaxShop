namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addbrand.
	/// </summary>
	public partial class Addbrand : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String name = null, Boolean? active = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetListBase<T>("pos", "AddBrand",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String name = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteScalar<T>("pos", "AddBrand",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String name = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteNonQuery("pos", "AddBrand",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String name = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetReader("pos", "AddBrand",parameters.ToArray());
        }

	#endregion
	}
}