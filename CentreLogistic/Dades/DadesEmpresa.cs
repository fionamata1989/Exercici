using CentreLogistic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Dades
{
    public class DadesEmpresa
    {
        public List<Client> Clients { get; set; }
        //public List<Comercial> Comercials { get; set;}
        public List<Comanda> Comandes { get; set;}
        public List<Producte> Productes { get; set;}
        public List<Categoria> Categories { get; set;}
        public List<Empleat> Empleats { get; set;}
        public List<Vehicle> Vehicles { get; set;}

        public DadesEmpresa()
        {
            Clients = new List<Client>();
            //Comercials= new List<Comercial>();
            Comandes = new List<Comanda>();
            Productes = new List<Producte>();
            Categories = new List<Categoria>();
            Empleats = new List<Empleat>();
            Vehicles = new List<Vehicle>();
        }
    }
}
