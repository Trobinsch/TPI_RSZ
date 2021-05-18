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
            this.SuspendLayout();
            // 
            // btn_payment
            // 
            this.btn_payment.Location = new System.Drawing.Point(198, 391);
            this.btn_payment.Name = "btn_payment";
            this.btn_payment.Size = new System.Drawing.Size(125, 23);
            this.btn_payment.TabIndex = 0;
            this.btn_payment.Text = "Faire un versement";
            this.btn_payment.UseVisualStyleBackColor = true;
            this.btn_payment.Click += new System.EventHandler(this.btn_payment_Click);
            // 
            // frm_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 426);
            this.Controls.Add(this.btn_payment);
            this.Name = "frm_HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.frm_HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_payment;
    }
}