namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Getpricepmfreight.
	/// </summary>
	public partial class Getpricepmfreight : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? IdPM = null, int? IdDestination = null, Double? Amount = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@IdPM", SqlDbType.Int, IdPM, null).Add("@IdDestination", SqlDbType.Int, IdDestination, null).Add("@Amount", SqlDbType.Float, Amount, null);

        	return this.GetListBase<T>("pos", "GetPricePMFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? IdPM = null, int? IdDestination = null, Double? Amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@IdPM", SqlDbType.Int, IdPM, null).Add("@IdDestination", SqlDbType.Int, IdDestination, null).Add("@Amount", SqlDbType.Float, Amount, null);

        	return this.ExecuteScalar<T>("pos", "GetPricePMFreight",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? IdPM = null, int? IdDestination = null, Double? Amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@IdPM", SqlDbType.Int, IdPM, null).Add("@IdDestination", SqlDbType.Int, IdDestination, null).Add("@Amount", SqlDbType.Float, Amount, null);

        	return this.ExecuteNonQuery("pos", "GetPricePMFreight",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? IdPM = null, int? IdDestination = null, Double? Amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@IdPM", SqlDbType.Int, IdPM, null).Add("@IdDestination", SqlDbType.Int, IdDestination, null).Add("@Amount", SqlDbType.Float, Amount, null);

        	return this.GetReader("pos", "GetPricePMFreight",parameters.ToArray());
        }

	#endregion
	}
}