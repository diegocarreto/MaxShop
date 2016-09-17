namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addproduct.
	/// </summary>
	public partial class Addproduct : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idGroup = null, int? idLabel = null, int? idMaterial = null, String pathImage = null, Boolean? active = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null).Add("@pathImage", SqlDbType.VarChar, pathImage, 500).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetListBase<T>("pos", "addProduct",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idGroup = null, int? idLabel = null, int? idMaterial = null, String pathImage = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null).Add("@pathImage", SqlDbType.VarChar, pathImage, 500).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteScalar<T>("pos", "addProduct",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idGroup = null, int? idLabel = null, int? idMaterial = null, String pathImage = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null).Add("@pathImage", SqlDbType.VarChar, pathImage, 500).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteNonQuery("pos", "addProduct",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idGroup = null, int? idLabel = null, int? idMaterial = null, String pathImage = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@idLabel", SqlDbType.Int, idLabel, null).Add("@idMaterial", SqlDbType.Int, idMaterial, null).Add("@pathImage", SqlDbType.VarChar, pathImage, 500).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetReader("pos", "addProduct",parameters.ToArray());
        }

	#endregion
	}
}