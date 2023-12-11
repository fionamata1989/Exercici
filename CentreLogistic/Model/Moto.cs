using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Moto : Vehicle
    {
        public string Tipus { get; set; }
        public int Cilindrada { get; set; }
        public int CapacitatMaleta { get; set; } // Capacitat de la maleta de la moto
        public override bool IsVehicleDeGerencia => false;
        public override string ToString()
        {
            return $"Moto [IdVehicle={IdVehicle}, Matrícula={Matricula}";
        }
    }
}
