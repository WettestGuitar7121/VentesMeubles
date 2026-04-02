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
    public partial class VentesMeublesForm : Form
    {
        public VentesMeublesForm()
        {
            InitializeComponent();
        }

        private void VentesMeublesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void quitterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
