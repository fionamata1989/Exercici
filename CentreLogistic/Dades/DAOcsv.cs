using CentreLogistic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Dades
{
    /*En implementar la interfície, podem generar automàticament els mètodes que hi van relacionats.
     Només caldrà implementar-los. 


    CAL IMPLEMENTAR LES DEMÉS CLASSES: Només per categories, productes (SOBRETOT) i persones: agafem i posem a tots en una llista de persones per poder fer-ho. Depenent de quin tipus és, anirà a un fitxer o a un altre.
    */
//    public class DAOcsv : IDadesCentreLogistic
//    {
//        const String NOM_FITXER_CATEGORIES = "Categories.csv";
//        const String NOM_FITXER_PRODUCTES = "Productes.csv";
//        //const String NOM_FITXER_PERSONES = "Persones.csv";
//        const String NOM_FITXER_DIRECTIUS = "Directius.csv";
//        const String NOM_FITXER_TECNICS = "Tecnics.csv";
//        const String NOM_FITXER_COMERCIALS = "Comercials.csv";
//        const String NOM_FITXER_CLIENTS = "Clients.csv";
//        const String NOM_FITXER_COTXES = "Cotxes.csv";
//        const String NOM_FITXER_FURGONETES = "Furgonetes.csv";
//        const String NOM_FITXER_MOTOS = "Motos.csv";

//        //PAS 2. Necessitem propietats.
//        public string Carpeta { get; private set; }


//        //PAS 1. Falta primer un constructor:
//        public DAOcsv(): this("Default") { }

//        //Posem carpeta pq tot es guardi en una carpeta en específic: motos amb motos, cotxes amb cotxes... Dins de la carpeta es guardaran tots els fitxers:
//        public DAOcsv(string carpeta) 
//        {
//            if (ComprobaSiElNomEsCorrecte(carpeta))
//                Carpeta = carpeta;
//            else
//                Carpeta = "Default";
//        }

//        //Opcional de fer.
//        private bool ComprobaSiElNomEsCorrecte(string carpeta)
//        {
//            bool esValid = false;
//            carpeta = carpeta.ToLower();
//            for (int i = 0; i <= carpeta.Length; i++)
//            {
//                esValid = carpeta[i] >= 48 && carpeta[i] <= 57 || carpeta[i] >= 97 && carpeta[i] <= 122;
//            }
//            return esValid;
//        }

//        public void DesaCategories(IEnumerable<Categoria> categories)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_CATEGORIES, false))
//            {
//                tw.WriteLine("IdCategoria,Nom,Descripcio,ProductesId");
//                foreach (Categoria categoria in categories) 
//                {
//                    tw.Write(categoria.IdCategoria);
//                    tw.Write(',');
//                    tw.Write(categoria.Nom);
//                    tw.Write(',');
//                    tw.Write(categoria.Descripcio);
//                    tw.Write(',');
//                    tw.Write(categoria.ProductesId);
//                    tw.Write(',');
//                }
//            }
//        }

//        public void DesaClients(IEnumerable<Client> clients)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_CLIENTS, false))
//            {
//                tw.WriteLine("IdClient,IdPersona,Nom,Edat,Adreca,Ciutat,CodiPostal,Email,Telefon,ComandesId");
//                foreach (Client client in clients)
//                {
//                    tw.Write(client.IdClient); 
//                    tw.Write(',');
//                    tw.Write(client.IdPersona);
//                    tw.Write(',');
//                    tw.Write(client.Nom);
//                    tw.Write(',');
//                    tw.Write(client.Edat);
//                    tw.Write(',');
//                    tw.Write(client.Adreca);
//                    tw.Write(',');
//                    tw.Write(client.Ciutat);
//                    tw.Write(',');
//                    tw.Write(client.CodiPostal);
//                    tw.Write(',');
//                    tw.Write(client.Email);
//                    tw.Write(',');
//                    tw.Write(client.Telefon);
//                    tw.Write(',');
//                    tw.Write(client.ComandesId);
//                }
//            }
//        }

//        public void DesaComercials(IEnumerable<Comercial> comercials)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_COMERCIALS, false))
//            {
//                tw.WriteLine("IdPersona,Nom,Edat,Adreca,Ciutat,IdEmpleat,Carrec,Salari,DataContracte,VehiclesId,Seccio,Fix,PercentatgeDeComissio,ComandesId,IsDirectiu");
//                foreach (Comercial comercial in comercials)
//                {
//                    tw.Write(comercial.IdPersona);
//                    tw.Write(',');
//                    tw.Write(comercial.Nom);
//                    tw.Write(',');
//                    tw.Write(comercial.Edat);
//                    tw.Write(',');
//                    tw.Write(comercial.Adreca);
//                    tw.Write(',');
//                    tw.Write(comercial.Ciutat);
//                    tw.Write(',');
//                    tw.Write(comercial.IdEmpleat);
//                    tw.Write(',');
//                    tw.Write(comercial.Carrec);
//                    tw.Write(',');
//                    tw.Write(comercial.Salari);
//                    tw.Write(',');
//                    tw.Write(comercial.DataContracte);
//                    tw.Write(',');
//                    tw.Write(comercial.VehiclesId);
//                    tw.Write(',');
//                    tw.Write(comercial.Seccio);
//                    tw.Write(',');
//                    tw.Write(comercial.Fix);
//                    tw.Write(',');
//                    tw.Write(comercial.PercentatgeDeComissio);
//                    tw.Write(',');
//                    tw.Write(comercial.ComandesId);
//                    tw.Write(',');
//                    tw.Write(comercial.IsDirectiu);
//                    tw.Write(',');
//                }
//            }
//        }

//        public void DesaCotxes(IEnumerable<Cotxe> cotxes)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_COTXES, false))
//            {
//                tw.WriteLine("IdVehicle,Marca,Model,Any,Matricula,Preu,ConductorId,CapacitatCarrega");
//                foreach (Cotxe cotxe in cotxes)
//                {
//                    tw.Write(cotxe.IdVehicle);
//                    tw.Write(',');
//                    tw.Write(cotxe.Marca);
//                    tw.Write(',');
//                    tw.Write(cotxe.Model);
//                    tw.Write(',');
//                    tw.Write(cotxe.Any);
//                    tw.Write(',');
//                    tw.Write(cotxe.Matricula);
//                    tw.Write(',');
//                    tw.Write(cotxe.Preu);
//                    tw.Write(',');
//                }
//            }
//        }

//        public void DesaDirectius(IEnumerable<Directiu> directius)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_DIRECTIUS, false))
//            {
//                tw.WriteLine("IdEmpleat,Nom,Edat,Adreca,Ciutat,Departament,Carrec,SubordinatsId,DataContracte,Salari,VehiclesId");
//                foreach(Directiu directiu in directius)
//                {
//                    tw.Write(directiu.IdEmpleat);
//                    tw.Write(',');
//                    tw.Write(directiu.Nom);
//                    tw.Write(',');
//                    tw.Write(directiu.Edat);
//                    tw.Write(',');
//                    tw.Write(directiu.Adreca);
//                    tw.Write(',');
//                    tw.Write(directiu.Ciutat);
//                    tw.Write(',');
//                    tw.Write(directiu.Departament);
//                    tw.Write(',');
//                    tw.Write(directiu.Carrec);
//                    tw.Write(',');
//                    tw.Write(directiu.SubordinatsId);
//                    tw.Write(',');
//                    tw.Write(directiu.DataContracte);
//                    tw.Write(',');
//                    tw.Write(directiu.Salari);
//                    tw.Write(',');
//                    tw.Write(directiu.VehiclesId);
//                    tw.Write(',');
//                    tw.Write(directiu.Supervisor);
//                }
//            }
//        }

//        public void DesaTecnics(IEnumerable<Tecnic> tecnics)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_TECNICS, false))
//            {
//                tw.WriteLine("IdEmpleat,Nom,Edat,Adreca,Ciutat,Carrec,Especialitat,Fix,DataContracte,SalariSupervisor");
//                foreach (Tecnic tecnic in tecnics)
//                {
//                    tw.Write(tecnic.IdEmpleat);
//                    tw.Write(',');
//                    tw.Write(tecnic.Nom);
//                    tw.Write(',');
//                    tw.Write(tecnic.Edat);
//                    tw.Write(',');
//                    tw.Write(tecnic.Adreca);
//                    tw.Write(',');
//                    tw.Write(tecnic.Ciutat);
//                    tw.Write(',');
//                    tw.Write(tecnic.Carrec);
//                    tw.Write(',');
//                    tw.Write(tecnic.Especialitat);
//                    tw.Write(',');
//                    tw.Write(tecnic.Fix);
//                    tw.Write(',');
//                    tw.Write(tecnic.DataContracte);
//                    tw.Write(',');
//                    tw.Write(tecnic.Salari);
//                    tw.Write(',');
//                    tw.Write(tecnic.Supervisor);
//                }
//            }
//        }

//        public void DesaFurgonetes(IEnumerable<Furgoneta> furgonetes)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_FURGONETES, false))
//            {
//                tw.WriteLine("IdVehicle,Marca,Model,Any,Matricula,Preu,ConductorId,CapacitatCarrega");
//                foreach(Furgoneta furgoneta in furgonetes)
//                {
//                    tw.Write(furgoneta.IdVehicle);
//                    tw.Write(',');
//                    tw.Write(furgoneta.Marca);
//                    tw.Write(',');
//                    tw.Write(furgoneta.Model);
//                    tw.Write(',');
//                    tw.Write(furgoneta.Any);
//                    tw.Write(',');
//                    tw.Write(furgoneta.Matricula);
//                    tw.Write(',');
//                    tw.Write(furgoneta.Preu);
//                    tw.Write(',');
//                    tw.Write(furgoneta.ConductorId);
//                    tw.Write(',');
//                    tw.Write(furgoneta.CapacitatCarrega);
//                    tw.Write(',');
//                }
//            }
//        }

//        public void DesaMotos(IEnumerable<Moto> motos)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_MOTOS, false))
//            {
//                tw.WriteLine("IdVehicle,Marca,Model,Any,Matricula,Preu,Tipus,Cilindrada,CapacitatMaleta");
//                foreach (Moto moto in motos)
//                {
//                    tw.Write(moto.IdVehicle);
//                    tw.Write(',');
//                    tw.Write(moto.Marca);
//                    tw.Write(',');
//                    tw.Write(moto.Model);
//                    tw.Write(',');
//                    tw.Write(moto.Any);
//                    tw.Write(',');
//                    tw.Write(moto.Matricula);
//                    tw.Write(',');
//                    tw.Write(moto.Preu);
//                    tw.Write(',');
//                    tw.Write(moto.Tipus);
//                    tw.Write(',');
//                    tw.Write(moto.Cilindrada);
//                    tw.Write(',');
//                    tw.Write(moto.CapacitatMaleta);
//                }
//            }
//        }

//        public void DesaProductes(IEnumerable<Producte> productes)
//        {
//            using (TextWriter tw = new StreamWriter(Carpeta + "\\" + NOM_FITXER_PRODUCTES, false))
//            {
//                tw.WriteLine("IdProducte,Nom,Descripcio,Preu,Stock,CategoriaId");
//                foreach (Producte producte in productes)
//                {
//                    tw.Write(producte.IdProducte);
//                    tw.Write(',');
//                    tw.Write(producte.Nom);
//                    tw.Write(',');
//                    tw.Write(producte.Descripcio);
//                    tw.Write(',');
//                    tw.Write(producte.Preu);
//                    tw.Write(',');
//                    tw.Write(producte.Stock);
//                    tw.Write(',');
//                    tw.Write(producte.CategoriaId);
//                }
//            }
//        }

//        public IEnumerable<Categoria> ObtenCategories()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Cotxe> ObtenCotxes()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Furgoneta> ObtenFurgonetes()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Moto> ObtenMotos()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Producte> ObtenProductes()
//        {
//            List<Producte> productes = new();
//            foreach (Producte producte in productes)
//            {
//                productes.Add(producte);
//            }
//            return productes;
//        }

//        /*private IEnumerable<Persona> CreaLlistaPersones(IEnumerable<Empleat> empleats, IEnumerable<Client> clients)
//        {
//            List<Persona> persones = new();
//            foreach (Empleat empleat in empleats)
//                persones.Add(empleat);
//            foreach (Client client in clients)
//                persones.Add(client);
//            return persones;
//        }*/
//    }


}
