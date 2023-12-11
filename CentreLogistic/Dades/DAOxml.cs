using CentreLogistic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CentreLogistic.Dades
{
    public class DAOxml : IDadesCentreLogistic
    {
        const String CATEGORIES = "Categories";
        const String PRODUCTES = "Productes";
        //const String NOM_FITXER_PERSONES = "Persones.csv";
        const String DIRECTIUS = "Directius";
        const String TECNICS = "Tecnics";
        const String COMERCIALS = "Comercials";
        const String CLIENTS = "Clients";
        const String COTXES = "Cotxes";
        const String FURGONETES = "Furgonetes";
        const String MOTOS = "Motos";
        const String EMPRESA = "Empresa";
        const String COMANDES = "Comandes";

        public string Carpeta { get; private set; }

        public DAOxml(): this("Dades"){ }
        public DAOxml(string carpeta)
        {
            Carpeta = carpeta;
        }

        //Important: per poder serialitzar correctament, cal convertir el IEnumerable en List. 
        public void DesaCategories(IEnumerable<Categoria> categories)
        {
            var llista = categories.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Categoria>));
            using (TextWriter fitxer = new StreamWriter(Carpeta + "\\" + CATEGORIES + ".xml"))
            {
                serialitzador.Serialize(fitxer, llista);
            }
        }


        public void DesaClients(IEnumerable<Client> clients)
        {
            var llista = clients.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Client>));
            using (TextWriter fitxer = new StreamWriter(Carpeta + "\\" + CLIENTS + ".xml"))
            {
                serialitzador.Serialize(fitxer, llista);
            }
        }

        public void DesaComercials(IEnumerable<Comercial> comercials)
        {
            var llista = comercials.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Comercial>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COMERCIALS + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public void DesaCotxes(IEnumerable<Cotxe> cotxes)
        {
            var llista = cotxes.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Cotxe>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COTXES + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public void DesaDirectius(IEnumerable<Directiu> directius)
        {
            var llista = directius.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Directiu>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + DIRECTIUS + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public void DesaFurgonetes(IEnumerable<Furgoneta> furgonetes)
        {
            var llista = furgonetes.ToList();  
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Furgoneta>));
            using(TextWriter tw = new StreamWriter(Carpeta + "\\" + FURGONETES + ".xml"))
            {
                serialitzador.Serialize(tw, llista);  
            }
        }

        public void DesaMotos(IEnumerable<Moto> motos)
        {
            var llista = motos.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Moto>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + MOTOS + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public void DesaProductes(IEnumerable<Producte> productes)
        {
            var llista = productes.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Producte>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + PRODUCTES + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public void DesaTecnics(IEnumerable<Tecnic> tecnics)
        {
            var llista = tecnics.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Tecnic>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + TECNICS + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }
        public void DesaEmpresa(Empresa empresa)
        {
            /*DadesEmpresa dadesEmpresa = new DadesEmpresa();
            

            XmlSerializer serialitzador = new XmlSerializer(typeof(Empresa));
            using (TextReader tw = new StreamWriter(Carpeta + "\\" + EMPRESA + ".xml"))
            {
                serialitzador.Serialize(tw, empresa);
            }*/

        }

        //No em permet serialització per implementar IDictionary
        public void DesaComandes(IEnumerable<Comanda> comandes)
        {
            var llista = comandes.ToList();
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Comanda>));
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COMANDES + ".xml"))
            {
                serialitzador.Serialize(tw, llista);
            }
        }

        public IEnumerable<Comanda> ObtenComandes()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(Comanda));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COMANDES + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Comanda>();
            }
            return obj as IEnumerable<Comanda> ?? new List<Comanda>();
        }
        
        public IEnumerable<Categoria> ObtenCategories()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Categoria>));
            using (TextReader fitxer = new StreamReader(Carpeta + "\\" + CATEGORIES + ".xml"))
            {
                obj = serialitzador.Deserialize(fitxer) ?? new List<Categoria>();
                
            }
            return obj as IEnumerable<Categoria>?? new List<Categoria>();
        }

        public IEnumerable<Cotxe> ObtenCotxes()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Cotxe>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COTXES + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Cotxe>();
            }
            return obj as IEnumerable<Cotxe> ?? new List<Cotxe>(); ;
        }

        public IEnumerable<Furgoneta> ObtenFurgonetes()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Furgoneta>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + FURGONETES + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Furgoneta>();
            }
            return obj as IEnumerable<Furgoneta> ?? new List<Furgoneta>();
        }

        public IEnumerable<Moto> ObtenMotos()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Moto>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + MOTOS + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Moto>();
            }
            return obj as IEnumerable<Moto> ?? new List<Moto>();
        }

        public IEnumerable<Producte> ObtenProductes()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Producte>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + PRODUCTES + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Producte>();
            }
            return obj as IEnumerable<Producte> ?? new List<Producte>();
        }



        public IEnumerable<Client> ObtenClients()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Client>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + CLIENTS + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Client>();
            }
            return obj as IEnumerable<Client> ?? new List<Client>();
        }

        public IEnumerable<Comercial> ObtenComercials()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Comercial>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COMERCIALS + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Comercial>();
            }
            return obj as IEnumerable<Comercial> ?? new List<Comercial>();
        }

        public IEnumerable<Directiu> ObtenDirectius()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Directiu>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + DIRECTIUS + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Directiu>();
            }
            return obj as IEnumerable<Directiu> ?? new List<Directiu>();
        }

        public IEnumerable<Tecnic> ObtenTecnics()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Tecnic>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + TECNICS + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Tecnic>();
            }
            return obj as IEnumerable<Tecnic> ?? new List<Tecnic>();
        }

        public IEnumerable<Empresa> ObtenEmpresa()
        {
            object obj;
            XmlSerializer serialitzador = new XmlSerializer(typeof(List<Empresa>));
            using (TextReader tr = new StreamReader(Carpeta + "\\" + EMPRESA + ".xml"))
            {
                obj = serialitzador.Deserialize(tr) ?? new List<Empresa>();
            }
            return obj as IEnumerable<Empresa> ?? new List<Empresa>();
        }
    }
}
