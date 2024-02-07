using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.Model
{
    internal class Contract
    {
        public int id;
        public DateOnly signingDate;
        public DateOnly expirationDate;
        public bool rightOfTermination;
    }
}
