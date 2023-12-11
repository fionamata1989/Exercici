using CentreLogistic.Model;

namespace CentreLogistic.Dades
{
    /*
     Cal tenir tots aquests mètodes. Ara, DadesFake ja implementa la interfície, que funciona com un contracte.
    La gràcia és que, en el main, podem cridar DadesCentrLogistic
     */
    public interface IDadesCentreLogistic
    {
        //Problema: rep una llista de categories, és a dir, una estructura de dades. Però podem passar una 
        //interfície. Envés de passar una llista, passem una IList. L'avanttatge és que no val fer una transformació i només cal que cumpleixi amb l'interfície. SI no necessitem totes les coses que té una IList, podem agafar una ICollection, que té menys coses. La més baixa és un IEnumerable. Funciona qualsevol cosa que pugui fer un ForEacht. Una llista és un IEnumerable.

        //Convertim tota List<> en IEnumerable.
        
        void DesaCategories(IEnumerable<Categoria> categories);
        void DesaClients(IEnumerable<Client> Clients);
        void DesaComercials(IEnumerable<Comercial> comercials);
        void DesaCotxes(IEnumerable<Cotxe> cotxes);
        void DesaDirectius(IEnumerable<Directiu> directius);
        void DesaFurgonetes(IEnumerable<Furgoneta> furgonetes);
        void DesaMotos(IEnumerable<Moto> motos);
        void DesaProductes(IEnumerable<Producte> productes);
        void DesaTecnics(IEnumerable<Tecnic> tecnics);
        void DesaEmpresa(Empresa empresa);

        void DesaComandes(IEnumerable<Comanda> comandes);

        //ObteCategories resulta una llista. Estan obligades a ser llistes. Però també podem canviar i, simplement tornar un IEnumerable. Tanmateix, això voldrà dir que 


        IEnumerable<Categoria> ObtenCategories();
        IEnumerable<Client> ObtenClients();
        IEnumerable<Comercial> ObtenComercials();
        IEnumerable<Cotxe> ObtenCotxes();
        IEnumerable<Directiu> ObtenDirectius();
        IEnumerable<Furgoneta> ObtenFurgonetes();
        IEnumerable<Moto> ObtenMotos();
        IEnumerable<Producte> ObtenProductes();
        IEnumerable<Tecnic> ObtenTecnics();
        IEnumerable<Empresa> ObtenEmpresa();

        IEnumerable<Comanda> ObtenComandes();
        

    }
}