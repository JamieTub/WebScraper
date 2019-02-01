using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebScraper
{
    public class EntryModel
    {
        public string GFXName { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"{GFXName}, {Price}";
        }
    }
}
