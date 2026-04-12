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
        #region Declaration des champs privées

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

        private DateTime datePaiementDateTime;

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
        public TransactionClass(string nomStr, string prenomStr, string adresseStr, string codePostal, string telephoneStr, string typeMeubleStr, string styleMeubleStr, string manifacturierStr, string tailleStr, DateTime dateLivraisonDateTime, decimal prixDecimal) : this()
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
            set {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        nomStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.NomObligatoire]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.NomObligatoire]);           
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le nom du client
        /// </summary>
        public string Prenom
        {
            get { return prenomStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        prenomStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.PrenomObligatoire]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.PrenomObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour l'adresse du client
        /// </summary>
        public string Adresse
        {
            get { return adresseStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        adresseStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.AdresseObligatoire]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.AdresseObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le code postal du client
        /// </summary>
        public string CodePostal
        {
            get { return codePostalStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        codePostalStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.CodePostalObligatoire]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.CodePostalObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le telephone du client
        /// </summary>
        public string Telephone
        {
            get { return telephoneStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        telephoneStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TelephoneObligatoire]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TelephoneObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le type de meuble que le client choisi
        /// </summary>
        public string Type
        {
            get { return typeMeubleStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        typeMeubleStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TypeInvalide]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TypeInvalide]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le style du meuble que le client choisi
        /// </summary>
        public string Style
        {
            get { return styleMeubleStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (value != String.Empty)
                    {
                        styleMeubleStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.StyleInvalide]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.StyleInvalide]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le manifacturier du meuble choisi
        /// </summary>
        public string Manifacturier
        {
            get { return manifacturierStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (Array.IndexOf(tManifacturiers, value) != -1) 
                    {
                        manifacturierStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.ManifacturierObligatoire]);
                }
                else
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodeErreurs.ManifacturierObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour la taille du meuble choisi
        /// </summary>
        public string Taille
        {
            get { return tailleStr; }
            set
            {

                if (value != null)
                {
                    value = value.Trim();

                    if (Array.IndexOf(tTailles, value) != -1)
                    {
                        tailleStr = value;
                    }
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TailleInvalide]);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.TailleObligatoire]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour la date de la livraison
        /// </summary>
        public DateTime DateLivraison
        {
            get { return dateLivraisonDateTime; }
            set
            {
                if (value >= DateTime.Now.AddDays(-15) &&
                    value <= DateTime.Now.AddDays(15))
                {
                    dateLivraisonDateTime = value;
                    datePaiementDateTime = dateLivraisonDateTime.AddDays(30);
                }
                else
                    throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.DateLivraisonInvalide]);
            }
        }

        /// <summary>
        /// Le Getter et Setter pour le prix
        /// </summary>
        public decimal Prix
        {
            get { return prixDecimal; }
            set {
                if (value > 0.0M)
                {
                    if (this.Manifacturier != string.Empty && this.Taille != string.Empty)
                    {
                                                                
                       int indiceManifacturier = Array.IndexOf(tManifacturiers, this.Manifacturier);
                       int indiceTaille = Array.IndexOf(tTailles, this.Taille);
                        Console.WriteLine(indiceManifacturier + Environment.NewLine + indiceTaille);

                        if (tPrix[indiceManifacturier, indiceTaille] == value)
                        {
                            prixDecimal = value;
                        }
                        else
                            throw new ArgumentException(tMessagesErreurs[(int)CodeErreurs.PrixInvalide]);

                    }
                    else
                        throw new ArgumentNullException(tMessagesErreurs[(int)CodeErreurs.PrixObligatoire]);

                }
                else
                    throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodeErreurs.PrixInvalide]);
            }
        }

        public DateTime DatePaiement
        {
            get { return datePaiementDateTime; }
           
        }

        #endregion

        #region Enregistrer
        /// <summary>
        /// Méthode pour enregistrer les informations d'achat
        /// </summary>
        public void Enregister()
        {
            Console.WriteLine(Nom+ Prenom + Adresse + CodePostal + Telephone + Type + Style + Manifacturier + Taille + DateLivraison + Prix);
        }

        /// <summary>
        /// Méthode pour enregistrer les informations d'achat avec paramètres
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

        #region Messages d'erreurs

        private enum CodeErreurs 
        {
        NomObligatoire,
        PrenomObligatoire,
        AdresseObligatoire,
        CodePostalObligatoire,
        CodePostalInvalide,
        TelephoneObligatoire,
        TelephoneInvalide,
        TypeInvalide,
        StyleInvalide,
        DateLivraisonInvalide,
        ErreurIndeterminee,
        ManifacturierObligatoire,
        TailleInvalide,
        TailleObligatoire,
        PrixObligatoire,
        PrixInvalide
        }

        private string[] tMessagesErreurs = new string[10];

        private void InitMessagesErreurs()
        {
            tMessagesErreurs[(int)CodeErreurs.NomObligatoire] = "Le nom est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.PrenomObligatoire] = "Le prénom est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.AdresseObligatoire] = "L'Adresse est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.CodePostalObligatoire] = "Le code postal est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.CodePostalInvalide] = "le code postal est invalide";
            tMessagesErreurs[(int)CodeErreurs.TelephoneObligatoire] = "Le téléphone est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.TelephoneInvalide] = "Le téléphone est invalide";
            tMessagesErreurs[(int)CodeErreurs.TypeInvalide] = "Le type est invalide";
            tMessagesErreurs[(int)CodeErreurs.StyleInvalide] = "Le style est invalide";
            tMessagesErreurs[(int)CodeErreurs.DateLivraisonInvalide] = "La date de livraison est invalide";
            tMessagesErreurs[(int)CodeErreurs.ErreurIndeterminee] = "Erreur Indéterminée";
            tMessagesErreurs[(int)CodeErreurs.ManifacturierObligatoire] = "Le Manifacturier est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.TailleInvalide] = "La Taille est invalide";
            tMessagesErreurs[(int)CodeErreurs.TailleObligatoire] = "La Taille est obligatoire";
            tMessagesErreurs[(int)CodeErreurs.PrixObligatoire] = "Un Manifacturier et une Taille sont obligatoires";
            tMessagesErreurs[(int)CodeErreurs.PrixInvalide] = "Le Manifacturier et la Taille sont invalides";

        }

        #endregion
    }
}
