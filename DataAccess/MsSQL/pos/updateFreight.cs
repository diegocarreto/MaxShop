namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Updatefreight.
	/// </summary>
	public partial class Updatefreight : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, int? idPM = null, int? idDestination = null, Decimal? cost = null, Double? min = null, Double? max = null, Boolean? active = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null).Add("@cost", SqlDbType.Money, cost, null).Add("@min", SqlDbType.Float, min, null).Add("@max", SqlDbType.Float, max, null).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetListBase<T>("pos", "updateFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, int? idPM = null, int? idDestination = null, Decimal? cost = null, Double? min = null, Double? max = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null).Add("@cost", SqlDbType.Money, cost, null).Add("@min", SqlDbType.Float, min, null).Add("@max", SqlDbType.Float, max, null).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteScalar<T>("pos", "updateFreight",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, int? idPM = null, int? idDestination = null, Decimal? cost = null, Double? min = null, Double? max = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null).Add("@cost", SqlDbType.Money, cost, null).Add("@min", SqlDbType.Float, min, null).Add("@max", SqlDbType.Float, max, null).Add("@active", SqlDbType.Bit, active, null);

        	return this.ExecuteNonQuery("pos", "updateFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, int? idPM = null, int? idDestination = null, Decimal? cost = null, Double? min = null, Double? max = null, Boolean? active = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idPM", SqlDbType.Int, idPM, null).Add("@idDestination", SqlDbType.Int, idDestination, null).Add("@cost", SqlDbType.Money, cost, null).Add("@min", SqlDbType.Float, min, null).Add("@max", SqlDbType.Float, max, null).Add("@active", SqlDbType.Bit, active, null);

        	return this.GetReader("pos", "updateFreight",parameters.ToArray());
        }

	#endregion
	}
}