using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query.Filter
{
    public class BaseFilter
    {
        public int EntityCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Take { get; set; }

        public void GeneratePaging(IQueryable<object> data, int take, int currentPage)
        {
            var entityCount = data.Count();
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
            EntityCount = entityCount;
            Take = take;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
        }

        public void GeneratePaging(int count, int take, int currentPage)
        {
            var entityCount = count;
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
            EntityCount = entityCount;
            Take = take;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
        }
    }

    public class BaseFilter<TData, TParam> : BaseFilter where TParam : BaseFilterParam where TData : BaseDto
    {
        public List<TData> Data { get; set; }
        public TParam FilterParam { get; set; }
    }
}