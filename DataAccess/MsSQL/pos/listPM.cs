namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listpm.
	/// </summary>
	public partial class Listpm : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, String name = null, Boolean? hasImage = null, int? idBrand = null, int? idGroup = null, int? typeLike = null, int? idCompany = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@hasImage", SqlDbType.Bit, hasImage, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@typeLike", SqlDbType.Int, typeLike, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetListBase<T>("pos", "listPM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, String name = null, Boolean? hasImage = null, int? idBrand = null, int? idGroup = null, int? typeLike = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@hasImage", SqlDbType.Bit, hasImage, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@typeLike", SqlDbType.Int, typeLike, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteScalar<T>("pos", "listPM",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, String name = null, Boolean? hasImage = null, int? idBrand = null, int? idGroup = null, int? typeLike = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@hasImage", SqlDbType.Bit, hasImage, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@typeLike", SqlDbType.Int, typeLike, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteNonQuery("pos", "listPM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, String name = null, Boolean? hasImage = null, int? idBrand = null, int? idGroup = null, int? typeLike = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@name", SqlDbType.VarChar, name, 100).Add("@hasImage", SqlDbType.Bit, hasImage, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@idGroup", SqlDbType.Int, idGroup, null).Add("@typeLike", SqlDbType.Int, typeLike, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetReader("pos", "listPM",parameters.ToArray());
        }

	#endregion
	}
}