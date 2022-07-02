namespace GestioneProgetto
{
    partial class Finestra
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.creaDb = new System.Windows.Forms.Button();
            this.eliminaDb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addDomande = new System.Windows.Forms.Button();
            this.creaSfide = new System.Windows.Forms.Button();
            this.cancellaSfide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // creaDb
            // 
            this.creaDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.creaDb.Location = new System.Drawing.Point(12, 78);
            this.creaDb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.creaDb.Name = "creaDb";
            this.creaDb.Size = new System.Drawing.Size(119, 102);
            this.creaDb.TabIndex = 0;
            this.creaDb.Text = "CREA DB";
            this.creaDb.UseVisualStyleBackColor = false;
            this.creaDb.Click += new System.EventHandler(this.creaDb_Click);
            // 
            // eliminaDb
            // 
            this.eliminaDb.BackColor = System.Drawing.Color.Red;
            this.eliminaDb.Location = new System.Drawing.Point(137, 78);
            this.eliminaDb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eliminaDb.Name = "eliminaDb";
            this.eliminaDb.Size = new System.Drawing.Size(129, 102);
            this.eliminaDb.TabIndex = 1;
            this.eliminaDb.Text = "ELIMINA DB";
            this.eliminaDb.UseVisualStyleBackColor = false;
            this.eliminaDb.Click += new System.EventHandler(this.eliminaDb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 46);
            this.label1.TabIndex = 2;
            // 
            // addDomande
            // 
            this.addDomande.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addDomande.Location = new System.Drawing.Point(12, 205);
            this.addDomande.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addDomande.Name = "addDomande";
            this.addDomande.Size = new System.Drawing.Size(177, 28);
            this.addDomande.TabIndex = 3;
            this.addDomande.Text = "AGGIUNGI DOMANDE";
            this.addDomande.UseVisualStyleBackColor = false;
            this.addDomande.Click += new System.EventHandler(this.addDomande_Click);
            // 
            // creaSfide
            // 
            this.creaSfide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.creaSfide.Location = new System.Drawing.Point(272, 78);
            this.creaSfide.Name = "creaSfide";
            this.creaSfide.Size = new System.Drawing.Size(106, 102);
            this.creaSfide.TabIndex = 4;
            this.creaSfide.Text = "CREA SFIDE";
            this.creaSfide.UseVisualStyleBackColor = false;
            this.creaSfide.Click += new System.EventHandler(this.creaSfide_Click);
            // 
            // cancellaSfide
            // 
            this.cancellaSfide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cancellaSfide.Location = new System.Drawing.Point(394, 78);
            this.cancellaSfide.Name = "cancellaSfide";
            this.cancellaSfide.Size = new System.Drawing.Size(106, 102);
            this.cancellaSfide.TabIndex = 5;
            this.cancellaSfide.Text = "CANCELLA SFIDE";
            this.cancellaSfide.UseVisualStyleBackColor = false;
            this.cancellaSfide.Click += new System.EventHandler(this.cancellaSfide_Click);
            // 
            // Finestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 246);
            this.Controls.Add(this.cancellaSfide);
            this.Controls.Add(this.creaSfide);
            this.Controls.Add(this.addDomande);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eliminaDb);
            this.Controls.Add(this.creaDb);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Finestra";
            this.Text = "Gestione Progetto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creaDb;
        private System.Windows.Forms.Button eliminaDb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addDomande;
        private System.Windows.Forms.Button creaSfide;
        private System.Windows.Forms.Button cancellaSfide;
    }
}

