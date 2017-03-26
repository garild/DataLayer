using System;
using System.Collections.Generic;
using DataLayer;
using DataLayer.ResultType.Interface;
using DataLayer.ResultType.Type;
using Ts3.pl.Repository.Forum.Interface;
using Ts3.pl.Models;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using Ts3.pl.SharedModel;
using DataLayer.WebCommon.Authorization;
using DataLayer.ResultType.Repository;

namespace Ts3.pl.Repository.Forum.Implementation
{
    public class ForumRepository : Datalayers,IForumRepository
    {
        private readonly string BaseConnection = ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString;


        public IDmlResult<DMLResultType> AddNewTopic(int userId, string title, string bodyContent)
        {
            return DMLData<DMLResultType>("Ts3pl_Topic_AddNewTopic", new
            {
                UserId = userId,
                Title = title,
                BodyContent = bodyContent
            });
        }

        public IDataResult<Topics> FindTopics(string search)
        {
            return QueryMultiData<Topics>("Ts3pl_Topic_FindTopic", new { Search  = search});
        }

        public IDataResult<Topics> GetTopTopics()
        {
            return QueryMultiData<Topics>("Ts3pl_Topic_GetTopTopics");
        }
        public IDmlResult<DMLResultType> BlockPost(int Id)
        {
            return DMLData<DMLResultType>("Ts3pl_Topic_BlockPost", new
            {
                Id = Id,
            });
        }

        public IDmlResult<DMLResultType> DeletePost(int Id)
        {
            return DMLData<DMLResultType>("Ts3pl_Topic_DeletePost", new
            {
                Id = Id,
            });
        }


    }
}