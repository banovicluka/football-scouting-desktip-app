using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektniZadatakA.Model
{
    internal class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int priceInThousandsOfEuros { get; set; }
        public int age { get; set; }
        public int height { get; set; }
        public string nationality { get; set; }
        public int jerseyNumber { get; set; }
        public string foot { get; set; }
        public Team team { get; set; }
        public Agency agency { get; set; }

    }
}
