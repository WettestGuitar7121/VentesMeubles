/*
Programmeur : Brandon Pinet et Olivier Roussel
But : Une couche métier que va permettre la validations des champs du formulaire,
avoir un Getter pour recevoir le prix dans le formulaire et avoir une méthode pour enregistrer.
Solution: VentesMeubles.sln 
Projet: Transaction.csproj
Classe : TransactionClass.cs
Date : Le 26-27 fevrier 2026 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;



namespace Transaction
{
    /// <summary>
    /// Couche métier : La classe de transaction
    /// </summary>
    public class TransactionClass
    {
        #region Declaration des champs priver

        private int idInt;
        private string nomStr;

        private string prenomStr;
        private string adresseStr;
        private string codePostalStr;
        private string telephoneStr;
        private string typeMeubleStr;
        private string styleMeubleStr;

        private string manifacturierStr;
        private string tailleStr;
    
        private DateTime dateLivraisonDateTime;
        private decimal prixDecimal;

        #endregion

        #region Déclaration des tableaux
        string[] tTailles;
        string[] tManifacturiers;
        decimal[,] tPrix;
        #endregion

        #region Initialisation des tableaux

        /// <summary>
        /// Initialisation du tableau de 1er dimension de Tailles.
        /// </summary>
        private void InitTaille()
        {
            tTailles = new string[4] { "7 Pied", "5 Pied", "4 Pied", "3 Pied" };
        }

        /// <summary>
        /// Initialisation du tableau de 1er dimension de Manifacturiers.
        /// </summary>
        private void InitManifacturier()
        {
            tManifacturiers = new string[4] { "Thomas's Homemade Furniture", "Jimmy's Antiques", "Lucas’s Fine Woodworks", "Alexis's Timeless Treasures" };
        }

        /// <summary>
        /// Initialisation du tableau de 2e dimension de Prix.
        /// </summary>
        private void InitPrix()
        {
            tPrix = new decimal[4, 4]
            {
                {500.00M, 300.00M, 200.00M, 120.00M},
                {2000.00M, 1850.00M, 1500.00M, 2200.00M},
                {600.00M, 350.00M, 250.00M, 149.99M},
                {999.99M, 899.99M, 749.99M, 649.99M}
            };
        }
        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public TransactionClass()
        {
            InitTaille();
            InitManifacturier();
            InitPrix();
        }

        /// <summary>
        /// Constructeur par paramètres
        /// </summary>
        /// <param name="nomStr"></param>
        /// <param name="prenomStr"></param>
        /// <param name="adresseStr"></param>
        /// <param name="codePostal"></param>
        /// <param name="telephoneStr"></param>
        /// <param name="typeMeubleStr"></param>
        /// <param name="styleMeubleStr"></param>
        /// <param name="manifacturierStr"></param>
        /// <param name="tailleStr"></param>
        /// <param name="dateLivraisonDateTime"></param>
        /// <param name="prixDecimal"></param>
        public TransactionClass(string nomStr, string prenomStr, string adresseStr, string codePostal, string telephoneStr, string typeMeubleStr, string styleMeubleStr, string manifacturierStr, string tailleStr, DateTime dateLivraisonDateTime, decimal prixDecimal)
        {
            Nom = nomStr;
            Prenom = prenomStr;
            Adresse = adresseStr;
            CodePostal = codePostal;
            Telephone = telephoneStr;
            Type = typeMeubleStr;
            Style = styleMeubleStr;
            Manifacturier = manifacturierStr;
            Taille = telephoneStr;
            DateLivraison = dateLivraisonDateTime;
            Prix = prixDecimal;
        
        }

        #endregion

        #region Manifacturiers des meubles

        /// <summary>
        /// Getter pour le tableau des Manifacturiers
        /// </summary>
        /// <returns>tManifacturiers</returns>
        public string[] GetManifacturiers()
            { return tManifacturiers; }

        #endregion

        #region Tailles des meubles

    /// <summary>
    /// Getter pour le tableau des Tailles
    /// </summary>
    /// <returns>tTailles</returns>
        public string[] GetTailles()
            { return tTailles; }

        #endregion

        #region Prix des meubles

        /// <summary>
        /// Getter pour le tableau des Prix qui utilise les index de manifacturier et taille pour trouver les prix
        /// </summary>
        /// <param name="manifacturier"></param>
        /// <param name="taille"></param>
        /// <returns>tPrix[manifacturier,taille]</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal GetPrix(int manifacturier, int taille)
        {
            if (manifacturier >= tManifacturiers.GetLowerBound(0) && manifacturier <= tManifacturiers.GetUpperBound(0))
            {
                if (taille >= tTailles.GetLowerBound(0) && taille <= tTailles.GetUpperBound(0))
                {
                    return tPrix[manifacturier, taille];
                }
                else         // utiliser general class pour argument exceptions

                    // VERIFIER AVEC PROF SI C NECESSAIRE DE METTRE LE VERIFICATIONS ICI
                    throw new ArgumentOutOfRangeException("La valeur de la taille n'est pas bonne...");
            }
                else
                    throw new ArgumentOutOfRangeException("La manifactorier n'est pas valide...");
        }

        /// <summary>
        /// Getter pour le tableau des Prix qui utilise les noms de manifacturier et taille pour trouver les prix
        /// </summary>
        /// <param name="manifacturier"></param>
        /// <param name="taille"></param>
        /// <returns>tPrix[manifacturier,taille]</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal GetPrix(string manifacturier, string taille)
        {
            int manifacturierInt, tailleInt;

            manifacturierInt=Array.IndexOf(tManifacturiers, manifacturier);
            tailleInt=Array.IndexOf(tTailles, taille);

            if (manifacturierInt != -1)
                if (tailleInt != -1)
                    return tPrix[manifacturierInt, tailleInt];
                else
                    throw new ArgumentException("La valeur de la taille n'est pas bonne...");
            else throw new ArgumentException("La manifactorier n'est pas valide...");

        }
        #endregion
        
        #region Getters/Setters


        /// <summary>
        /// Le Getter de l'id de la transaction
        /// </summary>
        public int Id
        {
            get {return idInt;}
        }


        /// <summary>
        /// Le Getter et Setter pour le nom de famille du client
        /// </summary>
        public string Nom
        {
            get { return nomStr;}
            set { nomStr = value;}
        }

        /// <summary>
        /// Le Getter et Setter pour le nom du client
        /// </summary>
        public string Prenom
        {
            get { return prenomStr; }
            set { prenomStr = value;}
        }

        /// <summary>
        /// Le Getter et Setter pour l'adresse du client
        /// </summary>
        public string Adresse
        {
            get { return adresseStr; }
            set { adresseStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour le code postal du client
        /// </summary>
        public string CodePostal
        {
            get { return codePostalStr; }
            set { codePostalStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour le telephone du client
        /// </summary>
        public string Telephone
        {
            get { return telephoneStr; }
            set { telephoneStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour le type de meuble que le client choisi
        /// </summary>
        public string Type
        {
            get { return typeMeubleStr; }
            set { typeMeubleStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour le style du meuble que le client choisi
        /// </summary>
        public string Style
        {
            get { return styleMeubleStr; }
            set { styleMeubleStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour le manifacturier du meuble choisi
        /// </summary>
        public string Manifacturier
        {
            get { return manifacturierStr; }
            set { manifacturierStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour la taille du meuble choisi
        /// </summary>
        public string Taille
        {
            get { return tailleStr; }
            set { tailleStr = value; }
        }

        /// <summary>
        /// Le Getter et Setter pour la date de la livraison
        /// </summary>
        public DateTime DateLivraison
        {
            get { return dateLivraisonDateTime; }
            set { dateLivraisonDateTime = value; }
        }

        public decimal Prix
        {
            get { return prixDecimal; }
            set { prixDecimal = value; }
        }
        #endregion
        #region Enregistrer
        public void Enregister()
        {
            Console.WriteLine(Nom+ Prenom + Adresse + CodePostal + Telephone + Type + Style + Manifacturier + Taille + DateLivraison + Prix);
        }
        public void Enregister(string nomStr, string prenomStr, string adresseStr, string codePostal, string telephoneStr, string typeMeubleStr, string styleMeubleStr, string manifacturierStr, string tailleStr, DateTime dateLivraisonDateTime, decimal prixDecimal)
        {
            Nom = nomStr;
            Prenom = prenomStr;
            Adresse = adresseStr;
            CodePostal = codePostal;
            Telephone = telephoneStr;
            Type = typeMeubleStr;
            Style = styleMeubleStr;
            Manifacturier = manifacturierStr;
            Taille = tailleStr;

            DateLivraison = dateLivraisonDateTime;
            Prix = prixDecimal;

            Enregister();
        }
        #endregion
    }
}
