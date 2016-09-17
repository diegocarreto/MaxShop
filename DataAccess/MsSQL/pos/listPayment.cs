namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listpayment.
	/// </summary>
	public partial class Listpayment : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idLoan = null, int? id = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@id", SqlDbType.Int, id, null);

        	return this.GetListBase<T>("pos", "listPayment",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idLoan = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@id", SqlDbType.Int, id, null);

        	return this.ExecuteScalar<T>("pos", "listPayment",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idLoan = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@id", SqlDbType.Int, id, null);

        	return this.ExecuteNonQuery("pos", "listPayment",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idLoan = null, int? id = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idLoan", SqlDbType.Int, idLoan, null).Add("@id", SqlDbType.Int, id, null);

        	return this.GetReader("pos", "listPayment",parameters.ToArray());
        }

	#endregion
	}
}