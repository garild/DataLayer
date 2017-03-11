using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ResultType.Type
{
    public class DMLResultType
    {
        public bool Succeed { get; set; }
        public bool Error { get; set; }
        public int Id { get; set; }
    }
}
