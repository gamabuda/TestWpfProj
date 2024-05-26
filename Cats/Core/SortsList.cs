using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cats.Data
{
public static class SortsList
    {
        public static List<Sort> SortList = new List<Sort>()
        {
            new Sort("По имени", l => l.OrderBy(x => x.Name).ToList()),
            new Sort("По возрасту", l => l.OrderBy(x => x.Birthday).ToList()),
        };
    }
}
