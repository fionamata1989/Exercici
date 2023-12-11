using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Cotxe : Vehicle
    {
        public int NPlaces { get; set; }
        public int Portes { get; set; }
        public bool Automatic { get; set; }
        public double Consum { get; set; }
        public bool Diesel { get; set; }
        public int Cavalls { get; set; }

        public override bool IsVehicleDeGerencia => true;

        public override string ToString()
        {
            return $"Cotxe [IdVehicle={IdVehicle}, Matrícula={Matricula}";
        }
    }
}
