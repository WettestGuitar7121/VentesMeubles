using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentesMeubles
{
    /// <summary>
    /// Classe générale dans la couche de présentation pour initialiser les messages d'erreurs du programme.
    /// </summary>
    internal class VentesMeublesGeneraleClass
    {
        #region Énumération
        public enum CodesErreurs
        {
            ErreurManifacturier,
            ErreurTaille,
            ErreurPrix,
            ErreurIndeterminee
        }
        #endregion

        #region Déclaration

        public static string[] tMessages = new string[4];


        #endregion

        #region Initialisation

        public static void InitMessages()
        {
            tMessages[(int)CodesErreurs.ErreurManifacturier] = "Erreur au niveau du manifacturier.";
            tMessages[(int)CodesErreurs.ErreurTaille] = "Erreur au niveau de la taille.";
            tMessages[(int)CodesErreurs.ErreurPrix] = "Erreur au niveau du prix.";
            tMessages[(int)CodesErreurs.ErreurIndeterminee] = "Erreur indéterminée. Veuillez joindre la personne ressource.";
        }

        #endregion
    }

}
