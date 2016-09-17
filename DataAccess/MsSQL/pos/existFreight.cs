namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Existfreight.
	/// </summary>
	public partial class Existfreight : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idPM = null, int? idDestination = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null);

        	return this.GetListBase<T>("pos", "existFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idPM = null, int? idDestination = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null);

        	return this.ExecuteScalar<T>("pos", "existFreight",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idPM = null, int? idDestination = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null);

        	return this.ExecuteNonQuery("pos", "existFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idPM = null, int? idDestination = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null);

        	return this.GetReader("pos", "existFreight",parameters.ToArray());
        }

	#endregion
	}
}