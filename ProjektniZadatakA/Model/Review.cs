using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    internal class Review
    {
        public int id { get; set; }
        public int finalGrade { get; set; }
        public int techniqueGrade { get; set; }
        public int physicsGrade { get; set; }
        public int tacticsGrade { get; set; }
        public int mentalityGrade { get; set; }
        public string physicsDescription { get; set; }
        public string tacticsDescription { get; set; }
        public string techniqueDescription { get; set; }
        public string mentalityDescription { get; set; }
        public string conclusion { get; set; }
        public Scout scout { get; set; }
        public Player player { get; set; }

    }
}
