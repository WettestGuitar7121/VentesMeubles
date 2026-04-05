/*
Programmeur : Brandon Pinet et Olivier Roussel
But : Un application pour la saisie d'un transaction d'une compagnie nommé Thomas's Old Furnitures
Solution: VentesMeubles.sln 
Projet: VentesMeubles.csproj
Classe : VentesMeublesForm.cs, VentesMeublesGeneraleClass.cs et TransactionClass.cs
Date : Le 26-27 fevrier 2026 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Transaction
{
    /// <summary>
    /// Couche métier : La classe de transaction
    /// </summary>
    public class TransactionClass
    {

        #region Déclaration des tableaux
        string[] tailles;
        string[] manifactoriers;
        decimal[,] prix;
        #endregion

        #region Initialisation des tableaux

        private void InitTaille()
        {
            tailles = new string[4] { "7 Pied", "5 Pied", "4 Pied", "3 Pied" };
        }

        private void InitManifacturier()
        {
            manifactoriers = new string[4] { "Thomas's Homemade Furniture", "Jimmy's Antiques", "Lucas’s Fine Woodworks", "Alexis's Timeless Treasures" };
        }

        private void InitPrix()
        {
            prix = new decimal[4, 4]
            {
                {500.00M, 300.00M, 200.00M, 120.00M},
                {2000.00M, 1850.00M, 1500.00M, 2200.00M},
                {600.00M, 350.00M, 250.00M, 149.99M},
                {999.99M, 899.99M, 749.99M, 649.99M}
            };
        }
        #endregion

        #region Constructeur
        public TransactionClass()
        {
            InitTaille();
            InitManifacturier();
            InitPrix();
        }
        

        #endregion

        #region Manifacturiers des meubles

        public string[] GetManifacturiers()
            { return manifactoriers; }

        #endregion

        #region Tailles des meubles
    
        public string[] GetTailles()
            { return tailles; }

        #endregion

        #region Prix des meubles

        public decimal GetPrix(int manifactorier, int taille)
        {
            if (manifactorier >= manifactoriers.GetLowerBound(0) && manifactorier <= manifactoriers.GetUpperBound(0))
            {
                if (taille >= tailles.GetLowerBound(0) && taille <= tailles.GetUpperBound(0))
                {
                    return prix[manifactorier, taille];
                }
                else         // utiliser general class pour argument exceptions
                    throw new ArgumentOutOfRangeException("La valeur de la taille n'est pas bonne...");
            }
                else
                    throw new ArgumentOutOfRangeException("La manifactorier n'est pas valide...");
        }
        #endregion
    }
}
