/*

Programmeur : Brandon Pinet et Olivier Roussel
But : Un application pour la saisie d'un transaction d'une compagnie nommé Thomas's Old Furnitures
Solution: VentesMeubles.sln 
Projet: VentesMeubles.csproj
Classe : VentesMeublesForm.cs
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
using Transaction;
using Types;
using static Types.TypesClass;
using ct = Types.TypesClass.CodeTypes;
using ce = VentesMeubles.VentesMeublesGeneraleClass.CodesErreurs;
using g = VentesMeubles.VentesMeublesGeneraleClass;

namespace VentesMeubles
{
 
    /// <summary>
    /// Les saisies d'une transaction
    /// </summary>xzczxczxczxc
    
    public partial class VentesMeublesForm : Form
    {
        #region Déclaration des membres privées
        
        TransactionClass oTrans;
        TypesClass oTypes;

        #endregion

        #region Constructeurs
        public VentesMeublesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Initialisation
        private void VentesMeublesForm_Load(object sender, EventArgs e)
        {
            g.InitMessages();

            try
            {
                oTrans = new TransactionClass();

                manifacturierTransactionGroupBoxComboBox.Items.AddRange(oTrans.GetManifacturiers());
                manifacturierTransactionGroupBoxComboBox.SelectedIndex = 0;

                tailleTransactionGroupBoxComboBox.Items.AddRange(oTrans.GetTailles());
                tailleTransactionGroupBoxComboBox.SelectedIndex = 0;

                dateLivraisonTransactionGroupBoxDateTimePicker.Text= DateTime.Now.ToLongDateString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); ;
            }

            try
            {
                oTypes = new TypesClass();

                typeMeubleClientGroupBoxComboBox.Items.AddRange(oTypes.GetTypes(ct.Types));
                typeMeubleClientGroupBoxComboBox.SelectedIndex = 0;
                styleMeubleClientGroupBoxComboBox.Items.AddRange(oTypes.GetTypes(ct.Styles));
                styleMeubleClientGroupBoxComboBox.SelectedIndex = 0;


            }
            catch (ArgumentOutOfRangeException ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }

        }
        #endregion

        #region Obtenir le prix
        /// <summary>
        /// Méthode partagé pour mettre à jour le label du prix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManifacturierTailleComboBox_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                if (manifacturierTransactionGroupBoxComboBox.SelectedIndex != -1 && tailleTransactionGroupBoxComboBox.SelectedIndex != -1)
                    prixMeubleTransactionGroupBoxLabel.Text = oTrans.GetPrix(manifacturierTransactionGroupBoxComboBox.SelectedItem.ToString(), tailleTransactionGroupBoxComboBox.SelectedItem.ToString()).ToString("C2");
            }
            catch (ArgumentOutOfRangeException ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
        }
        #endregion

        #region AboutBox
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentesMeublesAboutBox oVentesMeublesAboutBox = new VentesMeublesAboutBox();
            oVentesMeublesAboutBox.ShowDialog();
        }
        #endregion

        #region Quitter

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Enregistrer

        /// <summary>
        /// Méthode partagé pour Enregistrer l'information de la transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enregistrer_Click(object sender, EventArgs e)
        {
            TransactionClass oTrans;

            oTrans = new TransactionClass();

            oTrans.Enregister(nomClientGroupBoxMaskedTextBox.Text,
                prenomClientGroupBoxMaskedTextBox.Text,
                adresseClientGroupBoxMaskedTextBox.Text,
                codePostalClientGroupBoxMaskedTextBox.Text,
                telephoneClientGroupBoxMaskedTextBox.Text,
                typeMeubleClientGroupBoxComboBox.Text,
                styleMeubleClientGroupBoxComboBox.Text,
                manifacturierTransactionGroupBoxComboBox.Text,
                tailleTransactionGroupBoxComboBox.Text,
                DateTime.Parse(dateLivraisonTransactionGroupBoxDateTimePicker.Text),
                    Decimal.Parse(prixMeubleTransactionGroupBoxLabel.Text, System.Globalization.NumberStyles.Currency));
        }

        #endregion

    }
}
