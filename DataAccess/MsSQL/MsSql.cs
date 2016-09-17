using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.MsSqlCommands;

namespace DataAccess.MSSQL
{
	public class MsSQL : IDisposable
	{
		#region Properties

		/// <summary>
		/// Controla la ejecucion de los procedimientos almacenados de la conexion Pos.
		/// </summary>
		public DataAccess.MSSQL.Pos.Pos Pos = new DataAccess.MSSQL.Pos.Pos();


		#endregion

		#region Methods

		public void Dispose()
		{
			if (this.Pos != null)
				this.Pos.Dispose();


		}

		#endregion
	}
}