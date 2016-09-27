namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Listpmbycode.
	/// </summary>
	public partial class Listpmbycode : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String barCode = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@barCode", SqlDbType.VarChar, barCode, 50);

        	return this.GetListBase<T>("pos", "listPMByCode",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String barCode = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@barCode", SqlDbType.VarChar, barCode, 50);

        	return this.ExecuteScalar<T>("pos", "listPMByCode",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String barCode = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@barCode", SqlDbType.VarChar, barCode, 50);

        	return this.ExecuteNonQuery("pos", "listPMByCode",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String barCode = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@barCode", SqlDbType.VarChar, barCode, 50);

        	return this.GetReader("pos", "listPMByCode",parameters.ToArray());
        }

	#endregion
	}
}