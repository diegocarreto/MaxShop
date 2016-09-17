namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Checkbox.
	/// </summary>
	public partial class Checkbox : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? idUser = null, int? cashRegister = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null);

        	return this.GetListBase<T>("pos", "CheckBox",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? idUser = null, int? cashRegister = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null);

        	return this.ExecuteScalar<T>("pos", "CheckBox",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? idUser = null, int? cashRegister = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null);

        	return this.ExecuteNonQuery("pos", "CheckBox",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? idUser = null, int? cashRegister = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@idUser", SqlDbType.Int, idUser, null).Add("@cashRegister", SqlDbType.Int, cashRegister, null);

        	return this.GetReader("pos", "CheckBox",parameters.ToArray());
        }

	#endregion
	}
}