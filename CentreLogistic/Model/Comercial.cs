using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Comercial : Empleat
    {
        public Comercial()
        {
            ComandesId = new List<String>();
        }
        public string Seccio { get; set; }
        public bool Fix { get; set; }
        public float PercentatgeDeComissio { get; set; }
        public List<String> ComandesId { get; set; }

        public override bool IsDirectiu => false;
        public override string ToString()
        {
            return $"Comercial [IdEmpleat={IdEmpleat}, Nom={Nom}]";
        }
    }
}
