namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Addtelephonerecharge.
	/// </summary>
	public partial class Addtelephonerecharge : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(String phone = null, String folio = null, String companyName = null, String plan = null, Decimal? amount = null, Boolean? successful = null, String message = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@phone", SqlDbType.VarChar, phone, 10).Add("@folio", SqlDbType.VarChar, folio, 10).Add("@companyName", SqlDbType.VarChar, companyName, 20).Add("@plan", SqlDbType.VarChar, plan, 200).Add("@amount", SqlDbType.Money, amount, null).Add("@successful", SqlDbType.Bit, successful, null).Add("@message", SqlDbType.VarChar, message, 500);

        	return this.GetListBase<T>("pos", "addTelephoneRecharge",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(String phone = null, String folio = null, String companyName = null, String plan = null, Decimal? amount = null, Boolean? successful = null, String message = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@phone", SqlDbType.VarChar, phone, 10).Add("@folio", SqlDbType.VarChar, folio, 10).Add("@companyName", SqlDbType.VarChar, companyName, 20).Add("@plan", SqlDbType.VarChar, plan, 200).Add("@amount", SqlDbType.Money, amount, null).Add("@successful", SqlDbType.Bit, successful, null).Add("@message", SqlDbType.VarChar, message, 500);

        	return this.ExecuteScalar<T>("pos", "addTelephoneRecharge",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(String phone = null, String folio = null, String companyName = null, String plan = null, Decimal? amount = null, Boolean? successful = null, String message = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@phone", SqlDbType.VarChar, phone, 10).Add("@folio", SqlDbType.VarChar, folio, 10).Add("@companyName", SqlDbType.VarChar, companyName, 20).Add("@plan", SqlDbType.VarChar, plan, 200).Add("@amount", SqlDbType.Money, amount, null).Add("@successful", SqlDbType.Bit, successful, null).Add("@message", SqlDbType.VarChar, message, 500);

        	return this.ExecuteNonQuery("pos", "addTelephoneRecharge",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(String phone = null, String folio = null, String companyName = null, String plan = null, Decimal? amount = null, Boolean? successful = null, String message = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@phone", SqlDbType.VarChar, phone, 10).Add("@folio", SqlDbType.VarChar, folio, 10).Add("@companyName", SqlDbType.VarChar, companyName, 20).Add("@plan", SqlDbType.VarChar, plan, 200).Add("@amount", SqlDbType.Money, amount, null).Add("@successful", SqlDbType.Bit, successful, null).Add("@message", SqlDbType.VarChar, message, 500);

        	return this.GetReader("pos", "addTelephoneRecharge",parameters.ToArray());
        }

	#endregion
	}
}