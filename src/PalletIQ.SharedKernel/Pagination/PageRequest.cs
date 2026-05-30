using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Pagination
{
    public record PageRequest
    {
        public int Page { get; init; }  = 1;
        public int PageSize { get; init; } = 20;

        public string? SearchTerm { get; init; }

        public string? SortBy { get; init; }
        public bool SortDesc { get; init; } = false;

        public int Skip => (Page - 1) * PageSize;
    }
}
