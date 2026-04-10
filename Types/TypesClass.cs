/*
Programmeur : Brandon Pinet et Olivier Roussel
But : Une couche métier que va permet d'initialiser les tableaux de Types et Styles
Solution: VentesMeubles.sln 
Projet: Types.csproj
Classe : TypesClass.cs
Date : Le 26-27 fevrier 2026 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TypesClass
    {
        #region Déclaration des tableaux

        private string[] tTypes;
        private string[] tStyles;

        #endregion

        #region Enumeration
        /// <summary>
        /// Enumeration pour choisir quel tableau sera utiliser pour initialiser les ComboBox.
        /// </summary>
        public enum CodeTypes
        {
            Types,
            Styles
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public TypesClass()
        {
            InitTypes();
            InitStyles();
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialisateur pour le tableau Types
        /// </summary>
        private void InitTypes()
        {
            tTypes = new string[4] {"Chaise","Sofa","Table","Armoire"};
        }

        /// <summary>
        /// Initialisateur pour le tableau Styles
        /// </summary>
        private void InitStyles()
        {
            tStyles = new string[6] {"Moderne","Gothique","Industriel","Rustique","Antiquité","International"};
        }

        #endregion
        #region Obtenir les Types
        /// <summary>
        /// Méthode pour obtenir le tableau qui va être utiliser pour le ComboBox
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Le tableau qui va être utiliser</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string[] GetTypes(CodeTypes type)
        {
            switch (type)
            {
                case CodeTypes.Types:
                    return tTypes;
                case CodeTypes.Styles:
                    return tStyles;
                default:
                    throw new ArgumentOutOfRangeException("Données invalides");
            }
        }
        #endregion

    }
}
