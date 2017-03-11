using Dapper;
using DataLayer.ResultType.Implementation;
using DataLayer.ResultType.Repository;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class Datalayers

    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString;

        public IDataResult<TResult> QueryMultiData<TResult>(string procedureName, object param = null) where TResult :  new()
        {
            using (var conn = new SqlConnection(BaseConnection))
            {
                var data = SqlMapper.Query<TResult>(conn, procedureName, param, commandType: CommandType.StoredProcedure).ToList();
                return new QueryResult<TResult>() { valueList = data };
            }
        }

        public TResult QueryData<TResult>(string procedureName, object param = null) where TResult : class, new()
        {
            using (var conn = new SqlConnection(BaseConnection))
                return SqlMapper.Query<TResult>(conn, procedureName, param, commandType: CommandType.StoredProcedure).FirstOrDefault<TResult>();
        }

        public DMLResult<DMLResultType> DMLData<DMLResultType>(string procedureName, object param = null) where DMLResultType : class, new()
        {
            using (var conn = new SqlConnection(BaseConnection))
            {
                var data = SqlMapper.Query<DMLResultType>(conn, procedureName, param, commandType: CommandType.StoredProcedure).FirstOrDefault<DMLResultType>();
                return new DMLResult<DMLResultType>() { Value = data };
            }
        }

       
    }
}
