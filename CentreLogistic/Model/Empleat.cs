using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public abstract class Empleat : Persona
    {
        public Empleat()
        {
            VehiclesId = new List<String>();
        }
        public string IdEmpleat { get; set; }
        public string Carrec { get; set; }
        public double Salari { get; set; }
        public DateTime DataContracte { get; set; }
        public List<String> VehiclesId { get; set; } // Llista de vehicles assignats a l'empleat
        public abstract bool IsDirectiu { get; }
        public String? Supervisor { get; } //Hi ha empleats sense supervisor

        public override string ToString()
        {
            return $"Empleat [IdEmpleat={IdEmpleat}, Nom={Nom}]";
        }
    }
}
