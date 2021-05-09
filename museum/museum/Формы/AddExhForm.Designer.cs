namespace museum
{
    partial class fAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAdd));
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpAddExh = new System.Windows.Forms.TableLayoutPanel();
            this.pImage = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbImages = new System.Windows.Forms.ListBox();
            this.cmsImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddExhibit = new System.Windows.Forms.Button();
            this.ofdAddPicture = new System.Windows.Forms.OpenFileDialog();
            this.tlpAddExh.SuspendLayout();
            this.pImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.cmsImage.SuspendLayout();
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
            this.pImage.Controls.Add(this.pbImage);
            this.pImage.Controls.Add(this.lbImages);
            this.pImage.Controls.Add(this.btnAddImage);
            this.pImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage.Location = new System.Drawing.Point(581, 3);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(252, 417);
            this.pImage.TabIndex = 0;
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
            // lbImages
            // 
            this.lbImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImages.ContextMenuStrip = this.cmsImage;
            this.lbImages.FormattingEnabled = true;
            this.lbImages.Location = new System.Drawing.Point(3, 204);
            this.lbImages.Name = "lbImages";
            this.lbImages.Size = new System.Drawing.Size(246, 212);
            this.lbImages.TabIndex = 2;
            this.lbImages.Click += new System.EventHandler(this.lbImages_Click);
            // 
            // cmsImage
            // 
            this.cmsImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьИзображениеToolStripMenuItem,
            this.удалитьИзображениеToolStripMenuItem});
            this.cmsImage.Name = "cmsImage";
            this.cmsImage.Size = new System.Drawing.Size(204, 48);
            this.cmsImage.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOpening);
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
            this.btnAddExhibit.Text = "Добавить экспонат";
            this.btnAddExhibit.UseVisualStyleBackColor = true;
            this.btnAddExhibit.Click += new System.EventHandler(this.addExhibit);
            // 
            // ofdAddPicture
            // 
            this.ofdAddPicture.FileName = "openFileDialog1";
            this.ofdAddPicture.Multiselect = true;
            // 
            // fAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 472);
            this.Controls.Add(this.btnAddExhibit);
            this.Controls.Add(this.tlpAddExh);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(876, 510);
            this.Name = "fAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление экспоната";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tlpAddExh.ResumeLayout(false);
            this.pImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.cmsImage.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsImage;
        private System.Windows.Forms.ToolStripMenuItem добавитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзображениеToolStripMenuItem;




    }
}