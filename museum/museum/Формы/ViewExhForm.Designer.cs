namespace museum
{
    partial class fViewExhibit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fViewExhibit));
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbMainImage = new System.Windows.Forms.PictureBox();
            this.tlpAttr = new System.Windows.Forms.TableLayoutPanel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.tlp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp1.ColumnCount = 2;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Controls.Add(this.pbMainImage, 0, 0);
            this.tlp1.Controls.Add(this.tlpAttr, 1, 0);
            this.tlp1.Controls.Add(this.btnEdit, 1, 2);
            this.tlp1.Controls.Add(this.tlpImages, 0, 1);
            this.tlp1.Location = new System.Drawing.Point(12, 12);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 3;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlp1.Size = new System.Drawing.Size(494, 493);
            this.tlp1.TabIndex = 0;
            // 
            // pbMainImage
            // 
            this.pbMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMainImage.Image = global::museum.Properties.Resources.image;
            this.pbMainImage.Location = new System.Drawing.Point(3, 3);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(283, 200);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMainImage.TabIndex = 1;
            this.pbMainImage.TabStop = false;
            // 
            // tlpAttr
            // 
            this.tlpAttr.AutoScroll = true;
            this.tlpAttr.ColumnCount = 1;
            this.tlpAttr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAttr.Location = new System.Drawing.Point(292, 3);
            this.tlpAttr.Name = "tlpAttr";
            this.tlpAttr.RowCount = 1;
            this.tlp1.SetRowSpan(this.tlpAttr, 2);
            this.tlpAttr.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAttr.Size = new System.Drawing.Size(199, 458);
            this.tlpAttr.TabIndex = 4;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(370, 467);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Изменить экспонат";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.toEdit);
            // 
            // tlpImages
            // 
            this.tlpImages.AutoScroll = true;
            this.tlpImages.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpImages.ColumnCount = 1;
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImages.Location = new System.Drawing.Point(3, 209);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 1;
            this.tlp1.SetRowSpan(this.tlpImages, 2);
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpImages.Size = new System.Drawing.Size(283, 281);
            this.tlpImages.TabIndex = 5;
            // 
            // fViewExhibit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 518);
            this.Controls.Add(this.tlp1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(534, 556);
            this.Name = "fViewExhibit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр экспоната";
            this.Load += new System.EventHandler(this.fViewExhibit_Load);
            this.tlp1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.PictureBox pbMainImage;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TableLayoutPanel tlpAttr;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
    }
}