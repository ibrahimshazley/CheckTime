using System.Collections.Generic;

namespace CheckTime.Models.Helpers
{
    public class PaginationModel<T>
    {
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
