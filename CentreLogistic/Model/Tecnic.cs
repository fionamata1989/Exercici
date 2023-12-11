using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Tecnic : Empleat
    {
        public string Especialitat { get; set; }
        public bool Fix { get; set; }
        public string Supervisor { get; set; }

        public override bool IsDirectiu => false;
        public override string ToString()
        {
            return $"Tècnic [IdEmpleat={IdEmpleat}, Nom={Nom}]";
        }
    }
}
