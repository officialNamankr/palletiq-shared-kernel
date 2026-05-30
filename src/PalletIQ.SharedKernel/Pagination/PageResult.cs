using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Pagination
{
    public class PageResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = [];

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;
        public static PageResult<T> Create(List<T> items, int totalCount, int page, int pageSize)
        {
            return new PageResult<T>
            {
                Items = items,
                TotalCount = totalCount,      
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
