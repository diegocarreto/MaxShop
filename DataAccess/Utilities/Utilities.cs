using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Utilities
{
    public static class Utilities
    {
        public static List<SqlParameter> Add(this List<SqlParameter> Parameters, string Name, SqlDbType Type, object Value, int? Size = null)
        {
            SqlParameter parameter;

            if (Size.HasValue)
                parameter = new SqlParameter(Name, Type, Size.Value);
            else
                parameter = new SqlParameter(Name, Type);

            parameter.Value = (Value is string && string.IsNullOrWhiteSpace(Value.ToString())) ? null : Value;

            Parameters.Add(parameter);

            return Parameters;
        }

        public static List<MySqlParameter> Add(this List<MySqlParameter> Parameters, string Name, MySqlDbType Type, object Value, int? Size = null)
        {
            MySqlParameter parameter;

            if (Size.HasValue)
                parameter = new MySqlParameter(Name, Type, Size.Value);
            else
                parameter = new MySqlParameter(Name, Type);

            parameter.Value = (Value is string && string.IsNullOrWhiteSpace(Value.ToString())) ? null : Value;

            Parameters.Add(parameter);

            return Parameters;
        }
    }
}
