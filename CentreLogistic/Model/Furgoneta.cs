using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Furgoneta : Cotxe
    {
        public double CapacitatCarrega { get; set; }
        public override bool IsVehicleDeGerencia => false;

        public override string ToString()
        {
            return $"Furgoneta [IdVehicle={IdVehicle}, Matrícula={Matricula}]";
        }
    }
}
