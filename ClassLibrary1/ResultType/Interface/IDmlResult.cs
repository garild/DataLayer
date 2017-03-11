using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ResultType.Interface
{
    public interface IDmlResult<DMLResultType>
    {
        bool Succeed { get; }
        bool Error { get; }
        DMLResultType Value { get; set; }
    }
}
