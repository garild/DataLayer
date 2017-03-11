using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ResultType.Implementation
{
    public interface IDataResult<T>
    {
        bool success { get; }
        T value { get; set; }
        List<T> valueList { get; set; }
    }
}
