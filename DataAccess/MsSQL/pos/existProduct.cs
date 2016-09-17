namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Existproduct.
	/// </summary>
	public partial class Existproduct : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idLabel = null, int? idMaterial = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null);

        	return this.GetListBase<T>("pos", "existProduct",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idLabel = null, int? idMaterial = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null);

        	return this.ExecuteScalar<T>("pos", "existProduct",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idLabel = null, int? idMaterial = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null);

        	return this.ExecuteNonQuery("pos", "existProduct",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idLabel = null, int? idMaterial = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null);

        	return this.GetReader("pos", "existProduct",parameters.ToArray());
        }

	#endregion
	}
}