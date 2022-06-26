using System;
using System.Collections.Generic;

namespace Domain
{
    public class PaginationResult<T>
    {
        public int Index { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}