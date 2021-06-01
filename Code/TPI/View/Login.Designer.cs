namespace View
{
    partial class frm_login
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
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_connection = new System.Windows.Forms.Button();
            this.btn_leave = new System.Windows.Forms.Button();
            this.time_password = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(72, 61);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(53, 13);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "Identifiant";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(72, 132);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(71, 13);
            this.lbl_password.TabIndex = 1;
            this.lbl_password.Text = "Mot de passe";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(75, 77);
            this.txt_user.MaxLength = 50;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(126, 20);
            this.txt_user.TabIndex = 2;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(75, 148);
            this.txt_password.MaxLength = 30;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(126, 20);
            this.txt_password.TabIndex = 3;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // btn_connection
            // 
            this.btn_connection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_connection.Location = new System.Drawing.Point(336, 272);
            this.btn_connection.Name = "btn_connection";
            this.btn_connection.Size = new System.Drawing.Size(87, 23);
            this.btn_connection.TabIndex = 4;
            this.btn_connection.Text = "Se connecter";
            this.btn_connection.UseVisualStyleBackColor = true;
            this.btn_connection.Click += new System.EventHandler(this.btn_connection_Click);
            // 
            // btn_leave
            // 
            this.btn_leave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_leave.Location = new System.Drawing.Point(255, 272);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(75, 23);
            this.btn_leave.TabIndex = 5;
            this.btn_leave.Text = "Quitter";
            this.btn_leave.UseVisualStyleBackColor = true;
            this.btn_leave.Click += new System.EventHandler(this.btn_leave_Click);
            // 
            // time_password
            // 
            this.time_password.Tick += new System.EventHandler(this.time_password_Tick);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 307);
            this.Controls.Add(this.btn_leave);
            this.Controls.Add(this.btn_connection);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_user);
            this.MinimumSize = new System.Drawing.Size(451, 346);
            this.Name = "frm_login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_connection;
        private System.Windows.Forms.Button btn_leave;
        private System.Windows.Forms.Timer time_password;
    }
}