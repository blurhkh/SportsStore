using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class PagingInfo
    {
        public long TotalItems { get; set; }
        public int MaxSize { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => 
            (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}
