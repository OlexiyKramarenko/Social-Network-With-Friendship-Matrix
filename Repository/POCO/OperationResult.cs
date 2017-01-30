using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.POCO
{
    public class OperationResult
    {
        public bool Succeded { get; set; }
        public object Data { get; set; }
    }
}
