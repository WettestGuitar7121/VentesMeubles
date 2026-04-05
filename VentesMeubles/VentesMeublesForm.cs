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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using g = VentesMeubles.VentesMeublesGeneraleClass;
using ce = VentesMeubles.VentesMeublesGeneraleClass.CodesErreurs;

namespace VentesMeubles
{
 
    /// <summary>
    /// Les saisies d'une transaction
    /// </summary>xzczxczxczxc
    
    public partial class VentesMeublesForm : Form
    {
        #region Déclaration des membres privées

        #endregion

        #region Constructeurs
        public VentesMeublesForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Initialisation

        #endregion

        #region Obtenir le prix

        #endregion

        #region Quitter
        private void quitterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void VentesMeublesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
