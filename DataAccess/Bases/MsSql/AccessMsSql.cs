using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccess.MSSQL
{
    /// <summary>
    /// Gestiona la comunicacion con MS SQL Server.
    /// </summary>
    public class AccessMsSQL : IDisposable
    {
        #region Members

        /// <summary>
        /// Guarda las cadenas de conexion.
        /// </summary>
        private Dictionary<string, SqlConnection> ConnectionPool;

        /// <summary>
        /// Indica si se debe liberar el recurso.
        /// </summary>
        private bool Disposed;

        /// <summary>
        /// Guarda las transacciones.
        /// </summary>
        private Dictionary<string, SqlTransaction> TransactionPool;

        #endregion

        #region Properties
        #endregion

        #region Builder

        /// <summary>
        /// Constructor default.
        /// </summary>
        public AccessMsSQL()
        {
            ConnectionPool = new Dictionary<string, SqlConnection>();
            TransactionPool = new Dictionary<string, SqlTransaction>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inicia la transaccion de base de datos.
        /// <param name="ConnectionName">Nombre de la cadena de conexion en la cual se iniciara la transaccion.</param>
        /// </summary>
        protected void Begin(string ConnectionName)
        {
            if (!TransactionPool.ContainsKey(ConnectionName))
                TransactionPool.Add(ConnectionName, ConnectionPool[ConnectionName].BeginTransaction());
        }

        /// <summary>
        /// Confirma la transaccion de base de datos. 
        /// <param name="ConnectionName">Nombre de la cadena de conexion en la cual se realizara la transaccion.</param>
        /// </summary>
        protected void Commit(string ConnectionName)
        {
            TransactionPool[ConnectionName].Commit();
            TransactionPool.Remove(ConnectionName);
        }

        /// <summary>
        /// Libera los recursos y llama al Garbage Collector.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos.
        /// </summary>
        /// <param name="Disposing">Indicoa si se debe cerrar la conexion a base de datos.</param>
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                    if (ConnectionPool != null)
                    {
                        foreach (KeyValuePair<string, SqlConnection> connection in ConnectionPool)
                        {
                            if (connection.Value.State != System.Data.ConnectionState.Closed)
                            {
                                connection.Value.Close();
                                connection.Value.Dispose();
                            }
                        }
                    }
                }

                ConnectionPool = null;
                Disposed = true;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve el numero de filas afectadas.
        /// </summary>
        /// <param name="ConnectionName">Nombre de la cadena de conexion a la cual pertenece el procedimiento almacenado.</param>
        /// <param name="StoreProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="Parameters">Array de objetos SqlParameter.</param>
        /// <returns>Numero de filas afectadas.</returns>
        protected int ExecuteNonQuery(string ConnectionName, string StoreProcedure, params SqlParameter[] Parameters)
        {
            using (SqlCommand cmd = GetCommand(ConnectionName, StoreProcedure, Parameters))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve la primera columna de la primera fila del result set obtenido.
        /// </summary>
        /// <typeparam name="T">Tipo en al que se convertira el resultado obtenido.</typeparam>
        /// <param name="ConnectionName">Nombre de la cadena de conexion a la cual pertenece el procedimiento almacenado.</param>
        /// <param name="StoreProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="Parameters">Array de objetos SqlParameter.</param>
        /// <returns>Valor de la primera columna de la primera fila del result set obtenido.</returns>
        protected T ExecuteScalar<T>(string ConnectionName, string StoreProcedure, params SqlParameter[] Parameters)
        {
            using (SqlCommand cmd = GetCommand(ConnectionName, StoreProcedure, Parameters))
            {
                dynamic objR;

                objR = cmd.ExecuteScalar();

                if (objR != null)
                    objR = (T)objR;
                else
                    objR = default(T);

                return objR;
            }
        }

        /// <summary>
        /// Ontiene un objeto de tipo SqlCommand configurado. 
        /// </summary>
        /// <param name="ConnectionName">Nombre de la cadena de conexion a la cual pertenece el procedimiento almacenado.</param>
        /// <param name="StoreProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="Parameters">Matriz de parametros del procedimiento almacenado.</param>
        /// <returns>Objeto SqlCommand.</returns>
        private SqlCommand GetCommand(string ConnectionName, string StoreProcedure, params SqlParameter[] Parameters)
        {
            using (SqlCommand cmd = new SqlCommand(StoreProcedure))
            {
                if (Parameters.Length > 0)
                    cmd.Parameters.AddRange(Parameters);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = GetConnection(ConnectionName);

                return cmd;
            }
        }

        /// <summary>
        /// Obtiene la conexion indicada.
        /// </summary>
        /// <param name="ConnectionName">Nombre de la cadena de conexion que se desea obtener.</param>
        /// <returns>Objeto SqlConnection.</returns>
        private SqlConnection GetConnection(string ConnectionName)
        {
            SqlConnection Connection;

            if (ConnectionPool.ContainsKey(ConnectionName))
                Connection = ConnectionPool[ConnectionName];
            else
            {
                Connection = new FunctionsSql().GetConnectionMsSQL(ConnectionName);

                ConnectionPool.Add(ConnectionName, Connection);

                try
                {

                    Connection.Open();

                }
                catch (Exception ex)
                { 
                
                }
            }

            return Connection;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve un listado de objetos del tipo indicado.
        /// </summary>
        /// <typeparam name="T">Tipo en al que se convertira el resultado obtenido.</typeparam>
        /// <param name="ConnectionName">Nombre de la cadena de conexion a la cual pertenece el procedimiento almacenado.</param>
        /// <param name="StoreProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="Parameters">Array de objetos SqlParameter.</param>
        /// <returns></returns>
        protected List<T> GetListBase<T>(string ConnectionName, string StoreProcedure, params SqlParameter[] Parameters) where T : new()
        {
            using (SqlCommand cmd = GetCommand(ConnectionName, StoreProcedure, Parameters))
            {
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    List<T> list = new List<T>();

                    while (reader.Read())
                    {
                        list.Add(ToObject<T>(reader));
                    }

                    return list;
                }
            }
        }

        /// <summary>
        /// Obtiene un parametro de tipo SqlParameter.
        /// </summary>
        /// <param name="Name">Nombre del parametro.</param>
        /// <param name="Type">Tipo del parametro.</param>
        /// <param name="Size">Tamanio del parametro.</param>
        /// <param name="Value">Valor del parametro.</param>
        /// <returns>Parametro de tipo SqlParameter.</returns>
        protected static SqlParameter GetParam(string Name, SqlDbType Type, int? Size, object Value)
        {
            SqlParameter parametro;

            if (Size.HasValue)
                parametro = new SqlParameter(Name, Type, Size.Value);
            else
                parametro = new SqlParameter(Name, Type);

            parametro.Value = (Value is string && string.IsNullOrWhiteSpace(Value.ToString())) ? null : Value;

            return parametro;
        }

        /// <summary>
        /// Obtiene un arreglo de parametros de tipo SqlParameter.
        /// </summary>
        /// <param name="Names">Nombres de los parametros.</param>
        /// <param name="Types">Tipos de los parametros.</param>
        /// <param name="Sizes">Tamanios de los parametros.</param>
        /// <param name="Values">Valores de los parametros.</param>
        /// <returns>Arreglo de parametros de tipo SqlParameter.</returns>
        protected SqlParameter[] GetParams(string[] Names, SqlDbType[] Types, int?[] Sizes, object[] Values)
        {
            SqlParameter[] parametros = new SqlParameter[Names.Length];

            for (int i = 0; i < Names.Length; i++)
            {
                parametros[i] = GetParam(Names[i], Types[i], Sizes[i], Values[i]);
            }

            return parametros;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve un objeto IDataReader.
        /// </summary>
        /// <param name="ConnectionName">Nombre de la cadena de conexion a la cual pertenece el procedimiento almacenado.</param>
        /// <param name="StoreProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="Parameters">Array de objetos SqlParameter.</param>
        /// <returns></returns>
        protected IDataReader GetReader(string ConnectionName, string StoreProcedure, params SqlParameter[] Parameters)
        {
            using (SqlCommand cmd = GetCommand(ConnectionName, StoreProcedure, Parameters))
            {
                return cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Convierte una fila en un objeto y asigna los valores de las columnas en las propiedades del objeto. 
        /// </summary>
        /// <typeparam name="T">Tipo en al que se convertira el resultado obtenido.</typeparam>
        /// <param name="r">Objeto IDataRecord con los valores que se asignaran.</param>
        /// <returns>Objeto.</returns>
        protected T ToObject<T>(IDataRecord r) where T : new()
        {
            T obj = new T();

            for (int i = 0; i < r.FieldCount; i++)
            {
                var p = typeof(T).GetProperty(r.GetName(i), BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (p != null)
                {
                    if (p.PropertyType == r[i].GetType())
                        p.SetValue(obj, r[i], null);
                    else
                    {
                        Type t = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;

                        object safeValue = (r[i] == null || r[i] is DBNull) ? null : Convert.ChangeType(r[i], t);
                        p.SetValue(obj, safeValue, null);
                    }
                }
            }
            return obj;
        }

        #endregion
    }
}
