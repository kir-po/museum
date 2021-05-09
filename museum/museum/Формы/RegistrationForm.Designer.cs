namespace museum
{
    partial class fReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReg));
            this.gbLogPass = new System.Windows.Forms.GroupBox();
            this.cbAdminStatus = new System.Windows.Forms.CheckBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.gbCollections = new System.Windows.Forms.GroupBox();
            this.clbCollections = new System.Windows.Forms.CheckedListBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.gbLogPass.SuspendLayout();
            this.gbCollections.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogPass
            // 
            this.gbLogPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLogPass.Controls.Add(this.btnDeleteUser);
            this.gbLogPass.Controls.Add(this.cbAdminStatus);
            this.gbLogPass.Controls.Add(this.btnNewUser);
            this.gbLogPass.Controls.Add(this.btnSave);
            this.gbLogPass.Controls.Add(this.lblUsers);
            this.gbLogPass.Controls.Add(this.cbUsers);
            this.gbLogPass.Controls.Add(this.tbPass);
            this.gbLogPass.Controls.Add(this.tbLogin);
            this.gbLogPass.Controls.Add(this.lblPass);
            this.gbLogPass.Controls.Add(this.lblLogin);
            this.gbLogPass.Location = new System.Drawing.Point(12, 12);
            this.gbLogPass.Name = "gbLogPass";
            this.gbLogPass.Size = new System.Drawing.Size(236, 312);
            this.gbLogPass.TabIndex = 0;
            this.gbLogPass.TabStop = false;
            this.gbLogPass.Text = "Задайте значения логина и пароля";
            // 
            // cbAdminStatus
            // 
            this.cbAdminStatus.AutoSize = true;
            this.cbAdminStatus.Location = new System.Drawing.Point(9, 107);
            this.cbAdminStatus.Name = "cbAdminStatus";
            this.cbAdminStatus.Size = new System.Drawing.Size(176, 17);
            this.cbAdminStatus.TabIndex = 8;
            this.cbAdminStatus.Text = "Является администратором?";
            this.cbAdminStatus.UseVisualStyleBackColor = true;
            this.cbAdminStatus.CheckedChanged += new System.EventHandler(this.adminOrNot);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(6, 246);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(96, 20);
            this.btnNewUser.TabIndex = 7;
            this.btnNewUser.Text = "Создать нового пользователя";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.newUser);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.saveUser);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(6, 269);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(162, 13);
            this.lblUsers.TabIndex = 5;
            this.lblUsers.Text = "Существующие пользователи:";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(6, 285);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(224, 21);
            this.cbUsers.TabIndex = 4;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.selectExistsUser);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(57, 52);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(173, 20);
            this.tbPass.TabIndex = 3;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(57, 23);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(173, 20);
            this.tbLogin.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(6, 55);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(51, 13);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Пароль: ";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(6, 25);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            // 
            // gbCollections
            // 
            this.gbCollections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCollections.Controls.Add(this.clbCollections);
            this.gbCollections.Location = new System.Drawing.Point(254, 12);
            this.gbCollections.Name = "gbCollections";
            this.gbCollections.Size = new System.Drawing.Size(302, 312);
            this.gbCollections.TabIndex = 1;
            this.gbCollections.TabStop = false;
            this.gbCollections.Text = "Коллекции, к которым имеет доступ данный пользователь";
            // 
            // clbCollections
            // 
            this.clbCollections.CheckOnClick = true;
            this.clbCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCollections.FormattingEnabled = true;
            this.clbCollections.Location = new System.Drawing.Point(3, 16);
            this.clbCollections.MultiColumn = true;
            this.clbCollections.Name = "clbCollections";
            this.clbCollections.Size = new System.Drawing.Size(296, 293);
            this.clbCollections.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(97, 78);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(133, 23);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Удалить пользователя";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.deleteUser);
            // 
            // fReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 336);
            this.Controls.Add(this.gbCollections);
            this.Controls.Add(this.gbLogPass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(499, 374);
            this.Name = "fReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Зарегистрировать нового пользователя";
            this.gbLogPass.ResumeLayout(false);
            this.gbLogPass.PerformLayout();
            this.gbCollections.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogPass;
        private System.Windows.Forms.GroupBox gbCollections;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckedListBox clbCollections;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.CheckBox cbAdminStatus;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}