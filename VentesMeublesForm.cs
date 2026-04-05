using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentesMeubles
{
 
    /// <summary>
    /// Les saisies d'une transaction
    /// </summary>
    
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
    }
}
