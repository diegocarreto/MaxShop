namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Existpm.
	/// </summary>
	public partial class Existpm : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, int? idProduct = null, int? idMeasure = null, int? idBrand = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idBrand", SqlDbType.Int, idBrand, null);

        	return this.GetListBase<T>("pos", "existPM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, int? idProduct = null, int? idMeasure = null, int? idBrand = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idBrand", SqlDbType.Int, idBrand, null);

        	return this.ExecuteScalar<T>("pos", "existPM",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, int? idProduct = null, int? idMeasure = null, int? idBrand = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idBrand", SqlDbType.Int, idBrand, null);

        	return this.ExecuteNonQuery("pos", "existPM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, int? idProduct = null, int? idMeasure = null, int? idBrand = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idBrand", SqlDbType.Int, idBrand, null);

        	return this.GetReader("pos", "existPM",parameters.ToArray());
        }

	#endregion
	}
}