using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Producte
    {
        public string IdProducte { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public double Preu { get; set; }
        public int Stock { get; set; }
        public String CategoriaId { get; set; }

        public override bool Equals(object obj)
        {
            bool resultat = false;
            if (obj == null)
                resultat = this == null;
            else if (GetType() != obj.GetType())
            {
                resultat = false;
            }
            else
            {
                Producte other = (Producte)obj;
                resultat = IdProducte == other.IdProducte;
            }
            return resultat;
        }

        public override int GetHashCode()
        {
            return IdProducte.GetHashCode();
        }
        public override string ToString()
        {
            return $"Producte [idProducte={IdProducte}, Nom={Nom}]";
        }
    }
}
