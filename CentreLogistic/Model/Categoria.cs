namespace CentreLogistic.Model
{
    /// <summary>
    /// Classe per al manegament de les categories
    /// </summary>
    public class Categoria
    {
        private static int autoincrement = 0;

        #region atributs/camps
        private string idCategoria;
        private string nom;
        private string descripcio;
        private List<String> productesId;

        #endregion
        #region Getters & Setter

        /// <summary>
        /// Assigna o retorna l'Id de Categoria
        /// </summary>
        public string IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }


        public string Descripcio
        {
            get => descripcio;
            set => descripcio = value;
        }
        public List<String> ProductesId
        {
            get => productesId;
            set => productesId = value;
        }
        public string Nom
        {
            get => nom;
            set => nom = value;
        }
        #endregion

        #region Constructors
        public Categoria()
        {
            ProductesId = new List<String>();
        }
        #endregion
        #region SobreEscriptures
        public override string ToString()
        {
            return $"{IdCategoria} - {Nom}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return this == null;
            else if (!(obj is Categoria))
                return false;
            else
            {
                Categoria altreObj = obj as Categoria;
                return IdCategoria == altreObj.IdCategoria;
            }

        }


        public override int GetHashCode()
        {
            return IdCategoria.GetHashCode();
        }
        #endregion

        #region Mètodes
        public void CreaNovaID()
        {
            autoincrement++;
            IdCategoria = autoincrement.ToString();
        }

        #endregion
    }


}