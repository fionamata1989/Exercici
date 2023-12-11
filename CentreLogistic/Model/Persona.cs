using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public abstract class Persona
    {
        public string IdPersona { get; set; }
        public string Nom { get; set; }
        public int Edat { get; set; }
        public string Adreca { get; set; }
        public string Ciutat { get; set; }
        public string CodiPostal { get; set; }



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
                Persona other = (Persona)obj;
                resultat = IdPersona == other.IdPersona;
            }
            return resultat;
        }
        public override int GetHashCode()
        {
            return IdPersona.GetHashCode();
        }
    }
}
