using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        public override string ToString()
        {
            return name + ", " + country;
        }
    }
}
