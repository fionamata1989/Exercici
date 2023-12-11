using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Client : Persona
    {
        public Client()
        {
            ComandesId = new List<String>();
        }
        public string IdClient { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public List<String> ComandesId { get; set; }

        public override string ToString()
        {
            return $"Client [idEmpleat={IdClient}, Nom={Nom}]";
        }
    }
}
