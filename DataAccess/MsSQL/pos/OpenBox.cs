namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Openbox.
	/// </summary>
	public partial class Openbox : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idUser = null, int? cashRegister = null, Decimal? amount = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null).Add("@amount", SqlDbType.Money, amount, null);

        	return this.GetListBase<T>("pos", "OpenBox",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idUser = null, int? cashRegister = null, Decimal? amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null).Add("@amount", SqlDbType.Money, amount, null);

        	return this.ExecuteScalar<T>("pos", "OpenBox",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idUser = null, int? cashRegister = null, Decimal? amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null).Add("@amount", SqlDbType.Money, amount, null);

        	return this.ExecuteNonQuery("pos", "OpenBox",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idUser = null, int? cashRegister = null, Decimal? amount = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null).Add("@amount", SqlDbType.Money, amount, null);

        	return this.GetReader("pos", "OpenBox",parameters.ToArray());
        }

	#endregion
	}
}