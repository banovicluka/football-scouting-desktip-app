using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    public class Scout
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public string licence { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool registered { get; set; }
        public City city { get; set; }

        public override string ToString()
        {
            return name + " " + surname;
        }
    }
}
