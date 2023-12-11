using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Directiu : Empleat
    {
        public Directiu()
        {
            SubordinatsId = new List<String>();
        }
        public string Departament { get; set; }
        public List<String> SubordinatsId { get; set; }
        public override bool IsDirectiu => true;
        public override string ToString()
        {
            return $"Directiu [idEmpleat={IdEmpleat}, Nom={Nom} ]";
        }
    }
}
