using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    internal class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string jerseyColor { get; set; }
        public int yearFounded { get; set; }
        public League league { get; set; }
    }
}
