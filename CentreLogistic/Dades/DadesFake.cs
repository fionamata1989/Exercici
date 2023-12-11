using CentreLogistic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreLogistic.Dades
{
    public class DadesFake : IDadesCentreLogistic
    {
        #region Categories
        public IEnumerable<Categoria> ObtenCategories()
        {
            List<Categoria> categories = new List<Categoria>()  {
             new Categoria {IdCategoria = "0", Nom = "Electrònica", Descripcio = "Productes electrònics",ProductesId = new List<String>()},
             new Categoria {IdCategoria = "1", Nom = "Roba", Descripcio = "Roba de diferents tipus", ProductesId = new List < String >()},
             new Categoria {IdCategoria = "2",Nom = "Alimentació",Descripcio = "Productes alimentaris",ProductesId = new List < String >()},
             new Categoria {IdCategoria = "3",Nom = "Joguines",Descripcio = "Joguines per a nens i nenes",ProductesId = new List < String >()},
             new Categoria {IdCategoria = "4",Nom = "Oci",Descripcio = "Productes per al temps lliure",ProductesId = new List < String >()}
             };
            return categories;
        }
        public void DesaCategories(IEnumerable<Categoria> categories)
        {
        }
        #endregion
        #region Productes
        public IEnumerable<Producte> ObtenProductes()
        {
            List<Producte> productes = new List<Producte>() {
                 new Producte() { IdProducte = "001",Nom = "Televisor LG OLED55CX6LA",Descripcio = "Televisor OLED de 55\" amb resolució 4K, HDR10 Pro i Dolby Vision IQ.",Preu = 1899,Stock = 50,CategoriaId = "0"},
                 new Producte() { IdProducte = "002",Nom = "Xiaomi POCO F3",Descripcio = "Mòbil amb pantalla AMOLED de 6,67\", processador Snapdragon 870 i càmera triple de 48 MP.",Preu = 349,Stock = 100,CategoriaId = "0"},
                 new Producte() { IdProducte = "003",Nom = "Apple MacBook Pro M1",Descripcio = "Portàtil amb processador M1 d'Apple, pantalla Retina de 13,3\" i 8 GB de memòria RAM.",Preu = 1499,Stock = 25,CategoriaId = "0"},
                 new Producte() { IdProducte = "004",Nom = "Sony WH-1000XM4",Descripcio = "Auriculars inalàmbrics amb cancel·lació de soroll activa, Bluetooth 5.0 i autonomia de fins a 30 hores.",Preu = 379,Stock = 75,CategoriaId = "0"},
                 new Producte() { IdProducte = "005",Nom = "Samsung Galaxy Tab S7",Descripcio = "Tauleta amb pantalla de 11\", processador Snapdragon 865+ i suport per a S Pen.",Preu = 679,Stock = 40,CategoriaId = "0"},
                 new Producte() { IdProducte = "006",Nom = "Logitech MX Master 3",Descripcio = "Ratolí sense fil amb sensor de 4000 DPI, botons personals i roda de desplaçament electromagnètica.",Preu = 99,Stock = 60,CategoriaId = "0"},
                 new Producte() { IdProducte = "007",Nom = "NVIDIA GeForce RTX 3080 Ti",Descripcio = "Targeta gràfica amb 12 GB de memòria GDDR6X, 10240 nuclis CUDA i Ray Tracing en temps real.",Preu = 1199,Stock = 15,CategoriaId = "0"},
                 new Producte() { IdProducte = "008",Nom = "Philips Hue Play Gradient Lightstrip",Descripcio = "Tira LED amb tecnologia Ambilight per a TV de 55\"-65\", compatible amb Google Assistant i Amazon Alexa.",Preu = 179,Stock = 30,CategoriaId = "0"},
                 new Producte() { IdProducte = "009",Nom = "DJI Mavic Air 2",Descripcio = "Dron amb càmera de 48 MP, autonomia de 34 minuts i capacitat per a gravar vídeo en 4K.",Preu = 849,Stock = 20,CategoriaId = "0"},
                 new Producte() { IdProducte = "010",Nom = "Sony PlayStation 5",Descripcio = "Consola de videojocs amb disc dur SSD, sortida 4K i suport per a jocs amb retrocompatibilitat.",Preu = 499,Stock = 10,CategoriaId = "0"},
                 new Producte() { IdProducte = "251",Nom = "Samarreta blanca",Descripcio = "Samarreta blanca de cotó, talla L.",Preu = 19,Stock = 100,CategoriaId = "1"},
                 new Producte() { IdProducte = "252",Nom = "Pantalons negres",Descripcio = "Pantalons negres de tela, talla M.",Preu = 39,Stock = 50,CategoriaId = "1"},
                 new Producte() { IdProducte = "253",Nom = "Vestit de festa",Descripcio = "Vestit de festa negre amb pedreria, talla S.",Preu = 129,Stock = 10,CategoriaId = "1"},
                 new Producte() { IdProducte = "254",Nom = "Jersei de llana",Descripcio = "Jersei de llana gris, talla L.",Preu = 59,Stock = 30,CategoriaId = "1"},
                 new Producte() { IdProducte = "255",Nom = "Bufanda de seda",Descripcio = "Bufanda de seda estampada, color rosa.",Preu = 29,Stock = 20,CategoriaId = "1"},
                 new Producte() { IdProducte = "256",Nom = "Sabates de taló",Descripcio = "Sabates de taló negres de pell, talla 38.",Preu = 89,Stock = 15,CategoriaId = "1"},
                 new Producte() { IdProducte = "257",Nom = "Bikini",Descripcio = "Bikini estampat, talla M.",Preu = 49,Stock = 25,CategoriaId = "1"},
                 new Producte() { IdProducte = "258",Nom = "Gorra",Descripcio = "Gorra de cotó negra.",Preu = 19,Stock = 50,CategoriaId = "1"},
                 new Producte() { IdProducte = "25002",Nom = "Vestit de festa",Descripcio = "Vestit llarg i elegant per a ocasions especials, amb escot en V i pedreria al coll.",Preu = 299,Stock = 30,CategoriaId = "1"},
                 new Producte() { IdProducte = "25003",Nom = "Samarreta estampada",Descripcio = "Samarreta de cotó amb estampat floral i màniga curta.",Preu = 29,Stock = 100,CategoriaId = "1"},
                 new Producte() { IdProducte = "25004",Nom = "Pantaló de vestir",Descripcio = "Pantaló de tela negre per a ocasions formals, amb pinces i botó a la cintura.",Preu = 69,Stock = 70,CategoriaId = "1"},
                 new Producte() { IdProducte = "25005",Nom = "Bikini",Descripcio = "Conjunt de bikini amb sostenidor i braga a joc, en estampat de flors.",Preu = 49,Stock = 20,CategoriaId = "1"},
                 new Producte() { IdProducte = "25006",Nom = "Samarreta bàsica",Descripcio = "Samarreta de cotó en color blanc, amb màniga curta i escot rodó.",Preu = 15,Stock = 150,CategoriaId = "1"},
                 new Producte() { IdProducte = "25007",Nom = "Falda de pell",Descripcio = "Falda ajustada de pell sintètica en color negre, amb cremallera a la part posterior.",Preu = 89,Stock = 40,CategoriaId = "1"},
                 new Producte() { IdProducte = "341", Nom = "Llet sencera", Descripcio = "Llet sencera envasada", Preu = 0.99, Stock = 100, CategoriaId = "2" },
                 new Producte() { IdProducte = "342", Nom = "Iogurt natural", Descripcio = "Iogurt natural envasat", Preu = 1.50, Stock = 75, CategoriaId = "2" },
                 new Producte() { IdProducte = "343", Nom = "Formatge manxec", Descripcio = "Formatge manxec de cabra", Preu = 3.99, Stock = 50, CategoriaId = "2" },
                 new Producte() { IdProducte = "344", Nom = "Coca-cola", Descripcio = "Beguda carbonatada Coca-cola", Preu = 1.29, Stock = 200, CategoriaId = "2" },
                 new Producte() { IdProducte = "345", Nom = "Pasta de full", Descripcio = "Pasta de full congelada", Preu = 2.99, Stock = 30, CategoriaId = "2" },
                 new Producte() { IdProducte = "346", Nom = "Cafè molido", Descripcio = "Cafè molido per a cafetera", Preu = 4.50, Stock = 60, CategoriaId = "2" },
                 new Producte() { IdProducte = "347", Nom = "Poma Golden", Descripcio = "Pomes Golden de la terra", Preu = 0.45, Stock = 150, CategoriaId = "2" },
                 new Producte() { IdProducte = "348", Nom = "Vi negre D.O. Priorat", Descripcio = "Vi negre amb D.O. Priorat", Preu = 9.99, Stock = 25, CategoriaId = "2" },
                 new Producte() { IdProducte = "349", Nom = "Oli d'oliva verge extra", Descripcio = "Oli d'oliva verge extra envasat", Preu = 6.99, Stock = 40, CategoriaId = "2" },
                 new Producte() { IdProducte = "350", Nom = "Formatge brie", Descripcio = "Formatge brie francès", Preu = 2.99, Stock = 50, CategoriaId = "2" },
                 new Producte() { IdProducte = "731", Nom = "Puzle de 1000 peces", Descripcio = "Puzle de 1000 peces amb una imatge de paisatge", Preu = 19.99, Stock = 30, CategoriaId = "3" },
                 new Producte() { IdProducte = "732", Nom = "Lego Star Wars", Descripcio = "Conjunt de Lego per construir una nau de Star Wars", Preu = 59.99, Stock = 20, CategoriaId = "3" },
                 new Producte() { IdProducte = "733", Nom = "Playmobil Pirate Ship", Descripcio = "Conjunt de Playmobil per construir un vaixell de pirates", Preu = 39.99, Stock = 25, CategoriaId = "3" },
                 new Producte() { IdProducte = "734", Nom = "Joc de taula Monopoly", Descripcio = "Joc de taula Monopoly per a 2 a 8 jugadors", Preu = 29.99, Stock = 50, CategoriaId = "3" },
                 new Producte() { IdProducte = "735", Nom = "Joc de cartes UNO", Descripcio = "Joc de cartes UNO per a 2 a 10 jugadors", Preu = 7.99, Stock = 100, CategoriaId = "3" },
                 new Producte() { IdProducte = "736", Nom = "Joc de construcció Magna-Tiles", Descripcio = "Joc de construcció amb peces magnètiques", Preu = 69.99, Stock = 15, CategoriaId = "3" },
                 new Producte() { IdProducte = "737", Nom = "Nina articulada", Descripcio = "Nina articulada amb diferents accessoris", Preu = 29.99, Stock = 40, CategoriaId = "3" },
                 new Producte() { IdProducte = "738", Nom = "Pilota de futbol", Descripcio = "Pilota de futbol de la selecció espanyola", Preu = 14.99, Stock = 75, CategoriaId = "3" },
                 new Producte() { IdProducte = "739", Nom = "Pista de carreres de cotxes", Descripcio = "Pista de carreres de cotxes amb diferents vehicles", Preu = 49.99, Stock = 10, CategoriaId = "3" },
                 new Producte() { IdProducte = "740", Nom = "Joc de construcció K'NEX", Descripcio = "Joc de construcció amb peces K'NEX", Preu = 39.99, Stock = 20, CategoriaId = "3" },
                 new Producte() { IdProducte = "871", Nom = "Puzzle de 1000 peces", Descripcio = "Puzzle de 1000 peces per a totes les edats", Preu = 15.99, Stock = 20, CategoriaId = "4" },
                 new Producte() { IdProducte = "872", Nom = "Joc de taula Monopoly", Descripcio = "Joc de taula Monopoly per a tota la família", Preu = 29.99, Stock = 10, CategoriaId = "4" },
                 new Producte() { IdProducte = "873", Nom = "Cub de Rubik", Descripcio = "Cub de Rubik original 3x3", Preu = 7.99, Stock = 30, CategoriaId = "4" },
                 new Producte() { IdProducte = "874", Nom = "Baralla de cartes", Descripcio = "Baralla de cartes franceses per a jocs de taula", Preu = 4.99, Stock = 50, CategoriaId = "4" },
                 new Producte() { IdProducte = "875", Nom = "Llapis de dibuix", Descripcio = "Llapis de dibuix professional per a artistes", Preu = 2.99, Stock = 100, CategoriaId = "4" },
                 new Producte() { IdProducte = "876", Nom = "Bicicleta de muntanya", Descripcio = "Bicicleta de muntanya per a adults", Preu = 499.99, Stock = 5, CategoriaId = "4" },
                 new Producte() { IdProducte = "877", Nom = "Llibre de sudoku", Descripcio = "Llibre de sudoku amb 1000 enigmes", Preu = 9.99, Stock = 15, CategoriaId = "4" },
                 new Producte() { IdProducte = "878", Nom = "Raqueta de tennis", Descripcio = "Raqueta de tennis professional", Preu = 89.99, Stock = 8, CategoriaId = "4" },
                 new Producte() { IdProducte = "879", Nom = "Joc de dards", Descripcio = "Joc de dards amb targeta electrònica", Preu = 49.99, Stock = 12, CategoriaId = "4" },
                 new Producte() { IdProducte = "880", Nom = "Guitarra acústica", Descripcio = "Guitarra acústica per a principiants", Preu = 129.99, Stock = 3, CategoriaId = "4" }
             };
            return productes;
        }
        public void DesaProductes(IEnumerable<Producte> productes)
        {
        }
        #endregion

        #region Vehicles
        public IEnumerable<Cotxe> ObtenCotxes()
        {
            List<Cotxe> cotxes = new List<Cotxe>() {
                new Cotxe() { IdVehicle = "731", Marca = "Seat", Model = "Ibiza", Any = 2022, Matricula = "1234 ABC", Preu = 15000.0, ConductorId = "", NPlaces = 5, Portes = 3, Automatic = false, Consum = 6.5, Diesel = true, Cavalls = 100 },
                new Cotxe() { IdVehicle = "734", Marca = "Volkswagen", Model = "Golf", Any = 2022, Matricula = "3456 JKL", Preu = 20000.0, ConductorId = "", NPlaces = 5, Portes = 5, Automatic = true, Consum = 5.3, Diesel = true, Cavalls = 110 },
                new Cotxe() { IdVehicle = "735", Marca = "Peugeot", Model = "308", Any = 2022, Matricula = "7890 MNO", Preu = 18000.0, ConductorId = "", NPlaces = 5, Portes = 5, Automatic = false, Consum = 6.2, Diesel = true, Cavalls = 100 },
                new Cotxe() { IdVehicle = "736", Marca = "Audi", Model = "A3", Any = 2022, Matricula = "1234 PQR", Preu = 25000.0, ConductorId = "", NPlaces = 5, Portes = 3, Automatic = false, Consum = 6.7, Diesel = false, Cavalls = 120 },
                new Cotxe() { IdVehicle = "737", Marca = "BMW", Model = "Sèrie 1", Any = 2022, Matricula = "5678 STU", Preu = 30000.0, ConductorId = "", NPlaces = 5, Portes = 5, Automatic = true, Consum = 5.5, Diesel = true, Cavalls = 130 },
                new Cotxe() { IdVehicle = "738", Marca = "Mercedes-Benz", Model = "Classe A", Any = 2022, Matricula = "9012 VWX", Preu = 35000.0, ConductorId = "", NPlaces = 5, Portes = 5, Automatic = true, Consum = 5.0, Diesel = false, Cavalls = 140 },
                new Cotxe() { IdVehicle = "741", Marca = "BMW", Model = "Serie 3", Any = 2022, Matricula = "1234BBC", Preu = 45000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 6.5, Diesel = true, Cavalls = 184 },
                new Cotxe() { IdVehicle = "742", Marca = "Audi", Model = "A4", Any = 2022, Matricula = "5678DEF", Preu = 35000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 6.0, Diesel = true, Cavalls = 150 },
                new Cotxe() { IdVehicle = "743", Marca = "Mercedes-Benz", Model = "Clase C", Any = 2022, Matricula = "9012GHI", Preu = 50000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 6.8, Diesel = true, Cavalls = 194 },
                new Cotxe() { IdVehicle = "745", Marca = "Ford", Model = "Focus", Any = 2022, Matricula = "7890MNK", Preu = 30000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 5.8, Diesel = true, Cavalls = 120 },
                new Cotxe() { IdVehicle = "746", Marca = "Peugeot", Model = "308", Any = 2022, Matricula = "1234PQR", Preu = 28000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 5.5, Diesel = true, Cavalls = 130 },
                new Cotxe() { IdVehicle = "747", Marca = "Renault", Model = "Megane", Any = 2022, Matricula = "5679STU", Preu = 27000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 5.9, Diesel = true, Cavalls = 128 },
                new Cotxe() { IdVehicle = "748", Marca = "Seat", Model = "Leon", Any = 2022, Matricula = "9012VWX", Preu = 29000.00, ConductorId = "", NPlaces = 5, Portes = 4, Automatic = true, Consum = 6.2, Diesel = true, Cavalls =110 },
                new Cotxe() { IdVehicle = "732", Marca = "Renault", Model = "Clio", Any = 2022, Matricula = "5678 DEF", Preu = 14000.0, ConductorId = "", NPlaces = 5, Portes = 5, Automatic = true, Consum = 5.8, Diesel = false, Cavalls = 90 },
                new Cotxe() { IdVehicle = "733", Marca = "Ford", Model = "Fiesta", Any = 2022, Matricula = "9012 GJI", Preu = 16000.0, ConductorId = "", NPlaces = 5, Portes = 3, Automatic = true, Consum = 6.0, Diesel = false, Cavalls = 95 },
            };

            return cotxes;
        }
        public void DesaCotxes(IEnumerable<Cotxe> cotxes)
        {
        }
        public IEnumerable<Furgoneta> ObtenFurgonetes()
        {
            List<Furgoneta> furgonetes = new List<Furgoneta>()
            {
                new Furgoneta() { IdVehicle = "94001", Marca = "Renault", Model = "Kangoo", Any = 2018, Matricula = "1234BCD", Preu = 15000, ConductorId = "", CapacitatCarrega = 500 },
                new Furgoneta() { IdVehicle = "94002", Marca = "Ford", Model = "Transit", Any = 2020, Matricula = "5678EFG", Preu = 25000, ConductorId = "", CapacitatCarrega = 750 },
                new Furgoneta() { IdVehicle = "94003", Marca = "Mercedes-Benz", Model = "Sprinter", Any = 2019, Matricula = "9012HIJ", Preu = 30000, ConductorId = "", CapacitatCarrega = 1000 },
                new Furgoneta() { IdVehicle = "94004", Marca = "Peugeot", Model = "Partner", Any = 2021, Matricula = "3456KLM", Preu = 18000, ConductorId = "", CapacitatCarrega = 600 },
                new Furgoneta() { IdVehicle = "94005", Marca = "Citroën", Model = "Berlingo", Any = 2017, Matricula = "7890NOP", Preu = 17000, ConductorId = "", CapacitatCarrega = 550 },
            };

            return furgonetes;
        }
        public void DesaFurgonetes(IEnumerable<Furgoneta> furgonetes)
        {
        }
        public IEnumerable<Moto> ObtenMotos()
        {
            List<Moto> motos = new List<Moto>()
            {
                new Moto() { IdVehicle = "761", Marca = "Yamaha", Model = "MT-07", Any = 2021, Matricula = "1234-ABC", Preu = 7000, ConductorId = "", Tipus = "Carretera", Cilindrada = 700, CapacitatMaleta = 20 },
                new Moto() { IdVehicle = "762", Marca = "Honda", Model = "CB500F", Any = 2022, Matricula = "5678-DEF", Preu = 6000, ConductorId = "", Tipus = "Carretera", Cilindrada = 500, CapacitatMaleta = 15 },
                new Moto() { IdVehicle = "763", Marca = "Suzuki", Model = "GSX-S750", Any = 2020, Matricula = "9012-GHI", Preu = 8000, ConductorId = "", Tipus = "Carretera", Cilindrada = 750, CapacitatMaleta = 25 },
                new Moto() { IdVehicle = "764", Marca = "Kawasaki", Model = "Z650", Any = 2023, Matricula = "3456-JKL", Preu = 6500, ConductorId = "", Tipus = "Carretera", Cilindrada = 650, CapacitatMaleta = 10 },
                new Moto() { IdVehicle = "765", Marca = "BMW", Model = "F750GS", Any = 2021, Matricula = "7890-MNO", Preu = 10000, ConductorId = "", Tipus = "Aventura", Cilindrada = 750, CapacitatMaleta = 30 },
                new Moto() { IdVehicle = "766", Marca = "Ducati", Model = "Monster", Any = 2020, Matricula = "2345-PQR", Preu = 9000, ConductorId = "", Tipus = "Carretera", Cilindrada = 821, CapacitatMaleta = 0 },
                new Moto() { IdVehicle = "767", Marca = "Harley-Davidson", Model = "Fat Bob", Any = 2022, Matricula = "6789-STU", Preu = 15000, ConductorId = "", Tipus = "Custom", Cilindrada = 114, CapacitatMaleta = 5 },
                new Moto() { IdVehicle = "768", Marca = "Triumph", Model = "Street Triple", Any = 2023, Matricula = "1234-VWX", Preu = 8500, ConductorId = "", Tipus = "Carretera", Cilindrada = 765, CapacitatMaleta = 15 },
                new Moto() { IdVehicle = "769", Marca = "KTM", Model = "Super Duke R", Any = 2022, Matricula = "5678-YZ1", Preu = 12000, ConductorId = "", Tipus = "Carretera", Cilindrada = 1290, CapacitatMaleta = 0 },
            };

            return motos;
        }
        public void DesaMotos(IEnumerable<Moto> furgonetes)
        {
        }

        #endregion

        #region Persones
        public IEnumerable<Directiu> ObtenDirectius()
        {
            List<Directiu> directius = new()
            {
                new Directiu() { IdPersona = "001", IdEmpleat = "001", Nom = "Juan", Edat = 45, Adreca = "Calle Mayor, 10", Ciutat = "Barcelona", CodiPostal = "08001", Carrec = "Director General", DataContracte = new DateTime(2010,1,1), Salari = 80000, Departament = "Dirección General", SubordinatsId = new List<String>() },
                new Directiu() { IdPersona = "002", IdEmpleat = "002", Nom = "Ana", Edat = 50, Adreca = "Calle Principal, 20", Ciutat = "Madrid", CodiPostal = "28001", Carrec = "Directora Financiera", DataContracte = new DateTime(2012,1,1), Salari = 75000, Departament = "Finanzas", SubordinatsId = new List<String>() },
                new Directiu() { IdPersona = "003", IdEmpleat = "003", Nom = "Pedro", Edat = 55, Adreca = "Calle del Sol, 5", Ciutat = "Valencia", CodiPostal = "46001", Carrec = "Director Comercial", DataContracte = new DateTime(2015,1,1), Salari = 70000, Departament = "Ventas", SubordinatsId = new List<String>() }
            };
            return directius;
        }
        public void DesaDirectius(IEnumerable<Directiu> directius)
        {
        }
        public IEnumerable<Tecnic> ObtenTecnics()
        {
            List<Tecnic> tecnics = new()
            {
                new Tecnic() { IdPersona = "TEC001", Nom = "Laura", Edat = 32, Adreca = "Carrer Gran Via 123", Ciutat = "Barcelona", CodiPostal = "08001", IdEmpleat = "EMP001", Carrec = "Tècnic", DataContracte = new DateTime(2022,1,1), Salari = 25000, Supervisor = null, VehiclesId = new List<String>(), Fix = true, Especialitat = "Informàtica" },
                new Tecnic() { IdPersona = "TEC002", Nom = "David", Edat = 28, Adreca = "Carrer de Pau Claris 98", Ciutat = "Barcelona", CodiPostal = "08009", IdEmpleat = "EMP002", Carrec = "Tècnic", DataContracte = new DateTime(2010,5,1), Salari = 22000, Supervisor = null, VehiclesId = new List<String>(), Fix = false, Especialitat = "Mecànica" },
                new Tecnic() { IdPersona = "TEC003", Nom = "Maria", Edat = 35, Adreca = "Carrer de Sant Antoni 20", Ciutat = "Barcelona", CodiPostal = "08015", IdEmpleat = "EMP003", Carrec = "Tècnic", DataContracte = new DateTime(2019,3,1), Salari = 28000, Supervisor = null, VehiclesId = new List<String>(), Fix = true, Especialitat = "Electricitat" },
                new Tecnic() { IdPersona = "TEC004", Nom = "Daniel", Edat = 30, Adreca = "Carrer del Comte Borrell 92", Ciutat = "Barcelona", CodiPostal = "08015", IdEmpleat = "EMP004", Carrec = "Tècnic", DataContracte = new DateTime(2018,2,1), Salari = 30000, Supervisor = null, VehiclesId = new List<String>(), Fix = false, Especialitat = "Fotografia" },
                new Tecnic() { IdPersona = "TEC005", Nom = "Anna", Edat = 29, Adreca = "Carrer de Valencia 142", Ciutat = "Barcelona", CodiPostal = "08011", IdEmpleat = "EMP005", Carrec = "Tècnic", DataContracte = new DateTime(2017,1,1), Salari = 32000, Supervisor = null, VehiclesId = new List<String>(), Fix = true, Especialitat = "Disseny gràfic" }
            };
            return tecnics;
        }
        public void DesaTecnics(IEnumerable<Tecnic> tecnics)
        {
        }
        public IEnumerable<Comercial> ObtenComercials()
        {
            List<Comercial> comercials = new() {
                new Comercial() { IdEmpleat = "C001", Nom = "Laura", Edat = 28, Adreca = "Carrer dels Comercials 1", Ciutat = "Barcelona", CodiPostal = "08001", Carrec = "Comercial", DataContracte = new DateTime(2020,1,1), Salari = 2000, Seccio = "Ropa", PercentatgeDeComissio = 10, Fix = false, IdPersona = "P050"},
                new Comercial() { IdEmpleat = "C002", Nom = "Pedro", Edat = 32, Adreca = "Carrer dels Comercials 2", Ciutat = "Madrid", CodiPostal = "28001", Carrec = "Comercial", DataContracte = new DateTime(2018,5,1), Salari = 2200, Seccio = "Electronica", PercentatgeDeComissio = 8, Fix = true, IdPersona = "P051"},
                new Comercial() { IdEmpleat = "C003", Nom = "Sara", Edat = 25, Adreca = "Carrer dels Comercials 3", Ciutat = "Barcelona", CodiPostal = "08009", Carrec = "Comercial", DataContracte = new DateTime(2022,1,1), Salari = 1800, Seccio = "Juguetes", PercentatgeDeComissio = 12, Fix = false, IdPersona = "P052"},
                new Comercial() { IdEmpleat = "C004", Nom = "David", Edat = 30, Adreca = "Carrer dels Comercials 4", Ciutat = "Valencia", CodiPostal = "08009", Carrec = "Comercial", DataContracte = new DateTime(2021,8,1), Salari = 2100, Seccio = "Hogar", PercentatgeDeComissio = 9, Fix = true, IdPersona = "P053" },
                new Comercial() { IdEmpleat = "C005", Nom = "Lucia", Edat = 26, Adreca = "Carrer dels Comercials 5", Ciutat = "Barcelona", CodiPostal = "08004", Carrec = "Comercial", DataContracte = new DateTime(2017,2,1), Salari = 2300, Seccio = "Deportes", PercentatgeDeComissio = 7, Fix = false, IdPersona = "P054" }
            };
            return comercials;
        }
        public void DesaComercials(IEnumerable<Comercial> comercials)
        {
        }
        public IEnumerable<Client> ObtenClients()
        {
            List<Client> llistaClients = new()
            {
                new Client() { IdPersona = "CL001", IdClient = "C001", Nom = "Ana López", Edat = 28, Adreca = "C/ Mayor, 12", Ciutat = "Barcelona", CodiPostal = "08001", Email = "ana.lopez@gmail.com", Telefon = "612345678", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL002", IdClient = "C002", Nom = "Carlos García", Edat = 35, Adreca = "C/ Gran Vía, 23", Ciutat = "Madrid", CodiPostal = "28013", Email = "carlos.garcia@hotmail.com", Telefon = "612345679", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL003", IdClient = "C003", Nom = "Laura Pérez", Edat = 42, Adreca = "C/ Valencia, 45", Ciutat = "Valencia", CodiPostal = "46001", Email = "laura.perez@yahoo.es", Telefon = "612345680", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL004", IdClient = "C004", Nom = "Miguel Fernández", Edat = 31, Adreca = "C/ Paseo de Gracia, 67", Ciutat = "Barcelona", CodiPostal = "08008", Email = "miguel.fernandez@gmail.com", Telefon = "612345681", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL005", IdClient = "C005", Nom = "Isabel Sánchez", Edat = 45, Adreca = "C/ Alcalá, 89", Ciutat = "Madrid", CodiPostal = "28009", Email = "isabel.sanchez@yahoo.es", Telefon = "612345682", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL009", IdClient = "C009", Nom = "Maria Rodriguez", Edat = 25, Adreca = "C/ Valencia, 17", Ciutat = "Barcelona", CodiPostal = "08002", Email = "maria.rodriguez@gmail.com", Telefon = "612345678", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL010", IdClient = "C010", Nom = "Juan Martinez", Edat = 40, Adreca = "C/ Gran Vía, 34", Ciutat = "Madrid", CodiPostal = "28013", Email = "juan.martinez@hotmail.com", Telefon = "612345679", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL011", IdClient = "C011", Nom = "Elena Garcia", Edat = 30, Adreca = "C/ Valencia, 45", Ciutat = "Valencia", CodiPostal = "46001", Email = "elena.garcia@yahoo.es", Telefon = "612345680", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL012", IdClient = "C012", Nom = "Javier Pérez", Edat = 35, Adreca = "C/ Paseo de Gracia, 89", Ciutat = "Barcelona", CodiPostal = "08008", Email = "javier.perez@gmail.com", Telefon = "612345681", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL013", IdClient = "C013", Nom = "Laura Sánchez", Edat = 27, Adreca = "C/ Alcalá, 67", Ciutat = "Madrid", CodiPostal = "28009", Email = "laura.sanchez@yahoo.es", Telefon = "612345682", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL006", IdClient = "C006", Nom = "Antonio Fernández", Edat = 45, Adreca = "C/ Mayor, 56", Ciutat = "Sevilla", CodiPostal = "41001", Email = "antonio.fernandez@gmail.com", Telefon = "612345683", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL007", IdClient = "C007", Nom = "Sara López", Edat = 32, Adreca = "C/ Gran Vía, 12", Ciutat = "Valencia", CodiPostal = "46002", Email = "sara.lopez@hotmail.com", Telefon = "612345684", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL008", IdClient = "C008", Nom = "Pedro Torres", Edat = 38, Adreca = "C/ Valencia, 78", Ciutat = "Barcelona", CodiPostal = "08012", Email = "pedro.torres@yahoo.es", Telefon = "612345685", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL014", IdClient = "C014", Nom = "Júlia Garcia", Edat = 29, Adreca = "C/ Rambla Catalunya, 12", Ciutat = "Barcelona", CodiPostal = "08001", Email = "julia.garcia@gmail.com", Telefon = "612345678", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL015", IdClient = "C015", Nom = "Marc Torres", Edat = 35, Adreca = "C/ Passeig de Gràcia, 23", Ciutat = "Barcelona", CodiPostal = "28013", Email = "marc.torres@hotmail.com", Telefon = "612345679", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL016", IdClient = "C016", Nom = "Laia Fernández", Edat = 42, Adreca = "C/ Diagonal, 45", Ciutat = "Barcelona", CodiPostal = "46001", Email = "laia.fernandez@yahoo.es", Telefon = "612345680", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL017", IdClient = "C017", Nom = "Anna Garcia Soler", Edat = 31, Adreca = "C/ de la Font, 14", Ciutat = "Barcelona", CodiPostal = "08001", Email = "anna.garcia@gmail.com", Telefon = "612345678", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL018", IdClient = "C018", Nom = "Joan Martínez Vila", Edat = 45, Adreca = "C/ de la Rambla, 23", Ciutat = "Barcelona", CodiPostal = "08002", Email = "joan.martinez@hotmail.com", Telefon = "612345679", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL019", IdClient = "C019", Nom = "Laura Puig Ventura", Edat = 28, Adreca = "C/ de la Mercè, 45", Ciutat = "Girona", CodiPostal = "17001", Email = "laura.puig@yahoo.es", Telefon = "612345680", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL020", IdClient = "C020", Nom = "Pau Miralles Ros", Edat = 39, Adreca = "C/ del Pi, 67", Ciutat = "Tarragona", CodiPostal = "43001", Email = "pau.miralles@gmail.com", Telefon = "612345681", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL021", IdClient = "C021", Nom = "Carla Roca Pujol", Edat = 52, Adreca = "C/ de la Llibertat, 89", Ciutat = "Lleida", CodiPostal = "25001", Email = "carla.roca@yahoo.es", Telefon = "612345682", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL022", IdClient = "C022", Nom = "Arnau Serra Lluch", Edat = 31, Adreca = "C/ del Bisbe, 12", Ciutat = "Barcelona", CodiPostal = "08003", Email = "arnau.serra@gmail.com", Telefon = "612345683", ComandesId = new List<String>() },
                new Client() { IdPersona = "CL023", IdClient = "C023", Nom = "Júlia Castelló Ribes", Edat = 48, Adreca = "C/ de la Pau, 37", Ciutat = "Girona", CodiPostal = "17002", Email = "julia.castello@hotmail.com", Telefon = "612345684", ComandesId = new List<String>() }
            };
            return llistaClients;
        }
        public void DesaClients(IEnumerable<Client> Clients)
        {
        }

        public IEnumerable<Empresa> ObtenEmpresa()
        {
            throw new NotImplementedException();
        }

        public void DesaEmpresa(Empresa empresa)
        {
        }


        /// <summary>
        /// Mètode que genera tantes comandes com nComandes indiqui. A partir d'un random es determina quins seran Client, Comercial, línies de productes i unitats que constaran. A més generarà tota informació rellevant sobre les comandes per posteriorment processar-les l'empresa. 
        /// </summary>
        /// <param name="nComandes">nombre de comandes que volem generar</param>
        /// <param name="minLinies">límit inferior de línies que ha de tenir la comanda.</param>
        /// <param name="maxLinies">límit superior de línies que ha de tenir la comanda.</param>
        /// <param name="maxUnitats">quantitat màxima de productes que pot tenir cada línia.</param>
        public IEnumerable<Comanda> ObtenComandes()
        {
            List<Comanda> comandes = new List<Comanda>();
            return comandes;
        }

        public void DesaComandes(IEnumerable<Comanda> comandes)
        { 
        }

        public void DesaVehicles(IEnumerable<Vehicle> vehicles)
        {
            throw new NotImplementedException();
        }

        public void DesaEmpleats(IEnumerable<Empleat> empleats)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
