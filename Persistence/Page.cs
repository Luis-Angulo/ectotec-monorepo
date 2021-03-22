using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ectotec.Persistence {
    public class Page<T> {
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }

        public Page(IEnumerable<T> items, int pageSize)
        {
            Items = items;
            PageSize = pageSize;
        }
    }
}