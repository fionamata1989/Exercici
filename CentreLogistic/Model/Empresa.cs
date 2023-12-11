using CentreLogistic.Dades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Model
{
    public class Empresa
    {
        const int MIN = 1;
        const int MAX = 20;

        public Empresa()
        {
            Empleats = new List<Empleat>();
            Clients = new List<Client>();
            Vehicles = new List<Vehicle>();
            Categories = new List<Categoria>();
            Productes = new List<Producte>();
            Comercials = new List<Comercial>();
            Empreses = new List<Empresa>();
            Comandes = new List<Comanda>();

            //Estructures de dades addicionals:
            ProductesPerIDCategoria = new Dictionary<string, IEnumerable<Producte>>();
            EmpleatsPerId = new Dictionary<string, List<Empleat>>();
            //ClientsPerId = new Dictionary<string, List<Client>>();
            ComandesPerClient = new Dictionary<string, List<Comanda>>();
            ComandesPerComercial = new Dictionary<string, List<Comanda>>();
        }

        #region Propietats
        public string NIF { get; set; }
        public string NomFiscal { get; set; }
        public string NomComercial { get; set; }
        public string Adreca { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public List<Empleat> Empleats { get; set; }
        public List<Client> Clients { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Categoria> Categories { get; set; }
        public List<Producte> Productes { get; set; }
        public List<Comercial> Comercials { get; set; }
        public List<Tecnic> Tecnics { get; set; }
        public List<Directiu> Directius { get; set; }
        public List<Empresa> Empreses { get; set; }
        public List<Comanda> Comandes { get; set; }

        #region Estructures de dades addicionals
        public Dictionary<String, IEnumerable<Producte>> ProductesPerIDCategoria { get; private set; }

        public Dictionary<String, List<Empleat>> EmpleatsPerId { get; private set; }

        public Dictionary<String, List<Comanda>> ComandesPerClient { get; private set; }

        public Dictionary<String, List<Comanda>> ComandesPerComercial { get; private set; }
        #endregion
        #endregion

        #region Sobreescriptures
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
                Empresa other = (Empresa)obj;
                resultat = NIF == other.NIF;
            }
            return resultat;
        }

        public override int GetHashCode()
        {
            return NIF.GetHashCode();
        }
        public override string ToString()
        {
            return $"Empresa [NIF={NIF}, Nom={NomComercial}, Adreca={Adreca}, Telefon={Telefon}, Email={Email}]";
        }
        #endregion

        #region ignorar
        //Rep un DAO i: 
        public void CarregaDades(IDadesCentreLogistic dao)
        {
            //afageix les categories una per una.
            IEnumerable<Categoria> llistaCategories = dao.ObtenCategories();
            AfegeixCategories(llistaCategories);

            //Afegeix productes un per un
            IEnumerable<Producte> llistaProductes = dao.ObtenProductes();
            AfegeixProductes(llistaProductes);

            IEnumerable<Client> llistaClients = dao.ObtenClients();
            AfegeixClients(llistaClients);

            IEnumerable<Comercial> llistaComercials = dao.ObtenComercials();
            IEnumerable<Tecnic> llistaTecnics = dao.ObtenTecnics();
            IEnumerable<Directiu> llistaDirectius = dao.ObtenDirectius();

            IEnumerable<Cotxe> llistaCotxes = dao.ObtenCotxes();
            IEnumerable<Furgoneta> llistaFurgonetes = dao.ObtenFurgonetes();
            IEnumerable<Moto> llistaMotos = dao.ObtenMotos();

            //Llistats combinats: 
            IEnumerable<Empleat> llistaEmpleats = LlistaEmpleats(llistaDirectius, llistaTecnics,llistaComercials);
            IEnumerable<Vehicle> llistaVehicles = LlistaVehicles(llistaCotxes, llistaFurgonetes, llistaMotos);

            IEnumerable<Comanda> llistaComandes = dao.ObtenComandes();
        }

        #endregion

        public void CarregaDades2(IDadesCentreLogistic dao)
        {
            IEnumerable<Producte> productes = dao.ObtenProductes();
            IEnumerable<Categoria> categories = dao.ObtenCategories();
            IEnumerable<Client> clients = dao.ObtenClients();
            IEnumerable<Comercial> comercials = dao.ObtenComercials();
            IEnumerable<Comanda> comandes = dao.ObtenComandes();
            IEnumerable<Tecnic> tecnics = dao.ObtenTecnics();
            IEnumerable<Directiu> directius = dao.ObtenDirectius();
            IEnumerable<Cotxe> cotxes = dao.ObtenCotxes();
            IEnumerable<Furgoneta> furgonetes = dao.ObtenFurgonetes();
            IEnumerable<Moto> motos = dao.ObtenMotos();

            IEnumerable<Empleat> llistaEmpleats = LlistaEmpleats(directius, tecnics, comercials);
            IEnumerable<Vehicle> llistaVehicles = LlistaVehicles(cotxes, furgonetes, motos);

            IEnumerable<Comanda> llistaComandes = dao.ObtenComandes();

            foreach (Categoria categoria in categories)
                Categories.Add(categoria);

            foreach (Producte producte in productes)
                Productes.Add(producte);

            foreach (Client client in clients)
                Clients.Add(client);

            foreach (Comercial comercial in comercials)
                Empleats.Add(comercial);

            foreach (Tecnic t in tecnics)
                Empleats.Add(t);
            
            foreach (Directiu d in directius)
                Empleats.Add(d);

            foreach (Comanda comanda in comandes)
                Comandes.Add(comanda);

            foreach (Cotxe c in cotxes)
                Vehicles.Add(c);

            foreach (Furgoneta f in furgonetes)
                Vehicles.Add(f);

            foreach (Moto m in motos)
                Vehicles.Add(m);

        }

        public void DesaDades2(IDadesCentreLogistic dao)
        {
            dao.DesaProductes(Productes);
            dao.DesaCategories(Categories);
            dao.DesaClients(Clients);
            dao.DesaComercials(Comercials);
            dao.DesaComandes(Comandes);
            
            List<Directiu> directius = new List<Directiu>();
            List<Tecnic> tecnics = new List<Tecnic>();
            List<Comercial> comercials = new List<Comercial>();

            foreach (Empleat e in Empleats)
            {
                if (e is Directiu)
                {
                    Directiu d = (Directiu)e;
                    directius.Add(d);
                }
                else if (e is Tecnic)
                {
                    Tecnic t = (Tecnic)e;
                    tecnics.Add(t);
                }
                else
                {
                    Comercial c = (Comercial)e;
                    comercials.Add(c);
                }
            }

            dao.DesaDirectius(directius);
            dao.DesaTecnics(tecnics);
            dao.DesaComercials(comercials);

            List<Cotxe> cotxes = new List<Cotxe>();
            List<Furgoneta> furgonetes = new List<Furgoneta>();
            List<Moto> motos = new List<Moto>();
            
            foreach (Vehicle v in Vehicles)
            {
                if (v.IsVehicleDeGerencia)
                {
                    Cotxe c = (Cotxe)v;
                    cotxes.Add(c);
                }
                else if (v is Furgoneta)
                {
                    Furgoneta f = (Furgoneta)v;
                    furgonetes.Add(f);
                }
                else
                {
                    Moto m = (Moto)v;
                    motos.Add(m);
                }
            }
            dao.DesaCotxes(cotxes);
            dao.DesaFurgonetes(furgonetes);
            dao.DesaMotos(motos);
        }

        public void BorraDades()
        {
            Categories.Clear();
            Productes.Clear();
            Empleats.Clear();
            Clients.Clear();
            Vehicles.Clear();
            Comandes.Clear();
            EmpleatsPerId.Clear();
            ComandesPerClient.Clear();
            ComandesPerComercial.Clear();
            ProductesPerIDCategoria.Clear();
        }
    
        //Utilitzant la interfície guanyem molta maniobrabilitat, ja que no obliguem treballar amb una estructura de dades fixades, si no amb un interfície, un contracte, que segueix unes normes. 
        private void AfegeixCategories(IEnumerable<Categoria> llistaCategories)
        {
            foreach(Categoria categoria in llistaCategories)
            {
                //Afegim una categoria i llegim la pròxima.
                AfegeixCategoria(categoria);
            }
        }
 
        public void AfegeixCategoria(Categoria categoriaNova)
        {
            int posicio = 0;

            if (Categories.Any(cat => cat.IdCategoria == categoriaNova.IdCategoria))
            {
                //Sobreescriptura categories.
                Categories[posicio].Descripcio = categoriaNova.Descripcio;
                Categories[posicio].Nom = categoriaNova.Nom;
            }
            else 
            {
                Categories.Add(categoriaNova);
            }

            //Si no hi ha la clau IdCategoria, l'afegim i creem una nova llista:
            if (!ProductesPerIDCategoria.ContainsKey(categoriaNova.IdCategoria))
            {
                ProductesPerIDCategoria.Add(categoriaNova.IdCategoria, new List<Producte>());
            }
        }

        public void AfegeixProductes(IEnumerable<Producte> llistaProductes)
        {
            foreach(Producte producte in llistaProductes)
            {
                AfegeixProducte(producte);
            }
        }

        public void AfegeixProducte(Producte producteNou)
        {
            int posicio = 0;
            while (posicio < Productes.Count && producteNou.IdProducte != Productes[posicio].IdProducte)
                posicio++;

            if(posicio == Productes.Count)
                Productes.Add(producteNou);

            else
            {
                Productes[posicio].Descripcio = producteNou.Descripcio;
                Productes[posicio].Nom = producteNou.Nom;
                Productes[posicio].Preu = producteNou.Preu;
                Productes[posicio].Stock = producteNou.Stock;
            }

            //Falta part diccionari.
            //Si dins de la posició de categoria en el diccionari tenim la clau...
            if (ProductesPerIDCategoria.ContainsKey(producteNou.CategoriaId))
            {
                List<Producte> productesCategoria = (List<Producte>)ProductesPerIDCategoria[producteNou.CategoriaId]; 
                if (!productesCategoria.Contains(producteNou))
                {
                    productesCategoria.Add(producteNou);
                }
            }
        }

        public void AfegeixClients(IEnumerable<Client> clients)
        {
            foreach (Client client in clients)
                AfegeixClient(client);
        }

        public void AfegeixClient(Client client)
        {
            int posicio = 0;
            while (posicio < Clients.Count && client.IdClient != Clients[posicio].IdClient)
                posicio++;

            if (posicio == Clients.Count)
                Clients.Add(client);

            else
            {
                Clients[posicio].Nom = client.Nom;
                Clients[posicio].Telefon = client.Telefon;
                Clients[posicio].Email = client.Email;
                Clients[posicio].Adreca = client.Adreca;
                Clients[posicio].Ciutat = client.Ciutat;
            }

            //Diccionari ComandesPerClient:
            if (!ComandesPerClient.ContainsKey(client.IdClient))
            {
                ComandesPerClient.Add(client.IdClient, new List<Comanda>());
            }
        }

        public void AfegeixComercials(IEnumerable<Comercial> comercials)
        {
            foreach (Comercial c in comercials)
                AfegeixComercial(c);
        }

        public void AfegeixComercial(Comercial comercial)
        {
            int pos = 0;
            while (pos < Comercials.Count && comercial.IdEmpleat != Comercials[pos].IdEmpleat)
                pos++;

            if (pos == Comercials.Count)
                Comercials.Add(comercial);

            else
            {
                Comercials[pos].Nom = comercial.Nom;
                Comercials[pos].PercentatgeDeComissio = comercial.PercentatgeDeComissio;
                Comercials[pos].VehiclesId = comercial.VehiclesId;
            }

            //Diccionari EmpleatsPerID:
            if (!EmpleatsPerId.ContainsKey(comercial.IdEmpleat))
            {
                EmpleatsPerId.Add(comercial.IdEmpleat, new List<Empleat>());
            }
            EmpleatsPerId[comercial.IdEmpleat].Add(comercial);

            //Diccionari ComandesPerComercial:
            if (!ComandesPerComercial.ContainsKey(comercial.IdEmpleat))
            {
                ComandesPerComercial.Add(comercial.IdEmpleat, new List<Comanda>());
            }
        }

        public void AfegeixTecnics(IEnumerable<Tecnic> tecnics)
        {
            foreach (Tecnic tecnic in tecnics)
                AfegeixTecnic(tecnic);
        }

        public void AfegeixTecnic(Tecnic tecnic)
        {
            int pos = 0;
            while (pos < Tecnics.Count && tecnic.IdEmpleat != Tecnics[pos].IdEmpleat)
                pos++;
            if (pos == Tecnics.Count) Tecnics.Add(tecnic);
            else
            {
                Tecnics[pos].Nom = tecnic.Nom;
                Tecnics[pos].Edat = tecnic.Edat;
                Tecnics[pos].Especialitat = tecnic.Especialitat;
            }

            if (!EmpleatsPerId.ContainsKey(tecnic.IdEmpleat))
            {
                EmpleatsPerId.Add(tecnic.IdEmpleat, new List<Empleat>());
            }
            EmpleatsPerId[tecnic.IdEmpleat].Add(tecnic);
        }

        public void AfegeixDirectius(IEnumerable<Directiu> directius)
        {
            foreach(Directiu directiu in Directius)
            {
                AfegeixDirectiu(directiu);
            }
        }

        public void AfegeixDirectiu(Directiu directiu)
        {
            int pos = 0;
            while (pos < Directius.Count && directiu.IdEmpleat != Directius[pos].IdEmpleat)
                pos++;
            if (pos == Directius.Count) Directius.Add(directiu);
            else
            {
                Directius[pos].Nom = directiu.Nom;
                Directius[pos].Departament = directiu.Departament;
                Directius[pos].SubordinatsId = directiu.SubordinatsId;
            }
            
            if (!EmpleatsPerId.ContainsKey(directiu.IdEmpleat))
            {
                EmpleatsPerId.Add(directiu.IdEmpleat, new List<Empleat>());
            }
            EmpleatsPerId[directiu.IdEmpleat].Add(directiu);
        }

        public void AfegeixEmpreses(IEnumerable<Empresa> empreses)
        {
            foreach (Empresa empresa in empreses)
            {
                AfegeixEmpresa(empresa);
            }
        }

        public void AfegeixEmpresa(Empresa empresa)
        {
            int pos = 0;
            while (pos < Empreses.Count && empresa.NIF != Empreses[pos].NIF) pos++;
            if (pos == Empreses.Count)
                Empreses.Add(empresa);
            else
            {
                Empreses[pos].NomComercial = empresa.NomComercial;
                Empreses[pos].NomFiscal = empresa.NomFiscal;
                Empreses[pos].Adreca = empresa.Adreca;
                Empreses[pos].Email = empresa.Email;
                Empreses[pos].Clients = empresa.Clients;
                Empreses[pos].Categories= empresa.Categories;
                Empreses[pos].Comandes = empresa.Comandes;
                Empreses[pos].Productes= empresa.Productes;
            }
        }

        public void AfegeixComandes(IEnumerable<Comanda> comandes)
        {
            foreach (Comanda comanda in comandes)
            {
                AfegeixComanda(comanda);
            }
        }

        public void AfegeixComanda(Comanda comanda)
        {
            int pos = 0;
            while (pos < Comandes.Count && comanda.IDComanda != Comandes[pos].IDComanda) pos++;
            if (pos == Comandes.Count) Comandes.Add(comanda);
            else
            {
                Comandes[pos].ClientId = comanda.ClientId;
                Comandes[pos].EmpleatId = comanda.EmpleatId;
                Comandes[pos].DataComanda = comanda.DataComanda;
                Comandes[pos].DataEnviament= comanda.DataEnviament;
                Comandes[pos].Estat = comanda.Estat;
                Comandes[pos].Productes = comanda.Productes;
            }

            //Diccionari ComandesPerClient:
            if (ComandesPerClient.ContainsKey(comanda.ClientId))
            {
                List<Comanda> comandesPerClient = ComandesPerClient[comanda.ClientId];
                if (!comandesPerClient.Contains(comanda))
                    comandesPerClient.Add(comanda);
            }
            else
            {
                List<Comanda> nouComandesPerClient = new List<Comanda>();
                nouComandesPerClient.Add(comanda);
                ComandesPerClient.Add(comanda.ClientId, nouComandesPerClient);
            }
            //Diccionari ComandesPerComercial:
            if (ComandesPerComercial.ContainsKey(comanda.EmpleatId))
            {
                List<Comanda> comandesPerComercial = ComandesPerComercial[comanda.EmpleatId] as List<Comanda>;
                if (!comandesPerComercial.Contains(comanda))
                    comandesPerComercial.Add(comanda);
            }
            else
            {
                List<Comanda> nouComandesPerComercial = null;
                nouComandesPerComercial.Add(comanda);
                ComandesPerClient.Add(comanda.EmpleatId, nouComandesPerComercial);
            }
        }

        public void DesaDades(IDadesCentreLogistic dao)
        {
            dao.DesaCategories(Categories);
        }

        private void DesaEmpleats(IDadesCentreLogistic dao, List<Empleat> llistaEmpleats)
        {
            List<Directiu> directius = new List<Directiu>();
            List<Tecnic> tecnics = new List<Tecnic>();
            List<Comercial> comercials = new List<Comercial>();
            
            foreach (Empleat e in llistaEmpleats)
            {
                if (e is Directiu) directius.Add((Directiu)e);
                else if (e is Tecnic) tecnics.Add((Tecnic)e);
                else comercials.Add((Comercial)e);
            }

            dao.DesaDirectius(directius);
            dao.DesaTecnics(tecnics);
            dao.DesaComercials(comercials);
        }

        public void DesaVehicles(IDadesCentreLogistic dao, List<Vehicle> llistaVehicles)
        {
            List<Cotxe> cotxes = new List<Cotxe>();
            List<Furgoneta> furgonetes = new List<Furgoneta>();
            List<Moto> motos = new List<Moto>();
            
            foreach (Vehicle v in llistaVehicles)
            {
                if (v is Cotxe) 
                    cotxes.Add((Cotxe)v);

                else if (v is Furgoneta)
                    furgonetes.Add((Furgoneta)v);

                else motos.Add((Moto)v);
            }

            dao.DesaCotxes(cotxes);
            dao.DesaFurgonetes(furgonetes);
            dao.DesaMotos(motos);
        }

        public IEnumerable<Empleat> ObtenEmpleats(IEnumerable<Directiu> directius, IEnumerable<Tecnic> tecnics, IEnumerable<Comercial> comercials)
        {
            List<Empleat> empleats = LlistaEmpleats(directius, tecnics, comercials);
            return empleats;
        }

        public List<Empleat> LlistaEmpleats (IEnumerable<Directiu> directius, IEnumerable<Tecnic> tecnics, IEnumerable<Comercial> comercials)
        {
            //Per fer la llista d'empleats hi ha dues estratègies: o fem dues lectures, una que carreguem i una segona que llegim a fons les dades,
            //o carreguem ja i, en donar-se el cas d'un directiu que encara no ha estat llegit, el carreguem buit al final i l'emplenem amb les seves dades quan arribi el moment:
            List<Empleat> llistaEmpleats = new List<Empleat>();
            Directiu directiuExistent;
            
            foreach (Directiu directiu in directius)
            {
                int pos = 0;
                while (pos < llistaEmpleats.Count && directiu.IdEmpleat != llistaEmpleats[pos].IdEmpleat)
                    pos++;
                if (pos == llistaEmpleats.Count)
                    llistaEmpleats.Add(directiu);
                else
                {
                    llistaEmpleats[pos].Nom = directiu.Nom;
                    llistaEmpleats[pos].Edat = directiu.Edat;
                    llistaEmpleats[pos].DataContracte = directiu.DataContracte;
                    llistaEmpleats[pos].Carrec = directiu.Carrec;
                    llistaEmpleats[pos].VehiclesId = directiu.VehiclesId;

                    //No toquem llista de subordinats: l'ha de conservar. 
                }
                #region anterior
                //if (directiu.Supervisor != null)
                //{
                //    //Si existeix, l'assignem
                //    if (directiu.Supervisor
                //        directiuExistent = directiu;
                //    //si no, en fem un de nou:
                //    Directiu directiuNou = new Directiu();
                //    directiuNou.IdEmpleat = directiu.Supervisor;

                //    //Si existeix en la llista, l'afegeixo a subordinats d'aquest directiu, si no, faig directiu nou i afegeixo llista. Cal fer-ho pels demés també.
                //    if (directiuNou.Supervisor == directiu.Supervisor)
                //        directiu.SubordinatsId.Add(directiuNou.IdEmpleat);

                //    llistaEmpleats.Add(directiuNou);
                #endregion
            }

            foreach (Tecnic tecnic in tecnics)
            { 
                if (tecnic.Supervisor!= null)
                {
                    int pos = 0;
                    while (pos < llistaEmpleats.Count && tecnic.IdEmpleat != llistaEmpleats[pos].IdEmpleat) pos++;

                    if (pos == llistaEmpleats.Count)
                        llistaEmpleats.Add(tecnic); 
                    else
                    {
                        llistaEmpleats[pos].Nom = tecnic.Nom;
                        llistaEmpleats[pos].DataContracte = tecnic.DataContracte;
                        llistaEmpleats[pos].Salari = tecnic.Salari;
                        llistaEmpleats[pos].Carrec = tecnic.Carrec;
                    }

                    if (llistaEmpleats[pos].IsDirectiu && tecnic.Supervisor == llistaEmpleats[pos].IdEmpleat)
                    {
                        directiuExistent = (Directiu)llistaEmpleats[pos];
                        directiuExistent.SubordinatsId.Add(tecnic.IdEmpleat);
                    }
                    #region anterior
                    ////Si el tècnic té supervisor, creem un nou directiu i li associem el Id del supervisor del tècnic.
                    //Directiu directiuNou = new Directiu();
                    //directiuNou.IdEmpleat = tecnic.Supervisor;

                    ////Controlem si dins de la llista ja existeix l'ID del directiu
                    //foreach (Empleat empleat in llistaEmpleats)
                    //{
                    //    //Ens assegurem que sigui directiu, ja que les llistes de subordinats les tenen només directius:
                    //    if(empleat.IsDirectiu && empleat.IdEmpleat == directiuNou.IdEmpleat)
                    //    {
                    //        directiuExistent = (Directiu)empleat;
                    //    }
                    //}
                    ////Si aquest id coincideix amb supervisor existent, l'afegim a la llista d'empleats:
                    //if (directiuExistent.IdEmpleat == tecnic.Supervisor)
                    //    directiuExistent.SubordinatsId.Add(tecnic.IdEmpleat);

                    //llistaEmpleats.Add(tecnic);
                    #endregion
                }
            }
            foreach (Comercial comercial in comercials)
            {
                if (comercial.Supervisor != null)
                {
                    int pos = 0;
                    while (pos < llistaEmpleats.Count && comercial.IdEmpleat != llistaEmpleats[pos].IdEmpleat) pos++;

                    if (pos == llistaEmpleats.Count)
                        llistaEmpleats.Add(comercial);
                    else
                    {
                        llistaEmpleats[pos].Nom = comercial.Nom;
                        llistaEmpleats[pos].DataContracte = comercial.DataContracte;
                        llistaEmpleats[pos].Salari = comercial.Salari;
                        llistaEmpleats[pos].Carrec = comercial.Carrec;
                    }

                    if (llistaEmpleats[pos].IsDirectiu && comercial.Supervisor == llistaEmpleats[pos].IdEmpleat)
                    {
                        directiuExistent = (Directiu)llistaEmpleats[pos];
                        directiuExistent.SubordinatsId.Add(comercial.IdEmpleat);
                    }
                }
            }
            return llistaEmpleats;
        }

        public List<Vehicle> LlistaVehicles(IEnumerable<Cotxe> cotxes, IEnumerable<Furgoneta> furgonetes, IEnumerable<Moto> motos)
        {
            List<Vehicle> llistaVehicles = new List<Vehicle>();
            Cotxe cotxeNou = new Cotxe();

            foreach (Cotxe ctx in cotxes)
            {
                llistaVehicles.Add(ctx);
                int idx = 0;
                while (idx < Empleats.LongCount())
                {
                    if (Empleats[idx].IdEmpleat == ctx.ConductorId)
                    {
                        Empleats[idx].VehiclesId.Add(ctx.ConductorId);
                        idx++;
                    }
                    else
                        idx++;
                }
            }

            foreach (Furgoneta frgnt in furgonetes)
            {
                llistaVehicles.Add(frgnt);
                int idx = 0;
                while (idx < Empleats.LongCount())
                {
                    if (Empleats[idx].IdEmpleat == frgnt.ConductorId)
                    {
                        Empleats[idx].VehiclesId.Add(frgnt.ConductorId);
                        idx++;
                    }
                    else
                        idx++;
                }
            }   

            foreach(Moto moto in motos)
            {
                llistaVehicles.Add(moto);
                int idx = 0;
                while (idx < Empleats.LongCount())
                {
                    if (Empleats[idx].IdEmpleat == moto.ConductorId)
                    {
                        Empleats[idx].VehiclesId.Add(moto.ConductorId);
                        idx++;
                    }
                    else
                        idx++;
                }
            }
            return llistaVehicles;
        }

        public void GeneraComandes(int nComandes)
        {
            Random random = new Random();
            int nLinies, nUnitats, comptador = 0;
            
            while (comptador < nComandes)
            {
                Comanda comanda = new Comanda();
                comanda.ClientId = RandomClient(Clients);
                comanda.EmpleatId = RandomEmpleat(Empleats);
                comanda.DataComanda = DataComandaRandom();
                comanda.DataEnviament = DataEnviamentRandom(comanda.DataComanda);

                nLinies = random.Next(MIN, MAX + 1);

                comanda.Productes = RandomProductes(nLinies);
                comptador++;
                //Em generat una comanda tindrem unes dates, client, comercial i línies.
                //Cada línia tindrà un id de producte i una quantitat. Aquestes línies poden ser un diccionari de producte+quantitat (string + int)
                Comandes.Add(comanda);
            }
        }

        public void DesaComanda(IDadesCentreLogistic dao, List<Comanda> comandes)
        {
            dao.DesaComandes(Comandes);
        }

        
        #region mètodes propis
        private String RandomClient(List<Client>llistaClients)
        {
            Random random = new Random();
            int idx = random.Next(llistaClients.Count);
            string client = llistaClients[idx].IdClient;
            return client;
        }

        private static String RandomEmpleat(List<Empleat> llistaEmpleats)
        {
            Random random = new Random();
            int idx = random.Next(llistaEmpleats.Count);
            string idEmpleat = llistaEmpleats[idx].IdEmpleat;
            return idEmpleat;
        }

        private DateTime DataComandaRandom()
        {
            Random random = new Random();
            DateTime dataComandaRandom;
            DateTime inici = new DateTime(2020, 1, 1);
            int rang = (DateTime.Today - inici).Days;
            dataComandaRandom = inici.AddDays(random.Next(rang))
                                            .AddHours(random.Next(24))
                                            .AddMinutes(random.Next(60))
                                            .AddSeconds(random.Next(60))
                                            .AddMilliseconds(random.Next(1000));
            return dataComandaRandom;
        }

        private DateTime DataEnviamentRandom(DateTime dataComanda)
        {
            Random random = new Random();
            DateTime dataEnviamentRandom;
            int rang = (DateTime.Today - dataComanda).Days;
            dataEnviamentRandom = dataComanda.AddDays(random.Next(rang))
                                          .AddHours(random.Next(24))
                                          .AddMinutes(random.Next(60))
                                          .AddSeconds(random.Next(60))
                                          .AddMilliseconds(random.Next(1000));
            return dataEnviamentRandom;
        }

        private Dictionary<string, int> RandomProductes(int nLinies)
        {
            Random random = new Random();
            Dictionary<string, int> productesIUnitats = new Dictionary<string, int>();
            int comptador = 0, idx, nUnitats = 0;
            
            while (comptador < nLinies)
            {
                Producte producte = new Producte();
                idx = random.Next(Productes.Count);
                producte.IdProducte = Productes[idx].IdProducte;
                nUnitats = random.Next(MIN, MAX + 1);
                
                if (!productesIUnitats.ContainsKey(producte.IdProducte))
                {
                    productesIUnitats.Add(producte.IdProducte, nUnitats);
                }
                comptador++;
            }
            return productesIUnitats;
        }

        #endregion
    }
}
