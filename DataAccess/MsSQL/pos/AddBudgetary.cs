namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addbudgetary.
	/// </summary>
	public partial class Addbudgetary : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(Double? total = null, String clientName = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@clientName", SqlDbType.VarChar, clientName, 200);

        	return this.GetListBase<T>("pos", "AddBudgetary",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(Double? total = null, String clientName = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@clientName", SqlDbType.VarChar, clientName, 200);

        	return this.ExecuteScalar<T>("pos", "AddBudgetary",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(Double? total = null, String clientName = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@clientName", SqlDbType.VarChar, clientName, 200);

        	return this.ExecuteNonQuery("pos", "AddBudgetary",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(Double? total = null, String clientName = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@total", SqlDbType.Float, total, null).Add("@clientName", SqlDbType.VarChar, clientName, 200);

        	return this.GetReader("pos", "AddBudgetary",parameters.ToArray());
        }

	#endregion
	}
}