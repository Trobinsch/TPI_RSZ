namespace View
{
    partial class frm_HomePage
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
            this.btn_payment = new System.Windows.Forms.Button();
            this.btn_leave = new System.Windows.Forms.Button();
            this.btn_sort = new System.Windows.Forms.Button();
            this.DTP_lastDate = new System.Windows.Forms.DateTimePicker();
            this.DTP_firstDate = new System.Windows.Forms.DateTimePicker();
            this.LSV_payment = new System.Windows.Forms.ListView();
            this.CLM_Recipient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_Sender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_InformationTransmitted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CLM_personnalInformation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_listPayment = new System.Windows.Forms.Label();
            this.lbl_lastDate = new System.Windows.Forms.Label();
            this.lbl_firstDate = new System.Windows.Forms.Label();
            this.lbl_amountOwnerDisplay = new System.Windows.Forms.Label();
            this.lbl_amountOwner = new System.Windows.Forms.Label();
            this.btn_listRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_payment
            // 
            this.btn_payment.Location = new System.Drawing.Point(503, 396);
            this.btn_payment.Name = "btn_payment";
            this.btn_payment.Size = new System.Drawing.Size(125, 23);
            this.btn_payment.TabIndex = 0;
            this.btn_payment.Text = "Faire un versement";
            this.btn_payment.UseVisualStyleBackColor = true;
            this.btn_payment.Click += new System.EventHandler(this.btn_payment_Click);
            // 
            // btn_leave
            // 
            this.btn_leave.Location = new System.Drawing.Point(422, 396);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(75, 23);
            this.btn_leave.TabIndex = 1;
            this.btn_leave.Text = "Quitter";
            this.btn_leave.UseVisualStyleBackColor = true;
            this.btn_leave.Click += new System.EventHandler(this.btn_leave_Click);
            // 
            // btn_sort
            // 
            this.btn_sort.Location = new System.Drawing.Point(580, 42);
            this.btn_sort.Name = "btn_sort";
            this.btn_sort.Size = new System.Drawing.Size(48, 23);
            this.btn_sort.TabIndex = 2;
            this.btn_sort.Text = "Filtrer";
            this.btn_sort.UseVisualStyleBackColor = true;
            this.btn_sort.Click += new System.EventHandler(this.btn_sort_Click);
            // 
            // DTP_lastDate
            // 
            this.DTP_lastDate.Location = new System.Drawing.Point(374, 41);
            this.DTP_lastDate.Name = "DTP_lastDate";
            this.DTP_lastDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_lastDate.TabIndex = 3;
            // 
            // DTP_firstDate
            // 
            this.DTP_firstDate.Location = new System.Drawing.Point(168, 41);
            this.DTP_firstDate.Name = "DTP_firstDate";
            this.DTP_firstDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_firstDate.TabIndex = 4;
            // 
            // LSV_payment
            // 
            this.LSV_payment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CLM_Recipient,
            this.CLM_Sender,
            this.CLM_amount,
            this.CLM_date,
            this.CLM_InformationTransmitted,
            this.CLM_personnalInformation});
            this.LSV_payment.HideSelection = false;
            this.LSV_payment.Location = new System.Drawing.Point(25, 107);
            this.LSV_payment.Name = "LSV_payment";
            this.LSV_payment.Size = new System.Drawing.Size(558, 270);
            this.LSV_payment.TabIndex = 5;
            this.LSV_payment.UseCompatibleStateImageBehavior = false;
            this.LSV_payment.View = System.Windows.Forms.View.Details;
            // 
            // CLM_Recipient
            // 
            this.CLM_Recipient.Text = "Destinataire";
            this.CLM_Recipient.Width = 92;
            // 
            // CLM_Sender
            // 
            this.CLM_Sender.Text = "Envoyeur";
            this.CLM_Sender.Width = 92;
            // 
            // CLM_amount
            // 
            this.CLM_amount.Text = "Montant";
            this.CLM_amount.Width = 73;
            // 
            // CLM_date
            // 
            this.CLM_date.Text = "Date";
            this.CLM_date.Width = 80;
            // 
            // CLM_InformationTransmitted
            // 
            this.CLM_InformationTransmitted.Text = "Information Transmise";
            this.CLM_InformationTransmitted.Width = 115;
            // 
            // CLM_personnalInformation
            // 
            this.CLM_personnalInformation.Text = "Information Personnel";
            this.CLM_personnalInformation.Width = 127;
            // 
            // lbl_listPayment
            // 
            this.lbl_listPayment.AutoSize = true;
            this.lbl_listPayment.Location = new System.Drawing.Point(22, 91);
            this.lbl_listPayment.Name = "lbl_listPayment";
            this.lbl_listPayment.Size = new System.Drawing.Size(101, 13);
            this.lbl_listPayment.TabIndex = 6;
            this.lbl_listPayment.Text = "Liste des opérations";
            // 
            // lbl_lastDate
            // 
            this.lbl_lastDate.AutoSize = true;
            this.lbl_lastDate.Location = new System.Drawing.Point(371, 25);
            this.lbl_lastDate.Name = "lbl_lastDate";
            this.lbl_lastDate.Size = new System.Drawing.Size(59, 13);
            this.lbl_lastDate.TabIndex = 7;
            this.lbl_lastDate.Text = "Date de fin";
            // 
            // lbl_firstDate
            // 
            this.lbl_firstDate.AutoSize = true;
            this.lbl_firstDate.Location = new System.Drawing.Point(165, 25);
            this.lbl_firstDate.Name = "lbl_firstDate";
            this.lbl_firstDate.Size = new System.Drawing.Size(75, 13);
            this.lbl_firstDate.TabIndex = 8;
            this.lbl_firstDate.Text = "Date de début";
            // 
            // lbl_amountOwnerDisplay
            // 
            this.lbl_amountOwnerDisplay.AutoSize = true;
            this.lbl_amountOwnerDisplay.Location = new System.Drawing.Point(22, 41);
            this.lbl_amountOwnerDisplay.Name = "lbl_amountOwnerDisplay";
            this.lbl_amountOwnerDisplay.Size = new System.Drawing.Size(40, 13);
            this.lbl_amountOwnerDisplay.TabIndex = 9;
            this.lbl_amountOwnerDisplay.Text = "Solde :";
            // 
            // lbl_amountOwner
            // 
            this.lbl_amountOwner.AutoSize = true;
            this.lbl_amountOwner.Location = new System.Drawing.Point(68, 41);
            this.lbl_amountOwner.Name = "lbl_amountOwner";
            this.lbl_amountOwner.Size = new System.Drawing.Size(31, 13);
            this.lbl_amountOwner.TabIndex = 10;
            this.lbl_amountOwner.Text = "0000";
            // 
            // btn_listRefresh
            // 
            this.btn_listRefresh.Location = new System.Drawing.Point(316, 396);
            this.btn_listRefresh.Name = "btn_listRefresh";
            this.btn_listRefresh.Size = new System.Drawing.Size(100, 23);
            this.btn_listRefresh.TabIndex = 11;
            this.btn_listRefresh.Text = "Rafraichir la liste";
            this.btn_listRefresh.UseVisualStyleBackColor = true;
            this.btn_listRefresh.Click += new System.EventHandler(this.btn_listRefresh_Click);
            // 
            // frm_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 431);
            this.Controls.Add(this.btn_listRefresh);
            this.Controls.Add(this.lbl_amountOwner);
            this.Controls.Add(this.lbl_amountOwnerDisplay);
            this.Controls.Add(this.lbl_firstDate);
            this.Controls.Add(this.lbl_lastDate);
            this.Controls.Add(this.lbl_listPayment);
            this.Controls.Add(this.LSV_payment);
            this.Controls.Add(this.DTP_firstDate);
            this.Controls.Add(this.DTP_lastDate);
            this.Controls.Add(this.btn_sort);
            this.Controls.Add(this.btn_leave);
            this.Controls.Add(this.btn_payment);
            this.Name = "frm_HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.frm_HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_payment;
        private System.Windows.Forms.Button btn_leave;
        private System.Windows.Forms.Button btn_sort;
        private System.Windows.Forms.DateTimePicker DTP_lastDate;
        private System.Windows.Forms.DateTimePicker DTP_firstDate;
        private System.Windows.Forms.ListView LSV_payment;
        private System.Windows.Forms.ColumnHeader CLM_Recipient;
        private System.Windows.Forms.ColumnHeader CLM_amount;
        private System.Windows.Forms.ColumnHeader CLM_InformationTransmitted;
        private System.Windows.Forms.ColumnHeader CLM_personnalInformation;
        private System.Windows.Forms.ColumnHeader CLM_date;
        private System.Windows.Forms.Label lbl_listPayment;
        private System.Windows.Forms.Label lbl_lastDate;
        private System.Windows.Forms.Label lbl_firstDate;
        private System.Windows.Forms.Label lbl_amountOwnerDisplay;
        private System.Windows.Forms.Label lbl_amountOwner;
        private System.Windows.Forms.Button btn_listRefresh;
        private System.Windows.Forms.ColumnHeader CLM_Sender;
    }
}