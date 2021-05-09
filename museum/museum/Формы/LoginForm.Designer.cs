namespace museum
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.gbLogPass = new System.Windows.Forms.GroupBox();
            this.lblUsersEditor = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.gbLogPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogPass
            // 
            this.gbLogPass.Controls.Add(this.lblUsersEditor);
            this.gbLogPass.Controls.Add(this.btnLogin);
            this.gbLogPass.Controls.Add(this.btnCancel);
            this.gbLogPass.Controls.Add(this.tbPass);
            this.gbLogPass.Controls.Add(this.tbLogin);
            this.gbLogPass.Controls.Add(this.lblPass);
            this.gbLogPass.Controls.Add(this.lblLogin);
            this.gbLogPass.Location = new System.Drawing.Point(12, 12);
            this.gbLogPass.Name = "gbLogPass";
            this.gbLogPass.Size = new System.Drawing.Size(239, 133);
            this.gbLogPass.TabIndex = 0;
            this.gbLogPass.TabStop = false;
            this.gbLogPass.Text = "Введите логин и пароль пользователя:";
            // 
            // lblUsersEditor
            // 
            this.lblUsersEditor.AutoSize = true;
            this.lblUsersEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsersEditor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUsersEditor.Location = new System.Drawing.Point(89, 113);
            this.lblUsersEditor.Name = "lblUsersEditor";
            this.lblUsersEditor.Size = new System.Drawing.Size(135, 13);
            this.lblUsersEditor.TabIndex = 5;
            this.lblUsersEditor.Text = "Редактор пользователей";
            this.lblUsersEditor.Click += new System.EventHandler(this.registration);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(68, 87);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.login);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.close);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(57, 56);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(167, 20);
            this.tbPass.TabIndex = 2;
            this.tbPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPress);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(57, 28);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(167, 20);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPress);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(6, 58);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(48, 13);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Пароль:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(6, 31);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 157);
            this.Controls.Add(this.gbLogPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.gbLogPass.ResumeLayout(false);
            this.gbLogPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUsersEditor;
    }
}