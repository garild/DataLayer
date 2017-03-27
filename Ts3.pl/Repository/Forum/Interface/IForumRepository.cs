using DataLayer.ResultType.Interface;
using DataLayer.ResultType.Repository;
using DataLayer.ResultType.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ts3.pl.Models;
using Ts3.pl.SharedModel;

namespace Ts3.pl.Repository.Forum.Interface
{
    public interface IForumRepository
    {
        IDmlResult<DMLResultType> AddNewTopic(int userId, string title, string bodyContent);
        IDataResult<Post> GetTopPost();
        IDataResult<Post> FindTopics(string search);
        IDmlResult<DMLResultType> DeletePost(int Id);
        IDmlResult<DMLResultType> BlockPost(int Id);
        IDataResult<Topics> GetMainTopic();
        IDataResult<Post> GetPostListForTopic(int Id);
    }
}
