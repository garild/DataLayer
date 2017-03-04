using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DLL
{
    public class Datalayers
    {
        public DataResult<TResult> QueryMultiData<TResult>(string connectionString, string procedureName, object[] param = null) where TResult : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var data = SqlMapper.Query<TResult>(conn, procedureName, param).ToList();
                return new QueryResult<TResult>() { valueList = data };
            }

        }

        public TResult QueryData<TResult>(string connectionString, string procedureName, object[] param = null) where TResult : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.Query<TResult>(conn, procedureName, param).FirstOrDefault<TResult>();
        }

        public sealed class QueryResult<T> : DataResult<T>
        {
            public QueryResult()
            {
                _success = false;
            }
            private bool _success;

            private List<T> _valueList;

            private T _value;
            public bool success
            {
                get
                {
                    return _success;
                }
            }
            public List<T> valueList
            {
                get
                {
                    return _valueList;
                }

                set
                {
                    if (value == null || value.Count == 0)
                    {
                        _success = false;
                        _valueList = new List<T>();
                        return;
                    }
                    _success = true;
                    _valueList = value;

                }
            }
            public T value
            {
                get
                {
                    return _value;
                }

                set
                {
                    _success = true;
                    _value = value;
                }
            }
        }
        public interface DataResult<T>
        {
            bool success { get; }
            T value { get; set; }

            List<T> valueList { get; set; }
        }
    }
}
