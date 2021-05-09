namespace museum
{
    partial class fView
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.pFilters = new System.Windows.Forms.Panel();
            this.gbExhibits = new System.Windows.Forms.GroupBox();
            this.dgvExhibits = new System.Windows.Forms.DataGridView();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьЭкспонатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЭкспонатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЭкспонатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFind = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.tvFund = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddExhibit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelExh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbColoringMode = new System.Windows.Forms.ToolStripButton();
            this.tslColoringMode = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFind = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.gbExhibits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExhibits)).BeginInit();
            this.cmsDGV.SuspendLayout();
            this.gbFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 58);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.gbFilters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbExhibits);
            this.splitContainer1.Size = new System.Drawing.Size(764, 410);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 9;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.pFilters);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFilters.Location = new System.Drawing.Point(0, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(762, 201);
            this.gbFilters.TabIndex = 5;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Фильтры:";
            // 
            // pFilters
            // 
            this.pFilters.AutoScroll = true;
            this.pFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFilters.Location = new System.Drawing.Point(3, 16);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(756, 182);
            this.pFilters.TabIndex = 0;
            // 
            // gbExhibits
            // 
            this.gbExhibits.Controls.Add(this.dgvExhibits);
            this.gbExhibits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExhibits.Location = new System.Drawing.Point(0, 0);
            this.gbExhibits.Name = "gbExhibits";
            this.gbExhibits.Size = new System.Drawing.Size(762, 201);
            this.gbExhibits.TabIndex = 4;
            this.gbExhibits.TabStop = false;
            this.gbExhibits.Text = "Экспонаты:";
            // 
            // dgvExhibits
            // 
            this.dgvExhibits.AllowUserToAddRows = false;
            this.dgvExhibits.AllowUserToDeleteRows = false;
            this.dgvExhibits.AllowUserToResizeRows = false;
            this.dgvExhibits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvExhibits.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvExhibits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExhibits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExhibits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExhibits.ContextMenuStrip = this.cmsDGV;
            this.dgvExhibits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExhibits.Location = new System.Drawing.Point(3, 16);
            this.dgvExhibits.Name = "dgvExhibits";
            this.dgvExhibits.ReadOnly = true;
            this.dgvExhibits.RowHeadersVisible = false;
            this.dgvExhibits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExhibits.Size = new System.Drawing.Size(756, 182);
            this.dgvExhibits.TabIndex = 0;
            this.dgvExhibits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExhibits_CellClick);
            this.dgvExhibits.DoubleClick += new System.EventHandler(this.viewExhibit);
            // 
            // cmsDGV
            // 
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЭкспонатToolStripMenuItem,
            this.удалитьЭкспонатToolStripMenuItem,
            this.изменитьЭкспонатToolStripMenuItem,
            this.добавитьВОтчётToolStripMenuItem});
            this.cmsDGV.Name = "cmsDGV";
            this.cmsDGV.Size = new System.Drawing.Size(182, 92);
            this.cmsDGV.Opening += new System.ComponentModel.CancelEventHandler(this.openCMS);
            // 
            // добавитьЭкспонатToolStripMenuItem
            // 
            this.добавитьЭкспонатToolStripMenuItem.Name = "добавитьЭкспонатToolStripMenuItem";
            this.добавитьЭкспонатToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьЭкспонатToolStripMenuItem.Text = "Добавить экспонат";
            this.добавитьЭкспонатToolStripMenuItem.Click += new System.EventHandler(this.addExhibit);
            // 
            // удалитьЭкспонатToolStripMenuItem
            // 
            this.удалитьЭкспонатToolStripMenuItem.Name = "удалитьЭкспонатToolStripMenuItem";
            this.удалитьЭкспонатToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.удалитьЭкспонатToolStripMenuItem.Text = "Удалить экспонат";
            this.удалитьЭкспонатToolStripMenuItem.Click += new System.EventHandler(this.deleteExhibit);
            // 
            // изменитьЭкспонатToolStripMenuItem
            // 
            this.изменитьЭкспонатToolStripMenuItem.Name = "изменитьЭкспонатToolStripMenuItem";
            this.изменитьЭкспонатToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.изменитьЭкспонатToolStripMenuItem.Text = "Изменить экспонат";
            this.изменитьЭкспонатToolStripMenuItem.Click += new System.EventHandler(this.editExhibit);
            // 
            // добавитьВОтчётToolStripMenuItem
            // 
            this.добавитьВОтчётToolStripMenuItem.Name = "добавитьВОтчётToolStripMenuItem";
            this.добавитьВОтчётToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьВОтчётToolStripMenuItem.Text = "Добавить в отчёт";
            this.добавитьВОтчётToolStripMenuItem.Click += new System.EventHandler(this.addToReport);
            // 
            // gbFind
            // 
            this.gbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFind.Controls.Add(this.btnFind);
            this.gbFind.Controls.Add(this.tbFind);
            this.gbFind.Location = new System.Drawing.Point(3, 3);
            this.gbFind.Name = "gbFind";
            this.gbFind.Size = new System.Drawing.Size(764, 49);
            this.gbFind.TabIndex = 6;
            this.gbFind.TabStop = false;
            this.gbFind.Text = "Поиск";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFind.Location = new System.Drawing.Point(689, 19);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 20);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Поиск";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(6, 19);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(677, 20);
            this.tbFind.TabIndex = 1;
            // 
            // tvFund
            // 
            this.tvFund.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tvFund.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvFund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFund.Location = new System.Drawing.Point(0, 0);
            this.tvFund.Name = "tvFund";
            this.tvFund.Size = new System.Drawing.Size(215, 471);
            this.tvFund.TabIndex = 8;
            this.tvFund.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFund_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(0, 28);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvFund);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbFind);
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(993, 473);
            this.splitContainer2.SplitterDistance = 217;
            this.splitContainer2.TabIndex = 10;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddExhibit,
            this.tsbtnDelExh,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.tsbColoringMode,
            this.tslColoringMode});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(993, 25);
            this.tsMenu.TabIndex = 11;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnAddExhibit
            // 
            this.tsBtnAddExhibit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddExhibit.Image = global::museum.Properties.Resources.plus_16;
            this.tsBtnAddExhibit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddExhibit.Name = "tsBtnAddExhibit";
            this.tsBtnAddExhibit.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAddExhibit.Text = "Добавить экспонат";
            this.tsBtnAddExhibit.Click += new System.EventHandler(this.addExhibit);
            // 
            // tsbtnDelExh
            // 
            this.tsbtnDelExh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDelExh.Image = global::museum.Properties.Resources.delete_16;
            this.tsbtnDelExh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelExh.Name = "tsbtnDelExh";
            this.tsbtnDelExh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDelExh.Text = "Удалить экспонат";
            this.tsbtnDelExh.Click += new System.EventHandler(this.deleteExhibit);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::museum.Properties.Resources.briefcase_16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Редактор коллекций";
            this.toolStripButton1.Click += new System.EventHandler(this.collectionEditor);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbColoringMode
            // 
            this.tsbColoringMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbColoringMode.Image = global::museum.Properties.Resources.star2_16;
            this.tsbColoringMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColoringMode.Name = "tsbColoringMode";
            this.tsbColoringMode.Size = new System.Drawing.Size(23, 22);
            this.tsbColoringMode.Text = "Отображение статуса экспоната (цвет)";
            this.tsbColoringMode.Click += new System.EventHandler(this.tsbColoringMode_Click);
            // 
            // tslColoringMode
            // 
            this.tslColoringMode.Name = "tslColoringMode";
            this.tslColoringMode.Size = new System.Drawing.Size(94, 22);
            this.tslColoringMode.Text = "ОСЭ (цвет): вкл.";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFind});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFind
            // 
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(0, 17);
            // 
            // fView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(993, 526);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.splitContainer2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 475);
            this.Name = "fView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "БД Музея";
            this.LocationChanged += new System.EventHandler(this.locChanged);
            this.SizeChanged += new System.EventHandler(this.sizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.gbExhibits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExhibits)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            this.gbFind.ResumeLayout(false);
            this.gbFind.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.GroupBox gbExhibits;
        private System.Windows.Forms.DataGridView dgvExhibits;
        private System.Windows.Forms.GroupBox gbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.TreeView tvFund;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem изменитьЭкспонатToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЭкспонатToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsBtnAddExhibit;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripMenuItem добавитьЭкспонатToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВОтчётToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFind;
        private System.Windows.Forms.ToolStripButton tsbtnDelExh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbColoringMode;
        private System.Windows.Forms.ToolStripLabel tslColoringMode;
    }
}

