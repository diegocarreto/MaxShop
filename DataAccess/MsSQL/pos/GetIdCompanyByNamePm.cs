namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Getidcompanybynamepm.
	/// </summary>
	public partial class Getidcompanybynamepm : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String name = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetListBase<T>("pos", "GetIdCompanyByNamePm",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteScalar<T>("pos", "GetIdCompanyByNamePm",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100);

        	return this.ExecuteNonQuery("pos", "GetIdCompanyByNamePm",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String name = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 100);

        	return this.GetReader("pos", "GetIdCompanyByNamePm",parameters.ToArray());
        }

	#endregion
	}
}