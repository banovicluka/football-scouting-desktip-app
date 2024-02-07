using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    internal class Match
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public int ticketPrice { get; set; }
        public Team host { get; set; }
        public Team guest { get; set; }
        public Stadium stadium { get; set; }

        public List<Scout> scouts { get; set; }

        

        //NEMOJ ZABORAVITI LISTU SKAUTA KOJI POSMATRAJU MEC
    }
}
