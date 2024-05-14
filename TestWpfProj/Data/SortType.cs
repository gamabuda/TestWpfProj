using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class SortType
    {
        public SortType(string sortTitle)
        {
            Id = Guid.NewGuid().ToString();
            SortTitle = sortTitle;
        }

        public string Id { get; set; }
        public string SortTitle { get; set; }
    }
}
