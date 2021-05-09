namespace museum
{
    partial class fColEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fColEdit));
            this.tvFund = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbNewAttr = new System.Windows.Forms.ListBox();
            this.cmsNewAttr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьАтрибутToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNewAttr = new System.Windows.Forms.Label();
            this.lblExistsAttr = new System.Windows.Forms.Label();
            this.lbAttr = new System.Windows.Forms.ListBox();
            this.cmsLBAttr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьАтрибутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восстановитьАтрибутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddAttr = new System.Windows.Forms.Button();
            this.tbAttr = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddCol = new System.Windows.Forms.ToolStripButton();
            this.tspbtnDelCol = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblCollName = new System.Windows.Forms.ToolStripLabel();
            this.tstbCollName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnCollName = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCollNameCancel = new System.Windows.Forms.ToolStripButton();
            this.tssepCollName = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFindCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsNewAttr.SuspendLayout();
            this.cmsLBAttr.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFund
            // 
            this.tvFund.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tvFund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFund.Location = new System.Drawing.Point(0, 0);
            this.tvFund.Name = "tvFund";
            this.tvFund.Size = new System.Drawing.Size(165, 331);
            this.tvFund.TabIndex = 0;
            this.tvFund.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.selectFund);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFund);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbNewAttr);
            this.splitContainer1.Panel2.Controls.Add(this.lblNewAttr);
            this.splitContainer1.Panel2.Controls.Add(this.lblExistsAttr);
            this.splitContainer1.Panel2.Controls.Add(this.lbAttr);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddAttr);
            this.splitContainer1.Panel2.Controls.Add(this.tbAttr);
            this.splitContainer1.Size = new System.Drawing.Size(499, 331);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbNewAttr
            // 
            this.lbNewAttr.ContextMenuStrip = this.cmsNewAttr;
            this.lbNewAttr.FormattingEnabled = true;
            this.lbNewAttr.Location = new System.Drawing.Point(10, 48);
            this.lbNewAttr.Name = "lbNewAttr";
            this.lbNewAttr.Size = new System.Drawing.Size(308, 95);
            this.lbNewAttr.TabIndex = 5;
            // 
            // cmsNewAttr
            // 
            this.cmsNewAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьАтрибутToolStripMenuItem1});
            this.cmsNewAttr.Name = "cmsNewAttr";
            this.cmsNewAttr.Size = new System.Drawing.Size(165, 26);
            // 
            // удалитьАтрибутToolStripMenuItem1
            // 
            this.удалитьАтрибутToolStripMenuItem1.Name = "удалитьАтрибутToolStripMenuItem1";
            this.удалитьАтрибутToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.удалитьАтрибутToolStripMenuItem1.Text = "Удалить атрибут";
            this.удалитьАтрибутToolStripMenuItem1.Click += new System.EventHandler(this.deleteNewAttr);
            // 
            // lblNewAttr
            // 
            this.lblNewAttr.AutoSize = true;
            this.lblNewAttr.Location = new System.Drawing.Point(7, 32);
            this.lblNewAttr.Name = "lblNewAttr";
            this.lblNewAttr.Size = new System.Drawing.Size(94, 13);
            this.lblNewAttr.TabIndex = 4;
            this.lblNewAttr.Text = "Новые атрибуты:";
            // 
            // lblExistsAttr
            // 
            this.lblExistsAttr.AutoSize = true;
            this.lblExistsAttr.Location = new System.Drawing.Point(7, 152);
            this.lblExistsAttr.Name = "lblExistsAttr";
            this.lblExistsAttr.Size = new System.Drawing.Size(138, 13);
            this.lblExistsAttr.TabIndex = 3;
            this.lblExistsAttr.Text = "Существующие атрибуты:";
            // 
            // lbAttr
            // 
            this.lbAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAttr.ContextMenuStrip = this.cmsLBAttr;
            this.lbAttr.FormattingEnabled = true;
            this.lbAttr.Location = new System.Drawing.Point(10, 168);
            this.lbAttr.Name = "lbAttr";
            this.lbAttr.Size = new System.Drawing.Size(308, 160);
            this.lbAttr.TabIndex = 2;
            this.lbAttr.DoubleClick += new System.EventHandler(this.attrSelect);
            // 
            // cmsLBAttr
            // 
            this.cmsLBAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьАтрибутToolStripMenuItem,
            this.восстановитьАтрибутToolStripMenuItem});
            this.cmsLBAttr.Name = "cmsLBAttr";
            this.cmsLBAttr.Size = new System.Drawing.Size(196, 48);
            this.cmsLBAttr.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLBAttrOpening);
            // 
            // удалитьАтрибутToolStripMenuItem
            // 
            this.удалитьАтрибутToolStripMenuItem.Name = "удалитьАтрибутToolStripMenuItem";
            this.удалитьАтрибутToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.удалитьАтрибутToolStripMenuItem.Text = "Восстановить атрибут";
            this.удалитьАтрибутToolStripMenuItem.Click += new System.EventHandler(this.attrRestore);
            // 
            // восстановитьАтрибутToolStripMenuItem
            // 
            this.восстановитьАтрибутToolStripMenuItem.Name = "восстановитьАтрибутToolStripMenuItem";
            this.восстановитьАтрибутToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.восстановитьАтрибутToolStripMenuItem.Text = "Удалить атрибут";
            this.восстановитьАтрибутToolStripMenuItem.Click += new System.EventHandler(this.attrDelete);
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.Location = new System.Drawing.Point(197, 8);
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Size = new System.Drawing.Size(121, 23);
            this.btnAddAttr.TabIndex = 1;
            this.btnAddAttr.Text = "Добавить атрибут";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.addAttr);
            // 
            // tbAttr
            // 
            this.tbAttr.Location = new System.Drawing.Point(10, 9);
            this.tbAttr.Name = "tbAttr";
            this.tbAttr.Size = new System.Drawing.Size(181, 20);
            this.tbAttr.TabIndex = 0;
            this.tbAttr.TextChanged += new System.EventHandler(this.tbAttr_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddCol,
            this.tspbtnDelCol,
            this.toolStripSeparator1,
            this.tslblCollName,
            this.tstbCollName,
            this.tsbtnCollName,
            this.tsbtnCollNameCancel,
            this.tssepCollName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(499, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddCol
            // 
            this.tsbtnAddCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddCol.Image = global::museum.Properties.Resources.plus_16;
            this.tsbtnAddCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddCol.Name = "tsbtnAddCol";
            this.tsbtnAddCol.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddCol.Text = "Добавить коллекцию";
            this.tsbtnAddCol.Click += new System.EventHandler(this.addCollection);
            // 
            // tspbtnDelCol
            // 
            this.tspbtnDelCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspbtnDelCol.Image = global::museum.Properties.Resources.delete_32;
            this.tspbtnDelCol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnDelCol.Name = "tspbtnDelCol";
            this.tspbtnDelCol.Size = new System.Drawing.Size(23, 22);
            this.tspbtnDelCol.Text = "Удалить коллекцию";
            this.tspbtnDelCol.Click += new System.EventHandler(this.delCollection);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblCollName
            // 
            this.tslblCollName.Name = "tslblCollName";
            this.tslblCollName.Size = new System.Drawing.Size(206, 22);
            this.tslblCollName.Text = "Введите название новой коллекции:";
            this.tslblCollName.Visible = false;
            // 
            // tstbCollName
            // 
            this.tstbCollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbCollName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstbCollName.Name = "tstbCollName";
            this.tstbCollName.Size = new System.Drawing.Size(100, 25);
            this.tstbCollName.Visible = false;
            // 
            // tsbtnCollName
            // 
            this.tsbtnCollName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCollName.Image = global::museum.Properties.Resources.tick_32;
            this.tsbtnCollName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCollName.Name = "tsbtnCollName";
            this.tsbtnCollName.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCollName.Text = "ОК";
            this.tsbtnCollName.Visible = false;
            this.tsbtnCollName.Click += new System.EventHandler(this.addCollection);
            // 
            // tsbtnCollNameCancel
            // 
            this.tsbtnCollNameCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCollNameCancel.Image = global::museum.Properties.Resources.left_16;
            this.tsbtnCollNameCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCollNameCancel.Name = "tsbtnCollNameCancel";
            this.tsbtnCollNameCancel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCollNameCancel.Text = "Отмена";
            this.tsbtnCollNameCancel.Visible = false;
            this.tsbtnCollNameCancel.Click += new System.EventHandler(this.addCollectionCancel);
            // 
            // tssepCollName
            // 
            this.tssepCollName.Name = "tssepCollName";
            this.tssepCollName.Size = new System.Drawing.Size(6, 25);
            this.tssepCollName.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(351, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить изменения";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.saveChanges);
            // 
            // lblFindCount
            // 
            this.lblFindCount.AutoSize = true;
            this.lblFindCount.Location = new System.Drawing.Point(5, 373);
            this.lblFindCount.Name = "lblFindCount";
            this.lblFindCount.Size = new System.Drawing.Size(0, 13);
            this.lblFindCount.TabIndex = 4;
            // 
            // fColEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 396);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblFindCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(515, 434);
            this.Name = "fColEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор коллекций";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fColEdit_FormClosing);
            this.Load += new System.EventHandler(this.fColEdit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsNewAttr.ResumeLayout(false);
            this.cmsLBAttr.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFund;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAddCol;
        private System.Windows.Forms.ListBox lbAttr;
        private System.Windows.Forms.Button btnAddAttr;
        private System.Windows.Forms.TextBox tbAttr;
        private System.Windows.Forms.ContextMenuStrip cmsLBAttr;
        private System.Windows.Forms.ToolStripMenuItem удалитьАтрибутToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem восстановитьАтрибутToolStripMenuItem;
        private System.Windows.Forms.ListBox lbNewAttr;
        private System.Windows.Forms.Label lblNewAttr;
        private System.Windows.Forms.Label lblExistsAttr;
        private System.Windows.Forms.ContextMenuStrip cmsNewAttr;
        private System.Windows.Forms.ToolStripMenuItem удалитьАтрибутToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tspbtnDelCol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslblCollName;
        private System.Windows.Forms.ToolStripTextBox tstbCollName;
        private System.Windows.Forms.ToolStripButton tsbtnCollName;
        private System.Windows.Forms.ToolStripSeparator tssepCollName;
        private System.Windows.Forms.ToolStripButton tsbtnCollNameCancel;
        private System.Windows.Forms.Label lblFindCount;
    }
}