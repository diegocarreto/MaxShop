namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addclient.
	/// </summary>
	public partial class Addclient : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String name = null, String phone1 = null, String phone2 = null, String street = null, String number1 = null, String number2 = null, String colony = null, String municipality = null, String state = null, String zip = null, String others = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 150).Add("@phone1", SqlDbType.VarChar, phone1, 10).Add("@phone2", SqlDbType.VarChar, phone2, 10).Add("@street", SqlDbType.VarChar, street, 250).Add("@number1", SqlDbType.VarChar, number1, 10).Add("@number2", SqlDbType.VarChar, number2, 10).Add("@colony", SqlDbType.VarChar, colony, 30).Add("@municipality", SqlDbType.VarChar, municipality, 30).Add("@state", SqlDbType.VarChar, state, 30).Add("@zip", SqlDbType.VarChar, zip, 6).Add("@others", SqlDbType.VarChar, others, 2000);

        	return this.GetListBase<T>("pos", "AddClient",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String name = null, String phone1 = null, String phone2 = null, String street = null, String number1 = null, String number2 = null, String colony = null, String municipality = null, String state = null, String zip = null, String others = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 150).Add("@phone1", SqlDbType.VarChar, phone1, 10).Add("@phone2", SqlDbType.VarChar, phone2, 10).Add("@street", SqlDbType.VarChar, street, 250).Add("@number1", SqlDbType.VarChar, number1, 10).Add("@number2", SqlDbType.VarChar, number2, 10).Add("@colony", SqlDbType.VarChar, colony, 30).Add("@municipality", SqlDbType.VarChar, municipality, 30).Add("@state", SqlDbType.VarChar, state, 30).Add("@zip", SqlDbType.VarChar, zip, 6).Add("@others", SqlDbType.VarChar, others, 2000);

        	return this.ExecuteScalar<T>("pos", "AddClient",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String name = null, String phone1 = null, String phone2 = null, String street = null, String number1 = null, String number2 = null, String colony = null, String municipality = null, String state = null, String zip = null, String others = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 150).Add("@phone1", SqlDbType.VarChar, phone1, 10).Add("@phone2", SqlDbType.VarChar, phone2, 10).Add("@street", SqlDbType.VarChar, street, 250).Add("@number1", SqlDbType.VarChar, number1, 10).Add("@number2", SqlDbType.VarChar, number2, 10).Add("@colony", SqlDbType.VarChar, colony, 30).Add("@municipality", SqlDbType.VarChar, municipality, 30).Add("@state", SqlDbType.VarChar, state, 30).Add("@zip", SqlDbType.VarChar, zip, 6).Add("@others", SqlDbType.VarChar, others, 2000);

        	return this.ExecuteNonQuery("pos", "AddClient",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String name = null, String phone1 = null, String phone2 = null, String street = null, String number1 = null, String number2 = null, String colony = null, String municipality = null, String state = null, String zip = null, String others = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@name", SqlDbType.VarChar, name, 150).Add("@phone1", SqlDbType.VarChar, phone1, 10).Add("@phone2", SqlDbType.VarChar, phone2, 10).Add("@street", SqlDbType.VarChar, street, 250).Add("@number1", SqlDbType.VarChar, number1, 10).Add("@number2", SqlDbType.VarChar, number2, 10).Add("@colony", SqlDbType.VarChar, colony, 30).Add("@municipality", SqlDbType.VarChar, municipality, 30).Add("@state", SqlDbType.VarChar, state, 30).Add("@zip", SqlDbType.VarChar, zip, 6).Add("@others", SqlDbType.VarChar, others, 2000);

        	return this.GetReader("pos", "AddClient",parameters.ToArray());
        }

	#endregion
	}
}