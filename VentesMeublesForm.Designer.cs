namespace VentesMeubles
{
    partial class VentesMeublesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VentesMeublesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.transactionGroupBox = new System.Windows.Forms.GroupBox();
            this.enregistreButton = new System.Windows.Forms.Button();
            this.quitterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VentesMeublesContextMenuStrip
            // 
            this.VentesMeublesContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.VentesMeublesContextMenuStrip.Name = "VentesMeublesContextMenuStrip";
            this.VentesMeublesContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            this.VentesMeublesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.VentesMeublesContextMenuStrip_Opening);
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Location = new System.Drawing.Point(65, 86);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Size = new System.Drawing.Size(344, 316);
            this.clientGroupBox.TabIndex = 3;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Client:";
            // 
            // transactionGroupBox
            // 
            this.transactionGroupBox.Location = new System.Drawing.Point(622, 86);
            this.transactionGroupBox.Name = "transactionGroupBox";
            this.transactionGroupBox.Size = new System.Drawing.Size(344, 316);
            this.transactionGroupBox.TabIndex = 4;
            this.transactionGroupBox.TabStop = false;
            this.transactionGroupBox.Text = "Transaction:";
            // 
            // enregistreButton
            // 
            this.enregistreButton.Location = new System.Drawing.Point(518, 422);
            this.enregistreButton.Name = "enregistreButton";
            this.enregistreButton.Size = new System.Drawing.Size(203, 103);
            this.enregistreButton.TabIndex = 0;
            this.enregistreButton.Text = "Enregistrer";
            this.enregistreButton.UseVisualStyleBackColor = true;
            // 
            // quitterButton
            // 
            this.quitterButton.Location = new System.Drawing.Point(778, 422);
            this.quitterButton.Name = "quitterButton";
            this.quitterButton.Size = new System.Drawing.Size(203, 103);
            this.quitterButton.TabIndex = 5;
            this.quitterButton.Text = "Quitter";
            this.quitterButton.UseVisualStyleBackColor = true;
            this.quitterButton.Click += new System.EventHandler(this.quitterButton_Click);
            // 
            // VentesMeublesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 600);
            this.Controls.Add(this.quitterButton);
            this.Controls.Add(this.enregistreButton);
            this.Controls.Add(this.transactionGroupBox);
            this.Controls.Add(this.clientGroupBox);
            this.Name = "VentesMeublesForm";
            this.Text = "Formulaire de vente de Thomas Old Furniture\'s";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip VentesMeublesContextMenuStrip;
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.GroupBox transactionGroupBox;
        private System.Windows.Forms.Button enregistreButton;
        private System.Windows.Forms.Button quitterButton;
    }
}

