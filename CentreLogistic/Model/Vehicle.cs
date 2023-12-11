using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public abstract class Vehicle
    {
        public string IdVehicle { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }

        public int Any { get; set; }
        public string Matricula { get; set; }
        public double Preu { get; set; }
        public String ConductorId { get; set; }
        public abstract bool IsVehicleDeGerencia { get; }
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
                Vehicle other = (Vehicle)obj;
                resultat = IdVehicle == other.IdVehicle;
            }
            return resultat;
        }
        public override int GetHashCode()
        {
            return IdVehicle.GetHashCode();
        }

        public override string ToString()
        {
            return $"Vehicle [IdVehicle={IdVehicle}, Matrícula={Matricula}]"; ;
        }
    }
}
