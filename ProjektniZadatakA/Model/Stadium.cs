using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    internal class Stadium
    {
        public int id { get; set; }
        public string name { get; set; }
        public int yearContruction { get; set; }
        public int capacity { get; set; }
        public City city { get; set; }
    }
}
