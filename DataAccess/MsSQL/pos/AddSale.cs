namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addsale.
	/// </summary>
	public partial class Addsale : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(Double? total = null, int? idClient = null, String Type = null, Double? payment = null, Boolean? freight = null, Double? OnAccount = null, Double? change = null, int? IdCompany = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@idClient", SqlDbType.Int, idClient, null).Add("@Type", SqlDbType.VarChar, Type, 30).Add("@payment", SqlDbType.Float, payment, null).Add("@freight", SqlDbType.Bit, freight, null).Add("@OnAccount", SqlDbType.Float, OnAccount, null).Add("@change", SqlDbType.Float, change, null).Add("@IdCompany", SqlDbType.Int, IdCompany, null);

        	return this.GetListBase<T>("pos", "AddSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(Double? total = null, int? idClient = null, String Type = null, Double? payment = null, Boolean? freight = null, Double? OnAccount = null, Double? change = null, int? IdCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@idClient", SqlDbType.Int, idClient, null).Add("@Type", SqlDbType.VarChar, Type, 30).Add("@payment", SqlDbType.Float, payment, null).Add("@freight", SqlDbType.Bit, freight, null).Add("@OnAccount", SqlDbType.Float, OnAccount, null).Add("@change", SqlDbType.Float, change, null).Add("@IdCompany", SqlDbType.Int, IdCompany, null);

        	return this.ExecuteScalar<T>("pos", "AddSale",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(Double? total = null, int? idClient = null, String Type = null, Double? payment = null, Boolean? freight = null, Double? OnAccount = null, Double? change = null, int? IdCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@idClient", SqlDbType.Int, idClient, null).Add("@Type", SqlDbType.VarChar, Type, 30).Add("@payment", SqlDbType.Float, payment, null).Add("@freight", SqlDbType.Bit, freight, null).Add("@OnAccount", SqlDbType.Float, OnAccount, null).Add("@change", SqlDbType.Float, change, null).Add("@IdCompany", SqlDbType.Int, IdCompany, null);

        	return this.ExecuteNonQuery("pos", "AddSale",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(Double? total = null, int? idClient = null, String Type = null, Double? payment = null, Boolean? freight = null, Double? OnAccount = null, Double? change = null, int? IdCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@idClient", SqlDbType.Int, idClient, null).Add("@Type", SqlDbType.VarChar, Type, 30).Add("@payment", SqlDbType.Float, payment, null).Add("@freight", SqlDbType.Bit, freight, null).Add("@OnAccount", SqlDbType.Float, OnAccount, null).Add("@change", SqlDbType.Float, change, null).Add("@IdCompany", SqlDbType.Int, IdCompany, null);

        	return this.GetReader("pos", "AddSale",parameters.ToArray());
        }

	#endregion
	}
}