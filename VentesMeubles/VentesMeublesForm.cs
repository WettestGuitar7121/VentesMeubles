/*

Programmeur : Brandon Pinet et Olivier Roussel
But : Un application pour la saisie d'un transaction d'une compagnie nommé Thomas's Old Furnitures
Solution: VentesMeubles.sln 
Projet: VentesMeubles.csproj
Classe : VentesMeublesForm.cs
Date : Le 14 Avril 2026 
 
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
    /// Les saisies d'une transaction pour la compagnie Thomas's Old Furnitures
    /// </summary>
    
    public partial class VentesMeublesForm : Form
    {
        #region Déclaration des membres privées
        
        TransactionClass oTrans;
        TypesClass oTypes;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeurs par défaut du Form
        /// </summary>
        public VentesMeublesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Méthode d'initalisation du form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show(ex.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(g.tMessages[(int)ce.ErreurIndeterminee]);
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
                MessageBox.Show(ex.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(g.tMessages[(int)ce.ErreurIndeterminee]);
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
                MessageBox.Show(ex.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(g.tMessages[(int)ce.ErreurIndeterminee]);
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

        /// <summary>
        /// Méthode pour quitter l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            try
            {
                //Méthode 1
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

                //Méthode 2
                //TransactionClass oTrans = new TransactionClass();
                //oTrans.Nom = nomClientGroupBoxMaskedTextBox.Text;
                //oTrans.Prenom = prenomClientGroupBoxMaskedTextBox.Text;
                //oTrans.Adresse = adresseClientGroupBoxMaskedTextBox.Text;
                //oTrans.CodePostal = codePostalClientGroupBoxMaskedTextBox.Text;
                //oTrans.Telephone = telephoneClientGroupBoxMaskedTextBox.Text;
                //oTrans.Type = typeMeubleClientGroupBoxComboBox.Text;
                //oTrans.Style = styleMeubleClientGroupBoxComboBox.Text;
                //oTrans.Manifacturier= manifacturierTransactionGroupBoxComboBox.Text;
                //oTrans.Taille = tailleTransactionGroupBoxComboBox.Text;
                //oTrans.DateLivraison = DateTime.Parse(dateLivraisonTransactionGroupBoxDateTimePicker.Text);
                //oTrans.Prix = Decimal.Parse(prixMeubleTransactionGroupBoxLabel.Text, System.Globalization.NumberStyles.Currency);

                // Méthode 3
                //TransactionClass oTrans = new TransactionClass(nomClientGroupBoxMaskedTextBox.Text,
                //     prenomClientGroupBoxMaskedTextBox.Text,
                //     adresseClientGroupBoxMaskedTextBox.Text,
                //     codePostalClientGroupBoxMaskedTextBox.Text,
                //     telephoneClientGroupBoxMaskedTextBox.Text,
                //     typeMeubleClientGroupBoxComboBox.Text,
                //     styleMeubleClientGroupBoxComboBox.Text,
                //     manifacturierTransactionGroupBoxComboBox.Text,
                //     tailleTransactionGroupBoxComboBox.Text,
                //     DateTime.Parse(dateLivraisonTransactionGroupBoxDateTimePicker.Text),
                //     Decimal.Parse(prixMeubleTransactionGroupBoxLabel.Text, System.Globalization.NumberStyles.Currency));

                // oTrans.Enregister();

                datePaiementTotalLabel.Text = oTrans.DatePaiement.ToLongDateString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(g.tMessages[(int)ce.ErreurIndeterminee]);
            }
        }



        #endregion

        #region Validating DateLivraion


        /// <summary>
        /// La validation du DateTimePicker 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateLivraisonTransactionGroupBoxDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DateTime value;

            if (DateTime.TryParse(dateLivraisonTransactionGroupBoxDateTimePicker.Text, out value))
            {
                dateLivraisonTransactionGroupBoxDateTimePicker.Text = value.ToLongDateString();
            }
            else
            {
                dateLivraisonTransactionGroupBoxDateTimePicker.Text = DateTime.Now.ToLongDateString();
            }
        }
        #endregion

        #region MaskedBoxEnter

        /// <summary>
        /// Méthode pour selectionner l'interieur de la MaskedTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskedTextBox_Enter(object sender, EventArgs e)
        {
            (sender as MaskedTextBox).SelectAll();
        }
        #endregion

    }
}
