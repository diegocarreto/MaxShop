namespace DataAccess.MsSqlCommands.Pos
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using DataAccess.MSSQL;
	using DataAccess.Utilities;

	/// <summary>
	/// Controla la ejecucion del procedimientos almacenados Updatepm.
	/// </summary>
	public partial class Updatepm : AccessMsSQL
	{
        #region Methods

        /// <summary>
        /// Obtiene una lista del tipo de objectos indicado con el merge entre las propiedades del objeto y el resulset obtenido de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public List<T> ExeList<T>(int? id = null, int? idProduct = null, int? idMeasure = null, int? idMeasure2 = null, Double? amountMeasure2 = null, int? idBrand = null, Decimal? price = null, Boolean? active = null, String barCode = null, String codeVendor = null, Boolean? freight = null, int? idLocation = null, String name = null, int? Max = null, int? Min = null, int? idCompany = null) where T : new()
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idMeasure2", SqlDbType.Int, idMeasure2, null).Add("@amountMeasure2", SqlDbType.Float, amountMeasure2, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@price", SqlDbType.Money, price, null).Add("@active", SqlDbType.Bit, active, null).Add("@barCode", SqlDbType.VarChar, barCode, 50).Add("@codeVendor", SqlDbType.VarChar, codeVendor, 50).Add("@freight", SqlDbType.Bit, freight, null).Add("@idLocation", SqlDbType.Int, idLocation, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@Max", SqlDbType.Int, Max, null).Add("@Min", SqlDbType.Int, Min, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetListBase<T>("pos", "updatePM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene el scalar resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public T ExeScalar<T>(int? id = null, int? idProduct = null, int? idMeasure = null, int? idMeasure2 = null, Double? amountMeasure2 = null, int? idBrand = null, Decimal? price = null, Boolean? active = null, String barCode = null, String codeVendor = null, Boolean? freight = null, int? idLocation = null, String name = null, int? Max = null, int? Min = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idMeasure2", SqlDbType.Int, idMeasure2, null).Add("@amountMeasure2", SqlDbType.Float, amountMeasure2, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@price", SqlDbType.Money, price, null).Add("@active", SqlDbType.Bit, active, null).Add("@barCode", SqlDbType.VarChar, barCode, 50).Add("@codeVendor", SqlDbType.VarChar, codeVendor, 50).Add("@freight", SqlDbType.Bit, freight, null).Add("@idLocation", SqlDbType.Int, idLocation, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@Max", SqlDbType.Int, Max, null).Add("@Min", SqlDbType.Int, Min, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteScalar<T>("pos", "updatePM",parameters.ToArray());
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado.
        /// </summary>
        /// <returns></returns>
        public int ExeNonQuery(int? id = null, int? idProduct = null, int? idMeasure = null, int? idMeasure2 = null, Double? amountMeasure2 = null, int? idBrand = null, Decimal? price = null, Boolean? active = null, String barCode = null, String codeVendor = null, Boolean? freight = null, int? idLocation = null, String name = null, int? Max = null, int? Min = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idMeasure2", SqlDbType.Int, idMeasure2, null).Add("@amountMeasure2", SqlDbType.Float, amountMeasure2, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@price", SqlDbType.Money, price, null).Add("@active", SqlDbType.Bit, active, null).Add("@barCode", SqlDbType.VarChar, barCode, 50).Add("@codeVendor", SqlDbType.VarChar, codeVendor, 50).Add("@freight", SqlDbType.Bit, freight, null).Add("@idLocation", SqlDbType.Int, idLocation, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@Max", SqlDbType.Int, Max, null).Add("@Min", SqlDbType.Int, Min, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.ExecuteNonQuery("pos", "updatePM",parameters.ToArray());
        }

        /// <summary>
        /// Obtiene un objeto IDataReader resultante de la ejecucion.
        /// </summary>
        /// <returns></returns>
        public IDataReader ExeReader(int? id = null, int? idProduct = null, int? idMeasure = null, int? idMeasure2 = null, Double? amountMeasure2 = null, int? idBrand = null, Decimal? price = null, Boolean? active = null, String barCode = null, String codeVendor = null, Boolean? freight = null, int? idLocation = null, String name = null, int? Max = null, int? Min = null, int? idCompany = null)
        {
        	List<SqlParameter> parameters = new List<SqlParameter>();

        	parameters.Add("@id", SqlDbType.Int, id, null).Add("@idProduct", SqlDbType.Int, idProduct, null).Add("@idMeasure", SqlDbType.Int, idMeasure, null).Add("@idMeasure2", SqlDbType.Int, idMeasure2, null).Add("@amountMeasure2", SqlDbType.Float, amountMeasure2, null).Add("@idBrand", SqlDbType.Int, idBrand, null).Add("@price", SqlDbType.Money, price, null).Add("@active", SqlDbType.Bit, active, null).Add("@barCode", SqlDbType.VarChar, barCode, 50).Add("@codeVendor", SqlDbType.VarChar, codeVendor, 50).Add("@freight", SqlDbType.Bit, freight, null).Add("@idLocation", SqlDbType.Int, idLocation, null).Add("@name", SqlDbType.VarChar, name, 50).Add("@Max", SqlDbType.Int, Max, null).Add("@Min", SqlDbType.Int, Min, null).Add("@idCompany", SqlDbType.Int, idCompany, null);

        	return this.GetReader("pos", "updatePM",parameters.ToArray());
        }

	#endregion
	}
}