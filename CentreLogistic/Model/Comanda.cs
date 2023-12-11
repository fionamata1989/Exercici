using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Comanda
    {
        //Autoincrement per IDComanda. 
        private static int ultimaComanda = 0;
        public Comanda()
        {
            ultimaComanda++;
            IDComanda= ultimaComanda;
        }

        public Comanda (string clientId, string empleatId, DateTime dataComanda, DateTime dataEnviament, string estat, Dictionary<string, int> productes)
        {
            ClientId = clientId;
            EmpleatId = empleatId;
            DataComanda = dataComanda;
            DataEnviament = dataEnviament;
            Estat = estat;
            Productes = productes;
        }

        public int IDComanda { get; set; }
        public String ClientId { get; set; }
        public String EmpleatId { get; set; }
        public DateTime DataComanda { get; set; }
        public DateTime DataEnviament { get; set; }
        public string Estat { get; set; }
        public Dictionary<string, int> Productes { get; set; }
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
                Comanda other = (Comanda)obj;
                resultat = IDComanda == other.IDComanda;
            }
            return resultat;
        }

        public override int GetHashCode()
        {
            return IDComanda.GetHashCode();
        }
        public override string ToString()
        {
            int i = 1;
            StringBuilder comanda = new StringBuilder();
            comanda.Append($"Comanda\n [idComanda={IDComanda}] ---------- {ClientId} ---------- Data de la comanda: {DataComanda}\n");
            comanda.Append($"A càrrec de {EmpleatId}\n");
            comanda.Append($"Estat: {Estat}\n");
            comanda.Append($"Productes seleccionats:\n");

            foreach (var item in Productes)
            {
                string liniaProducte = "Producte " + i + item.ToString();
                comanda.AppendLine( liniaProducte );
                i++;
            }

            return comanda.ToString();
        }

        
    }
}
