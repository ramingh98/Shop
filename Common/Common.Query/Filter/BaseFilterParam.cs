using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query.Filter
{
    public class BaseFilterParam
    {
        public int PageId { get; set; } = 1;
        public int Take { get; set; } = 10;
    }
}