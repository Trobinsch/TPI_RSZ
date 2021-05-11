namespace View
{
    partial class frm_Versement
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_accountRecipient = new System.Windows.Forms.Label();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.lbl_informationSent = new System.Windows.Forms.Label();
            this.lbl_personnalInformation = new System.Windows.Forms.Label();
            this.txt_accountRecipient = new System.Windows.Forms.TextBox();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.txt_informationTransmitted = new System.Windows.Forms.TextBox();
            this.txt_personnalInformation = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.DTP_datePayment = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbl_accountRecipient
            // 
            this.lbl_accountRecipient.AutoSize = true;
            this.lbl_accountRecipient.Location = new System.Drawing.Point(31, 42);
            this.lbl_accountRecipient.Name = "lbl_accountRecipient";
            this.lbl_accountRecipient.Size = new System.Drawing.Size(115, 13);
            this.lbl_accountRecipient.TabIndex = 0;
            this.lbl_accountRecipient.Text = "Compte du destinataire";
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Location = new System.Drawing.Point(31, 114);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(46, 13);
            this.lbl_amount.TabIndex = 1;
            this.lbl_amount.Text = "Montant";
            // 
            // lbl_informationSent
            // 
            this.lbl_informationSent.AutoSize = true;
            this.lbl_informationSent.Location = new System.Drawing.Point(31, 175);
            this.lbl_informationSent.Name = "lbl_informationSent";
            this.lbl_informationSent.Size = new System.Drawing.Size(155, 13);
            this.lbl_informationSent.TabIndex = 2;
            this.lbl_informationSent.Text = "Information transmise (facultatif)";
            // 
            // lbl_personnalInformation
            // 
            this.lbl_personnalInformation.AutoSize = true;
            this.lbl_personnalInformation.Location = new System.Drawing.Point(31, 241);
            this.lbl_personnalInformation.Name = "lbl_personnalInformation";
            this.lbl_personnalInformation.Size = new System.Drawing.Size(162, 13);
            this.lbl_personnalInformation.TabIndex = 3;
            this.lbl_personnalInformation.Text = "Remarque personnelle (facultatif)";
            // 
            // txt_accountRecipient
            // 
            this.txt_accountRecipient.Location = new System.Drawing.Point(34, 58);
            this.txt_accountRecipient.Name = "txt_accountRecipient";
            this.txt_accountRecipient.Size = new System.Drawing.Size(100, 20);
            this.txt_accountRecipient.TabIndex = 4;
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(34, 130);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(100, 20);
            this.txt_amount.TabIndex = 5;
            // 
            // txt_informationTransmitted
            // 
            this.txt_informationTransmitted.Location = new System.Drawing.Point(34, 191);
            this.txt_informationTransmitted.Name = "txt_informationTransmitted";
            this.txt_informationTransmitted.Size = new System.Drawing.Size(421, 20);
            this.txt_informationTransmitted.TabIndex = 6;
            // 
            // txt_personnalInformation
            // 
            this.txt_personnalInformation.Location = new System.Drawing.Point(34, 257);
            this.txt_personnalInformation.Multiline = true;
            this.txt_personnalInformation.Name = "txt_personnalInformation";
            this.txt_personnalInformation.Size = new System.Drawing.Size(421, 155);
            this.txt_personnalInformation.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(445, 452);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Enregistrer";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(364, 452);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Annuler";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // DTP_datePayment
            // 
            this.DTP_datePayment.Enabled = false;
            this.DTP_datePayment.Location = new System.Drawing.Point(294, 55);
            this.DTP_datePayment.Name = "DTP_datePayment";
            this.DTP_datePayment.Size = new System.Drawing.Size(200, 20);
            this.DTP_datePayment.TabIndex = 10;
            // 
            // frm_Versement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 487);
            this.Controls.Add(this.DTP_datePayment);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_personnalInformation);
            this.Controls.Add(this.txt_informationTransmitted);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.txt_accountRecipient);
            this.Controls.Add(this.lbl_personnalInformation);
            this.Controls.Add(this.lbl_informationSent);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_accountRecipient);
            this.Name = "frm_Versement";
            this.Text = "Page de versement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_accountRecipient;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Label lbl_informationSent;
        private System.Windows.Forms.Label lbl_personnalInformation;
        private System.Windows.Forms.TextBox txt_accountRecipient;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.TextBox txt_informationTransmitted;
        private System.Windows.Forms.TextBox txt_personnalInformation;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DateTimePicker DTP_datePayment;
    }
}

