using CentreLogistic.Dades;
using CentreLogistic.Model;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

internal class Program
{ 
    Random random = new Random();
    /*
* La idea és fer, en algun moment, una càrrega de dades. Aquesta càrrega s'hauria de fer de manera que hi hagi diferents origens de dades. 
* És possible, però, que l'origen sigui molt diferent: podria ser un fitxer, sigui .csv, .json o .xml; podria ser d'una base de dades Oracle, SQLServer, SQLite; podria ser REST... Per anar bé, per no haver de refer el programa, aldrà configurar l'orgen de dades. 
* Només amb aquesta configuració, tot funcionarà sempre i quan tinguem els mètodes fets correctament. 
* 
* No es posa un origen concret; se li dona forma de interfície. Pot passar qualsevol cosa, sempre i quan disposi dels mètodes que hem fet (ObtenProductes i DesaProductes)
* 
*/
    private static void Main(string[] args)
    {
        #region proves amb montilivi
        //Empresa montilivi = new Empresa()
        //{
        //    NIF = "B7001735I",
        //    NomFiscal = "Institut Montilivi",
        //    NomComercial = "Monty",
        //    Email = "b7001735@centres.xtec.cat",
        //    Telefon = "972209458",
        //    Adreca = "Avda. Montilivi 125",
        //    Clients = new(),
        //    Categories = new(),
        //    Empleats = new(),
        //    Productes = new(),
        //    Vehicles = new(),
        //    Comercials = new(),
        //    Comandes = new()
        //    //Empreses = new()
        //};

        ////Main amn menu, per poder guardar, desar i borrar. 
        ////Obtenció de dades fake:
        //IDadesCentreLogistic dadesFake = new DadesFake();
        //IDadesCentreLogistic dadesJson = new DAOJson();
        ////IDadesCentreLogistic dadesXML = new DAOxml();

        //montilivi.BorraDades();
        //montilivi.CarregaDades2(dadesJson);

        //montilivi.GeneraComandes(300);
        //foreach (Comanda comanda in montilivi.Comandes.ToList())
        //{
        //    montilivi.Comandes.Add(comanda);
        //}

        ////montilivi.CarregaDades2(dadesJson);
        //montilivi.DesaDades2(dadesJson);

        ////Quants vehicles hi ha:
        //Console.WriteLine("El num. de vehicles és: " + montilivi.Vehicles.Count);

        ////Passem IEnumerable de qualsevol cosa i la treu per consola.
        //void Escriu<T>(IEnumerable<T> llista)
        //{
        //    foreach (T elem in llista)
        //    {
        //        Console.WriteLine(elem);
        //    }
        //}

        //int nVehicles = montilivi.Vehicles.Count(vehicle => vehicle is Moto);
        //Console.WriteLine(nVehicles);

        //Escriu(montilivi.Vehicles.FindAll(vehicle => vehicle.Any > 2021));
        ////Tenim el .cast, que permet, per exemple, convertir tots aquells objectes que son moto en moto. 
        ////.average per poder calcular mitjanes...
        ////.Except...

        ////LINQ:  
        ////Permet comandes tipus SQL, permetent joins i tot. 
        //var productes = from producte in montilivi.Productes
        //                where producte.CategoriaId == ""
        //                select new //Crea una nova classe, que té descripció i preu, amb els seus respectius ToString();
        //                {
        //                    Descripcio = producte.Descripcio,
        //                    Preu = producte.Preu,
        //                };

        //Escriu(productes);

        ////Només funciona si utilitzem using System.Linq. Permet complicacions completes:
        //Escriu(montilivi.ProductesPerIDCategoria["1"]);
        #endregion

        #region exercici

        #region carrega de dades:
        //Borrar dades..
        //Carregar un sol cop json. Ara mateix les estic llegint multiples vegades. Cal traçar.
        //Desar.
        //Fer consultes.
        Empresa empresaNova = new Empresa()
        {
            NIF = "B70016581",
            NomFiscal = "EmpresaNova",
            NomComercial = "Monty",
            Email = "b7001735@centres.xtec.cat",
            Telefon = "972209458",
            Adreca = "Avda. Montilivi 125",
            Clients = new(),
            Categories = new(),
            Empleats = new(),
            Productes = new(),
            Vehicles = new(),
            Comercials = new(),
            Comandes = new()
        };

        //empresaNova.BorraDades();
        IDadesCentreLogistic dadesJsonEmpresaNova = new DAOJson();
        DadesFake df = new DadesFake();
        dadesJsonEmpresaNova = df;
        empresaNova.CarregaDades2(dadesJsonEmpresaNova);
        empresaNova.DesaDades2(dadesJsonEmpresaNova);

        //empresaNova.GeneraComandes(300);
        foreach (Comanda comanda in empresaNova.Comandes.ToList())
        {
            empresaNova.Comandes.Add(comanda);
        }
        #endregion

        #region menu
        int opcio;

        do
        {
            Console.Clear();
            Opcions();
            opcio = Convert.ToInt32(Console.ReadLine());

            switch (opcio)
            {
                case 1:
                    Console.WriteLine("Categories sense productes: ");
                    List<Categoria> llista = CategoriesSenseProductes(empresaNova);
                    if (llista != null)
                        Escriu(llista);
                    else
                        Console.WriteLine("No hi ha categories sense productes.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 2:
                    Console.WriteLine("Productes de la categoria seleccionada. \n Entra un iDCategoria: ");
                    string idCategoria = Console.ReadLine();
                    List<Producte> productesPerCategoria = ProductesPerCategoria(empresaNova, idCategoria);
                    if (productesPerCategoria != null)
                        Escriu(productesPerCategoria);
                    else
                        Console.WriteLine("No hi ha productes en la categoria seleccionada. ");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 3:
                    Console.WriteLine("Productes amb categoria que contingui string entrat. \n Entra un text o paraula que vulguis buscar: ");
                    string text = Console.ReadLine();
                    var productesDCategoria = ProductesDCategoria(empresaNova, text);
                    if (productesDCategoria != null)
                        Escriu(productesDCategoria);
                    else
                        Console.WriteLine("No s'ha trobat el text/paraula buscada.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 4:
                    Console.WriteLine("Especialitats dels tècnics contractats: ");
                    var especialitatsDeTecnics = EspecialitatsDeTecnics(empresaNova);
                    if (especialitatsDeTecnics != null)
                        Escriu(especialitatsDeTecnics);
                    else
                        Console.WriteLine("No s'ha trobat especialitats");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 5:
                    Console.WriteLine("Nom i salari del empleats fixos: ");
                    var nomISouEmpleatsFixos = NomISouEmpleatsFixos(empresaNova);
                    if (nomISouEmpleatsFixos != null)
                        Escriu(nomISouEmpleatsFixos);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 6:
                    Console.WriteLine("Empleats sense supervisor: ");
                    var empleatsSenseSupervisor = EmpleatsSenseSupervisor(empresaNova);
                    if (empleatsSenseSupervisor != null)
                        Escriu(empleatsSenseSupervisor);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 7:
                    Console.WriteLine("Comercials ordenats per data de contracte: ");
                    List<Empleat> llistaComercialsOrdenats = ComercialsOrdenats(empresaNova);
                    if (llistaComercialsOrdenats != null)
                        Escriu(llistaComercialsOrdenats);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 8:
                    Console.WriteLine("Cotxes de subordinats d'un supervisor entrat: \n Entra l'id del supervisor: ");
                    string idSupervisor = Console.ReadLine();
                    List<Vehicle> llistaVehicles = VehiclesDeSubordinatsDeSupervisor(empresaNova, idSupervisor);
                    if (llistaVehicles != null)
                        Escriu(llistaVehicles);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 9:
                    Console.WriteLine("Capacitat de càrrega de furgonetes. \n Entra una càrrega: ");
                    double carrega = Convert.ToDouble(Console.ReadLine());
                    List<Furgoneta> furgonetes = LlistarFurgonetes(empresaNova, carrega);
                    if (furgonetes != null)
                        Escriu(furgonetes);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 10:
                    Console.WriteLine("Comandes de clients. \n Entre l'ID del client:");
                    string idClient = Console.ReadLine();
                    List<Comanda> comandes = LlistarComandes(empresaNova, idClient);
                    if (comandes != null)
                        Escriu(comandes);
                    else
                        Console.WriteLine("Llista buida.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 11:
                    Console.WriteLine("Facturació. Veure beneficis de l'empresa. ");
                    double beneficis = Benefici(empresaNova);
                    if (beneficis < 0)
                        Console.WriteLine("No hi ha benefici.");
                    else 
                        Console.WriteLine("Beneficis de l'empresa: " + beneficis);
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 12:
                    Console.WriteLine("Facturació. Veure beneficis en període de temps.\n Entra la data en format 'aaaa, mm, dd':");
                    Console.WriteLine("Data inici: ");
                    DateTime inici = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Data final: ");
                    DateTime final = Convert.ToDateTime(Console.ReadLine());
                    beneficis = BeneficiRang(empresaNova, inici, final);
                    if (beneficis < 0)
                        Console.WriteLine("No hi ha benefici.");
                    else
                        Console.WriteLine("Beneficis de l'empresa: " + beneficis);
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;
                
                case 13:
                    Console.WriteLine("Facturació. Veure comercial que més ha facturat.");
                    Comercial comercial = null; //MillorComercialEnFacturacio(empresaNova);
                    if (comercial != null)
                        Console.WriteLine(comercial.ToString());
                    else
                        Console.WriteLine("No està implementat correctament.");
                    break;

                case 14:
                    Console.WriteLine("Facturació. Veure comercials que han facturat mínim l'import entrat.\n Entra un import:");
                    double import = Convert.ToDouble(Console.ReadLine());
                    List<Comercial> comercials = null; //ComercialsQueHanFacturatMesQue(empresaNova, import);
                    if (comercials != null)
                        Escriu(comercials);
                    else
                        Console.WriteLine("No està implementat correctament.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break; 

                case 15:
                    Console.WriteLine("Facturació. Productes més venuts. \n Entra quants productes vols veure: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    List<string> productesMesVenuts = NProductesMesVenuts(empresaNova, n);
                    if (productesMesVenuts != null)
                        Escriu(productesMesVenuts);
                    else Console.WriteLine("No s'han trobat productes.");
                    MissatgeSeguentPantalla("Prem una tecla per tornar al menú.");
                    break;

                case 0:
                    Console.WriteLine("Opció no trobada.");
                    break; 
            }

        } while (opcio != 0);

        static void Opcions()
        {
            
            Console.WriteLine("Benvingut/da al menú d'empresa.\n" +
                "Tria una opció:\n" +
                "1. Categories sense productes.\n" +
                "2. Productes de la categoria seleccionada.\n" +
                "3. Productes que continguin string entrat.\n" +
                "4. Especialitats dels tècnics contractats.\n" +
                "5. Nom i salari del empleats fixos.\n" +
                "6. Empleats sense supervisor.\n" +
                "7. Comercials ordenats per data de contracte.\n" +
                "8. Cotxes de subordinats d'un supervisor entrat.\n" +
                "9. Donada una capacitat de càrrega, els vehicles que com a mínim tinguin aquesta capacitat de càrrega.\n" +
                "10. Comandes de clients.\n" +
                "11. Facturació. Veure beneficis.\n" +
                "12. Facturació. Veure beneficis en període de temps.\n" +
                "13. Facturació. Veure comercial que més ha facturat.\n" +
                "14. Facturació. Veure comercials per rang de facturació.\n" +
                "15. Facturació. Productes més venuts.\n" +
                "------------------------------------------------------------------");
        }

         static void MissatgeSeguentPantalla(String elMissatge)
        {
            Console.WriteLine(elMissatge);
            Console.ReadKey();
        }

        #endregion

        #region funcions de tractament de dades:
        //Passem IEnumerable de qualsevol cosa i la treu per consola.
        void Escriu<T>(IEnumerable<T> llista)
        {
            foreach (T elem in llista)
            {
                Console.WriteLine(elem);
            }
        }

        //Categories sense productes
        static List<Categoria> CategoriesSenseProductes(Empresa empresaNova)
        {
            var categoriesSenseProductes = from categoria in empresaNova.Categories
                                           where categoria.ProductesId is null
                                           select categoria;

            Console.WriteLine(empresaNova.Categories.Count());
            return categoriesSenseProductes.ToList();
        }
        
        //Donat un id Categoria, tots els productes d'aquesta categoria
        static List<Producte> ProductesPerCategoria(Empresa empresaNova, string idCategoria)
        {
            var productesDeCategoria = from producte in empresaNova.Productes
                                       where producte.CategoriaId == idCategoria
                                       select producte;

            return productesDeCategoria.ToList(); //Passem Escriu() al switch case amb la llista retornada.
        }

        //Donat un string, tots els productes on la categoria contingui aquest string
        static List<Producte> ProductesDCategoria(Empresa empresaNova, string text)
        {
            var productesDunaCategoria = empresaNova.Productes
        .Where(p => p.Descripcio.Contains(text))
        .ToList();

            //Alternatica var consulta = productes.Where(p=> p.Descripcio.Contains(textCategoria));
            return productesDunaCategoria.ToList();
        }

        static List<string> EspecialitatsDeTecnics(Empresa empresaNova)
        {

            //Especialitats dels tècnics contractats
            List<Tecnic> tecnicsFixos = empresaNova.Empleats.OfType<Tecnic>().ToList();
            List<string> especialitatsTecnics = tecnicsFixos.Select(t => t.Especialitat).ToList();
            return especialitatsTecnics;
        }

        //Nom i salari del empleats fixos:
        static Dictionary<string, double> NomISouEmpleatsFixos(Empresa empresaNova)
        {
            //Aïllem tecnics i comercials
            var empleatsFixos = empresaNova.Empleats.Where(e => e is Tecnic || e is Comercial);

            //Fem un diccionari on afegim nom i sou dels empleats fixos.
            Dictionary<string, double> nomISou = new Dictionary<string, double>();

            //Iterem a través dels empleats fixos, ja que poden haver-hi empleats amb el mateix nom:
            foreach (Empleat e in empleatsFixos)
            {
                string nomId = $"{e.IdEmpleat} + {e.Nom}: ";

                //Si existeix, afegim el salari
                if (nomISou.ContainsKey(nomId))
                {
                    nomISou[nomId] += e.Salari;
                }
                //si no existeix, afegim nomId i salari.
                else
                {
                    nomISou.Add(nomId, e.Salari);
                }
            }
            return nomISou;
        }

        //Empleats sense supervisor
        static List<Empleat> EmpleatsSenseSupervisor(Empresa empresaNova)
        {
            var empleatsSenseSupervisor = from empleats in empresaNova.Empleats
                                          where empleats.Supervisor == null
                                          select empleats;
            return empleatsSenseSupervisor.ToList() ;

        }

        //Comercials ordenats per data de contracte
        static List<Empleat> ComercialsOrdenats(Empresa empresaNova)
        {
            var comercialsOrdenats = empresaNova.Empleats.Where(e => e is Comercial)
                .OrderBy(e => e.DataContracte.ToString("yyyy/MM/dd"));

            return comercialsOrdenats.ToList();

        }

        //Donat un idSupervisor, els cotxes dels seus subordinat
        static List<Vehicle> VehiclesDeSubordinatsDeSupervisor(Empresa empresaNova, string idSupervisor)
        {
            //Primer: busquem supervisor entre els empleats:
            Empleat empleat = empresaNova.Empleats.Single(e => e.IdEmpleat == idSupervisor);
           
            List<Vehicle> vehiclesDeSubordiants = new List<Vehicle>();
            if (empleat != null)
            {
                //Busquem empleats subordinats del supervisor. 
                var llistaEmpleats = empresaNova.Empleats.Where(e => e.Supervisor == empleat.IdEmpleat);

                //Si no té subordinats:
                if (llistaEmpleats == null)
                    throw new Exception("El supervisor no té empleats.");

                //Si té subrodinats, busquem els seus cotxes;
                else
                {
                    foreach (Empleat e in llistaEmpleats)
                    {
                        List<string> idVehicles = e.VehiclesId;

                        foreach (string idVehicle in idVehicles)
                        {
                            Vehicle vehicle = empresaNova.Vehicles.FirstOrDefault(v => v.IdVehicle == idVehicle);
                            if (vehicle != null)
                            {
                                vehiclesDeSubordiants.Add(vehicle);
                            }
                        }
                    }
                }
            }
            return vehiclesDeSubordiants; //Caldrà tractar la llista si es torna buida.
        }
        
        //Donada una capacitat de càrrega, els vehicles que com a mínim tinguin aquesta capacitat de càrrega
                //Agafem furgonetes:
        static List<Furgoneta> LlistarFurgonetes(Empresa empresaNova, double carrega)
        {
            double capacitatCarrega = 400;

            //Com mirem en la llista de vehicles, l'hem de convertit a List<Furgoneta>:
            List<Furgoneta> furgonetaLista = (List<Furgoneta>)empresaNova.Vehicles.Where(v => v is Furgoneta && ((Furgoneta)v).CapacitatCarrega >= capacitatCarrega);

            return furgonetaLista;
        }

        //Donat un idClient, totes les seves comandes
        static List<Comanda> LlistarComandes(Empresa empresaNova, string idClient)
        {
            Client client = empresaNova.Clients.FirstOrDefault(c => c.IdClient == idClient);
            List<Comanda> llistaComandes = null;
            
            if (client != null)
            {
                llistaComandes = empresaNova.Comandes.Where(comanda => comanda.ClientId == idClient).ToList();
            }
            return llistaComandes;
        }
        
        //- Quantitat total d'euros que ha facturat l'empresa
        static double Benefici(Empresa empresaNova)
        {
            var benefici = empresaNova.Comandes
            .SelectMany(c => c.Productes, (c, p) => new { Comanda = c, Producte = p })
            .Sum(cp => cp.Comanda.Productes[cp.Producte.Key] * cp.Producte.Value);

            return benefici;
        }

        //- Donades dues dates, quantitat que ha facturat l'empresa entre aquestes dues dates

        static double BeneficiRang(Empresa empresaNova, DateTime start, DateTime final)
        {
            double benefici = empresaNova.Comandes
                .Where(c => c.DataComanda >= start && c.DataComanda <= final)
                .SelectMany(c => c.Productes.Select(p => p.Value * c.Productes[p.Key]).ToList())
                .Sum();
            return benefici;
        }

        //- Quin és el comercial que més ha facturat
       /* static Comercial MillorComercialEnFacturacio(Empresa empresaNova)
        {
            var comandes = empresaNova.Comandes
                .GroupBy(c => c.EmpleatId)
                .Select(comanda => comanda.Productes)
                .OrderByDescending(c => c.Benefici);

            //var comercialMesVendes = (beneficiComercials.FirstOrDefault()?.EmpleatId, beneficiComercials.FirstOrDefault()?.Benefici ?? 0);

        }
          
        //- Donada una quantitat, quins comercials han facturat aquesta quantitat o més
        static List<Comercial> ComercialsQueHanFacturatMesQue(Empresa empresaNova, double import)
        {
            return new NotImplementedException();
        }*/

        //- Donat un número n, els n productes més venuts
        static List<string> NProductesMesVenuts(Empresa empresaNova, int n)
        {
            var productesVenuts = empresaNova.Comandes
                .SelectMany(comanda => comanda.Productes)
                .GroupBy(p => p.Key)
                .Select(g => new { Product = g.Key, Sales = g.Sum(p => p.Value) })
                .OrderByDescending(x => x.Sales)
                .Take(n)
                .Select(x => x.Product)
                .ToList();

            return productesVenuts;
        }
        #endregion
    }
    #endregion
}      

