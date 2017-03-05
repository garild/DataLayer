using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace BLL.DLL
{
    public class Datalayers
    {
        public DataResult<TResult> QueryMultiData<TResult>(string connectionString, string procedureName, object param = null) where TResult :  new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var data = SqlMapper.Query<TResult>(conn, procedureName, param, commandType: CommandType.StoredProcedure).ToList();
                return new QueryResult<TResult>() { valueList = data };
            }

        }

        public TResult QueryData<TResult>(string connectionString, string procedureName, object param = null) where TResult : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
                return SqlMapper.Query<TResult>(conn, procedureName, param, commandType: CommandType.StoredProcedure).FirstOrDefault<TResult>();
        }

        public DMLResult<DMLResultType> DMLData<DMLResultType>(string connectionString, string procedureName, object param = null) where DMLResultType : class, new()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var data = SqlMapper.Query<DMLResultType>(conn, procedureName, param, commandType: CommandType.StoredProcedure).FirstOrDefault<DMLResultType>();
                return new DMLResult<DMLResultType>() { Value = data };
            }
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
                    if (value == null)
                    {
                        _success = false;
                        _value = default(T);
                        return;
                    }
                    _success = true;
                    _value = value;
                }
            }
        }

        public sealed class DMLResult<T> : IDmlResult<T>
        {
            public DMLResult()
            {
                _success = false;
            }
            private bool _success;
            private bool _error;
            private T _value;
            public bool Error
            {
                get
                {
                    return _error;
                }
            }

            public bool Succeed
            {
                get
                {
                    return _success;
                }
            }

            public T Value
            {
                get
                {
                    return _value;
                }

                set
                {
                    if (value == null)
                    {
                        _error = true;
                        _value = default(T);
                    }
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

        public interface IDmlResult<DMLResultType>
        {
            bool Succeed { get; }
            bool Error { get; }
            DMLResultType Value { get; set; }
        }

        public class DMLResultType
        {
            public bool Succeed { get; set; }
            public bool Error { get; set; }
            public int Id { get; set; }
        }
    }
}
