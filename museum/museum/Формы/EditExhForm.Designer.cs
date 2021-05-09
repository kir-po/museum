namespace museum
{
    partial class fEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEdit));
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpAddExh = new System.Windows.Forms.TableLayoutPanel();
            this.pImage = new System.Windows.Forms.Panel();
            this.gbExistsImg = new System.Windows.Forms.GroupBox();
            this.lbExistsImg = new System.Windows.Forms.ListBox();
            this.cmsImageEditExists = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.восстанвитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзображениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbAddedImg = new System.Windows.Forms.GroupBox();
            this.lbImages = new System.Windows.Forms.ListBox();
            this.cmsImageAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddExhibit = new System.Windows.Forms.Button();
            this.ofdAddPicture = new System.Windows.Forms.OpenFileDialog();
            this.tlpAddExh.SuspendLayout();
            this.pImage.SuspendLayout();
            this.gbExistsImg.SuspendLayout();
            this.cmsImageEditExists.SuspendLayout();
            this.gbAddedImg.SuspendLayout();
            this.cmsImageAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(148, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelAdd);
            // 
            // tlpAddExh
            // 
            this.tlpAddExh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAddExh.ColumnCount = 2;
            this.tlpAddExh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddExh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tlpAddExh.Controls.Add(this.pImage, 1, 0);
            this.tlpAddExh.Controls.Add(this.splitContainer1, 0, 0);
            this.tlpAddExh.Location = new System.Drawing.Point(12, 12);
            this.tlpAddExh.Name = "tlpAddExh";
            this.tlpAddExh.RowCount = 1;
            this.tlpAddExh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddExh.Size = new System.Drawing.Size(836, 423);
            this.tlpAddExh.TabIndex = 5;
            // 
            // pImage
            // 
            this.pImage.Controls.Add(this.gbExistsImg);
            this.pImage.Controls.Add(this.gbAddedImg);
            this.pImage.Controls.Add(this.pbImage);
            this.pImage.Controls.Add(this.btnAddImage);
            this.pImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage.Location = new System.Drawing.Point(581, 3);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(252, 417);
            this.pImage.TabIndex = 0;
            // 
            // gbExistsImg
            // 
            this.gbExistsImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExistsImg.Controls.Add(this.lbExistsImg);
            this.gbExistsImg.Location = new System.Drawing.Point(3, 313);
            this.gbExistsImg.Name = "gbExistsImg";
            this.gbExistsImg.Size = new System.Drawing.Size(246, 105);
            this.gbExistsImg.TabIndex = 5;
            this.gbExistsImg.TabStop = false;
            this.gbExistsImg.Text = "Существующие изображения:";
            // 
            // lbExistsImg
            // 
            this.lbExistsImg.ContextMenuStrip = this.cmsImageEditExists;
            this.lbExistsImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbExistsImg.FormattingEnabled = true;
            this.lbExistsImg.Location = new System.Drawing.Point(3, 16);
            this.lbExistsImg.Name = "lbExistsImg";
            this.lbExistsImg.Size = new System.Drawing.Size(240, 86);
            this.lbExistsImg.TabIndex = 0;
            this.lbExistsImg.Click += new System.EventHandler(this.lbImages_Click);
            // 
            // cmsImageEditExists
            // 
            this.cmsImageEditExists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.восстанвитьИзображениеToolStripMenuItem,
            this.удалитьИзображениеToolStripMenuItem1});
            this.cmsImageEditExists.Name = "cmsImageEditExists";
            this.cmsImageEditExists.Size = new System.Drawing.Size(220, 48);
            this.cmsImageEditExists.Opening += new System.ComponentModel.CancelEventHandler(this.cmsImageEditExistsOpening);
            // 
            // восстанвитьИзображениеToolStripMenuItem
            // 
            this.восстанвитьИзображениеToolStripMenuItem.Name = "восстанвитьИзображениеToolStripMenuItem";
            this.восстанвитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.восстанвитьИзображениеToolStripMenuItem.Text = "Восстанвить изображение";
            this.восстанвитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.restoreImage);
            // 
            // удалитьИзображениеToolStripMenuItem1
            // 
            this.удалитьИзображениеToolStripMenuItem1.Name = "удалитьИзображениеToolStripMenuItem1";
            this.удалитьИзображениеToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.удалитьИзображениеToolStripMenuItem1.Text = "Удалить изображение";
            this.удалитьИзображениеToolStripMenuItem1.Click += new System.EventHandler(this.deleteExistsImg);
            // 
            // gbAddedImg
            // 
            this.gbAddedImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddedImg.Controls.Add(this.lbImages);
            this.gbAddedImg.Location = new System.Drawing.Point(3, 202);
            this.gbAddedImg.Name = "gbAddedImg";
            this.gbAddedImg.Size = new System.Drawing.Size(246, 105);
            this.gbAddedImg.TabIndex = 4;
            this.gbAddedImg.TabStop = false;
            this.gbAddedImg.Text = "Добавленные изображения:";
            // 
            // lbImages
            // 
            this.lbImages.ContextMenuStrip = this.cmsImageAdd;
            this.lbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImages.FormattingEnabled = true;
            this.lbImages.Location = new System.Drawing.Point(3, 16);
            this.lbImages.Name = "lbImages";
            this.lbImages.Size = new System.Drawing.Size(240, 86);
            this.lbImages.TabIndex = 2;
            this.lbImages.Click += new System.EventHandler(this.lbImages_Click);
            // 
            // cmsImageAdd
            // 
            this.cmsImageAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьИзображениеToolStripMenuItem,
            this.удалитьИзображениеToolStripMenuItem});
            this.cmsImageAdd.Name = "cmsImage";
            this.cmsImageAdd.Size = new System.Drawing.Size(204, 48);
            this.cmsImageAdd.Opening += new System.ComponentModel.CancelEventHandler(this.cmsImageAddOpening);
            // 
            // добавитьИзображениеToolStripMenuItem
            // 
            this.добавитьИзображениеToolStripMenuItem.Name = "добавитьИзображениеToolStripMenuItem";
            this.добавитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.добавитьИзображениеToolStripMenuItem.Text = "Добавить изображение";
            this.добавитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.addImageToList);
            // 
            // удалитьИзображениеToolStripMenuItem
            // 
            this.удалитьИзображениеToolStripMenuItem.Name = "удалитьИзображениеToolStripMenuItem";
            this.удалитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.удалитьИзображениеToolStripMenuItem.Text = "Удалить изображение";
            this.удалитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.imageDelete);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Image = global::museum.Properties.Resources.image;
            this.pbImage.InitialImage = global::museum.Properties.Resources.image;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(246, 164);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddImage.Location = new System.Drawing.Point(3, 173);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(246, 23);
            this.btnAddImage.TabIndex = 1;
            this.btnAddImage.Text = "Добавить изображение";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.addImageToList);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(572, 417);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnAddExhibit
            // 
            this.btnAddExhibit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddExhibit.Location = new System.Drawing.Point(12, 441);
            this.btnAddExhibit.Name = "btnAddExhibit";
            this.btnAddExhibit.Size = new System.Drawing.Size(130, 23);
            this.btnAddExhibit.TabIndex = 6;
            this.btnAddExhibit.Text = "Сохранить изменения";
            this.btnAddExhibit.UseVisualStyleBackColor = true;
            this.btnAddExhibit.Click += new System.EventHandler(this.addExhibit);
            // 
            // ofdAddPicture
            // 
            this.ofdAddPicture.FileName = "openFileDialog1";
            this.ofdAddPicture.Multiselect = true;
            // 
            // fEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 472);
            this.Controls.Add(this.btnAddExhibit);
            this.Controls.Add(this.tlpAddExh);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(876, 510);
            this.Name = "fEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение экспоната";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tlpAddExh.ResumeLayout(false);
            this.pImage.ResumeLayout(false);
            this.gbExistsImg.ResumeLayout(false);
            this.cmsImageEditExists.ResumeLayout(false);
            this.gbAddedImg.ResumeLayout(false);
            this.cmsImageAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpAddExh;
        private System.Windows.Forms.Panel pImage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbImages;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnAddExhibit;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.OpenFileDialog ofdAddPicture;
        private System.Windows.Forms.ContextMenuStrip cmsImageAdd;
        private System.Windows.Forms.ToolStripMenuItem добавитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbExistsImg;
        private System.Windows.Forms.ListBox lbExistsImg;
        private System.Windows.Forms.GroupBox gbAddedImg;
        private System.Windows.Forms.ContextMenuStrip cmsImageEditExists;
        private System.Windows.Forms.ToolStripMenuItem восстанвитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзображениеToolStripMenuItem1;
    }
}