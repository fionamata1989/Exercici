using CentreLogistic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CentreLogistic.Dades
{
    public class DAOJson : IDadesCentreLogistic
    {
        const String CATEGORIES = "Categories";
        const String PRODUCTES = "Productes";
        const String DIRECTIUS = "Directius";
        const String TECNICS = "Tecnics";
        const String COMERCIALS = "Comercials";
        const String CLIENTS = "Clients";
        const String COTXES = "Cotxes";
        const String FURGONETES = "Furgonetes";
        const String MOTOS = "Motos";
        const String EMPRESA = "EMPRESA";
        const String COMANDES = "Comandes";
        const String EMPLEATS = "Empleats";
        const String VEHICLES = "Vehicles";

        public string Carpeta { get; private set; }

        public DAOJson(): this("Dades") { }

        public DAOJson(string carpeta) 
        {
            if (ComprovarSiElNomEsCorrecte(carpeta))
            {
                Carpeta = carpeta;
            }
            else carpeta = "Dades";
        }

        private bool ComprovarSiElNomEsCorrecte(string carpeta)
        {
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            return true;
        }

        public void DesaCategories(IEnumerable<Categoria> categories)
        {
            string resultat;
            //Agafem nom de carpeta, nom del fitxer + .json. 
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + CATEGORIES + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    categories,
                    typeof(IEnumerable<Categoria>));
                tw.Write(resultat);
            }
        }

        public void DesaClients(IEnumerable<Client> clients)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + CLIENTS + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    clients,
                    typeof(IEnumerable<Client>));
                tw.Write(resultat);
            }
        }

        public void DesaComercials(IEnumerable<Comercial> comercials)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COMERCIALS + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    comercials,
                    typeof(IEnumerable<Comercial>));
                tw.Write(resultat);
            }
        }

        public void DesaCotxes(IEnumerable<Cotxe> cotxes)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COTXES + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    cotxes,
                    typeof(IEnumerable<Cotxe>));
                tw.Write(resultat);
            }
        }

        public void DesaDirectius(IEnumerable<Directiu> directius)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + DIRECTIUS + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    directius,
                    typeof(IEnumerable<Directiu>));
                tw.Write(resultat);
            }
        }

        public void DesaFurgonetes(IEnumerable<Furgoneta> furgonetes)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + FURGONETES + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    furgonetes,
                    typeof(IEnumerable<Furgoneta>));
                tw.Write(resultat);
            }
        }

        public void DesaMotos(IEnumerable<Moto> motos)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + MOTOS + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    motos,
                    typeof(IEnumerable<Moto>));
                tw.Write(resultat);
            }
        }

        public void DesaProductes(IEnumerable<Producte> productes)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + PRODUCTES + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    productes,
                    typeof(IEnumerable<Producte>));
                tw.Write(resultat);
            }
        }

        public void DesaTecnics(IEnumerable<Tecnic> tecnics)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + TECNICS + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    tecnics,
                    typeof(IEnumerable<Tecnic>));
                tw.Write(resultat);
            }
        }

        public void DesaEmpresa(Empresa empresa)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + EMPRESA + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    empresa,
                    typeof(IEnumerable<Empresa>));
                tw.Write(resultat);
            }
        }

        public void DesaComandes(IEnumerable<Comanda> comandes)
        {
            string resultat;
            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + COMANDES + ".json"))
            {
                resultat = JsonSerializer.Serialize(
                    comandes, typeof(IEnumerable<Comanda>));
                tw.Write(resultat);
            }
        }

        public IEnumerable<Comanda> ObtenComandes()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COMANDES + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(List<Comanda>)) ?? new List<Comanda>();
            }
            return resultat as IEnumerable<Comanda> ?? new List<Comanda>();
        }

        public IEnumerable<Categoria> ObtenCategories()
        {
            object resultat;
            using (TextReader fitxer = new StreamReader(Carpeta + "\\" + CATEGORIES + ".json"))
            {
                string contingut = fitxer.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Categoria>)) ?? new List<Categoria>();
            }
            return resultat as IEnumerable<Categoria> ?? new List<Categoria>();
        }

        public IEnumerable<Producte> ObtenProductes()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + PRODUCTES + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Producte>)) ?? new List<Producte>();
            }
            return resultat as IEnumerable<Producte> ?? new List<Producte>();
        }

        public IEnumerable<Cotxe> ObtenCotxes()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COTXES + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Cotxe>)) ?? new List<Cotxe>();
            }
            return resultat as IEnumerable<Cotxe> ?? new List<Cotxe>();
        }

        public IEnumerable<Furgoneta> ObtenFurgonetes()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + FURGONETES + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Furgoneta>)) ?? new List<Furgoneta>();
            }
            return resultat as IEnumerable<Furgoneta> ?? new List<Furgoneta>();
        }

        public IEnumerable<Moto> ObtenMotos()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + MOTOS + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Moto>)) ?? new List<Moto>();
            }
            return resultat as IEnumerable<Moto> ?? new List<Moto>();
        }

        public IEnumerable<Client> ObtenClients()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + CLIENTS + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Client>)) ?? new List<Client>();
            }
            return resultat as IEnumerable<Client> ?? new List<Client>();
        }

        public IEnumerable<Comercial> ObtenComercials()
        {
            object resultat = null;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + COMERCIALS + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Comercial>)) ?? new List<Comercial>();
            }
            return resultat as IEnumerable<Comercial> ?? new List<Comercial>();
        }

        public IEnumerable<Directiu> ObtenDirectius()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + DIRECTIUS + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Directiu>)) ?? new List<Directiu>();
            }
            return resultat as IEnumerable<Directiu> ?? new List<Directiu>();
        }

        public IEnumerable<Tecnic> ObtenTecnics()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + TECNICS + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Tecnic>)) ?? new List<Tecnic>();
            }
            return resultat as IEnumerable<Tecnic> ?? new List<Tecnic>();
        }

        public IEnumerable<Empresa> ObtenEmpresa()
        {
            object resultat;
            using (TextReader tr = new StreamReader(Carpeta + "\\" + EMPRESA + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize(contingut, typeof(IEnumerable<Empresa>)) ?? new List<Empresa>();
            }
            return resultat as IEnumerable<Empresa> ?? new List<Empresa>();
        }



        public IEnumerable<Vehicle> ObtenVehicle()
        {
            List<Vehicle> resultat = new List<Vehicle>();
            List<Cotxe> cotxes = new List<Cotxe>();
            List<Furgoneta> furgonetes = new List<Furgoneta>();
            List<Moto> motos = new List<Moto>();

            using (TextReader tr = new StreamReader(Carpeta + "\\" + VEHICLES + ".json"))
            {
                string contingut = tr.ReadToEnd();
                resultat = JsonSerializer.Deserialize<List<Vehicle>>(contingut);

                foreach (Vehicle vehicle in resultat)
                {
                    if (vehicle is Cotxe)
                        cotxes.Add((Cotxe)vehicle);
                    else if (vehicle is Furgoneta)
                        furgonetes.Add((Furgoneta)vehicle);
                    else
                        motos.Add((Moto)vehicle);
                }

            }
            resultat.AddRange(cotxes);
            resultat.AddRange(furgonetes);
            resultat.AddRange(motos);

            return resultat;
        }

    }
}
