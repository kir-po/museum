using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System;
using System.IO;

namespace museum
{
    public partial class fView : Form
    {
        public string connection_string = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\museum.mdb";
        public string selectedFund = "";
        public string user;
        public string kp = "";
        public string resPath = @".\resources\images\";
        public string queryColor = "";

        public string[] arComboBoxItems;
        public string[] arQueryConstructorAttributesValues;
        public string[] sposobPostupleniya = new string[] {"Дар","Пожертвование","Безвозмездная передача","Закупка"};
        public string[] tipologiyaPo8NK = new string[] {"Живопись",
                                                        "Графика",
                                                        "Скульптура",
                                                        "Предметы прикладного искусства, быта и этнографии",
                                                        "Предметы нумизматики",
                                                        "Предметы археологии",
                                                        "Редкие книги",
                                                        "Оружие",
                                                        "Документы",
                                                        "Фотографии, негативы",
                                                        "Предметы естественнонаучной коллекции",
                                                        "Предметы минералогической коллекции",
                                                        "Предметы техники",
                                                        "Предметы печатной продукции",
                                                        "Прочие"};
        public string[] formaSobstvennosti = new string[] {"Федеральная собственность",
                                                           "Собственность субъектов РФ",
                                                           "Муниципальная собственность",
                                                           "Частная собственность"};
        public string[] ogranicheniye = new string[] {"Публиковать","Не публиковать"};
        public string[] kategoriyaCennosti = new string[] {"1","2","3"};

        public int generalCount;
        public int id;
        public int rowInd = 404;

        public bool firstSelection = true;
        public bool exStatus = false;
        public bool editStatus = false;
        public bool admin;
        public bool exit;
        public bool fromColEdit = false;
        public bool reportExists = false;
        public bool findStart = false;
        public bool coloringMode = true;

        public DataSet dsFilters;
        public DataSet dsBuffer;
        public DataSet dsExhibits;
        public DataSet dsColoring;

        public List<string> attr = new List<string>();
        public List<string> fundsAccess = new List<string>();

        public fReport frmReport;

        //инициализация формы
        public fView()
        {
            InitializeComponent();

            fundsExtract();
            login();
        }

        //для раскраски
        void forColoring(bool find)
        {
            string sql = "";

            if (find == false)
            {
                if (queryColor == "") sql = "SELECT * FROM Экспонаты WHERE fundTable = '" + selectedFund + "'";
                else
                {
                    sql = queryColor;
                    queryColor = "";
                }
            }
            else
            {
                sql = "SELECT Экспонаты.*, Общие.* FROM Экспонаты, Общие WHERE Экспонаты.idExhibition = Общие.idExhibition AND Экспонаты.descriptionFind LIKE '%" + tbFind.Text + "%'";
            }

            findStart = false;

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            dsColoring = new DataSet();
            adapter.Fill(dsColoring, "coloring");

            for (int i = 0; i < dsColoring.Tables[0].Rows.Count; i++)
            {
                string exportStatus = dsColoring.Tables[0].Rows[i]["exportStatus"].ToString();

                dgvExhibits.Rows[i].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                dgvExhibits.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                dgvExhibits.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;

                if (exportStatus.Contains("noXML"))
                {
                    dgvExhibits.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvExhibits.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Gray;
                }
                else if (exportStatus.Contains("yesXML"))
                {
                    dgvExhibits.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    dgvExhibits.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                }
                else if (exportStatus.Contains("error"))
                {
                    dgvExhibits.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dgvExhibits.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                else if (exportStatus.Contains("registered") | exportStatus.Contains("corrected"))
                {
                    dgvExhibits.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dgvExhibits.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        //логин
        void login()
        {
            fLogin fLogin = new fLogin();

            fLogin.Owner = this;
            fLogin.ShowDialog();
        }

        //sql-запрос
        public void sqlQuery(string sql)
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            if (sql == "SELECT MAX(idExhibition) FROM Экспонаты")
            {
                id = (int)cmd.ExecuteScalar();
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                exStatus = true;
                cmd.CommandText = "DELETE FROM Экспонаты WHERE idExhibition = " + id;
                if (editStatus != true) cmd.ExecuteNonQuery();
                editStatus = false;
            }
            connection.Close();
        }

        //извлечение фондов
        public void fundsExtract()
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            DataTable dtFunds = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            connection.Close();

            tvFund.Nodes.Add("Фонды:");
            foreach (DataRow item in dtFunds.Rows)
            {
                if ((string)item["TABLE_NAME"] != "Экспонаты" & (string)item["TABLE_NAME"] != "Общие" & (string)item["TABLE_NAME"] != "Пользователи")
                {
                    tvFund.Nodes[0].Nodes.Add((string)item["TABLE_NAME"]);
                }
            }
            tvFund.ExpandAll();
        }

        //извлечение фильтров
        public void filtersExtract()
        {
            string query;

            query = "SELECT Общие.* FROM Общие";

            OleDbConnection connection1 = new OleDbConnection(connection_string);
            connection1.Open();
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(query, connection1);
            OleDbCommandBuilder comBuilder1 = new OleDbCommandBuilder(adapter1);
            dsBuffer = new DataSet();
            adapter1.Fill(dsBuffer, "general_count");
            connection1.Close();
            generalCount = dsBuffer.Tables[0].Columns.Count - 2;

            pFilters.Controls.Clear();

            //извлечение атрибутов
            query = "SELECT Общие.*, " + selectedFund + ".* FROM Экспонаты, Общие, " + selectedFund + " WHERE Экспонаты.idExhibition = Общие.idExhibition AND Экспонаты.idExhibition = " + selectedFund + ".idExhibition";

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            dsFilters = new DataSet();
            adapter.Fill(dsFilters, "attributes");
            connection.Close();

            dsFilters.Tables[0].Columns.Remove("Общие.idExhibition");
            dsFilters.Tables[0].Columns.Remove(selectedFund + ".idExhibition");
            dsFilters.Tables[0].Columns.Remove("Фото");

            FlowLayoutPanel flpFilters = new FlowLayoutPanel();
            flpFilters.Dock = DockStyle.Fill;
            flpFilters.AutoSize = true;

            Array.Resize<string>(ref arComboBoxItems, dsFilters.Tables[0].Rows.Count);
            Array.Resize<string>(ref arQueryConstructorAttributesValues, dsFilters.Tables[0].Columns.Count);
            
            //создание фильтров
            for (int i = 0; i < dsFilters.Tables[0].Columns.Count; i++)
            {
                ComboBox cbFilter = new ComboBox();
                Label lblFilter = new Label();
                FlowLayoutPanel flpFiltersBuffer = new FlowLayoutPanel();

                lblFilter.AutoSize = true;
                flpFiltersBuffer.AutoSize = true;
                flpFiltersBuffer.FlowDirection = FlowDirection.TopDown;
                flpFiltersBuffer.WrapContents = false;

                if (dsFilters.Tables[0].Columns[i].ToString().Contains('_')) lblFilter.Text = dsFilters.Tables[0].Columns[i].ToString().Replace("_", " ");
                else lblFilter.Text = dsFilters.Tables[0].Columns[i].ToString();

                string bufLabelName = lblFilter.Text;
                if (lblFilter.Text.Length > 20)
                {
                    lblFilter.Text = lblFilter.Text.Substring(0, 17) + "...";
                    ToolTip tooltip = new ToolTip();
                    tooltip.AutoPopDelay = 5000;
                    tooltip.InitialDelay = 1000;
                    tooltip.ReshowDelay = 500;
                    tooltip.ShowAlways = true;

                    tooltip.SetToolTip(lblFilter, bufLabelName);
                }

                cbFilter.Name = dsFilters.Tables[0].Columns[i].ToString();
                cbFilter.Tag = i+1;
                cbFilter.SelectedIndexChanged += new EventHandler(cbFilter_SelectedIndexChanged);
                for (int j = 0; j < dsFilters.Tables[0].Rows.Count; j++)
                {
                    arComboBoxItems[j] = dsFilters.Tables[0].Rows[j][i].ToString();
                }

                string[] result = arComboBoxItems.Distinct().ToArray();

                cbFilter.Items.AddRange(result);
                flpFiltersBuffer.Controls.Add(lblFilter);
                flpFiltersBuffer.Controls.Add(cbFilter);
                flpFilters.Controls.Add(flpFiltersBuffer);
            }
            dsFilters.Tables[0].Clear();
            pFilters.Controls.Add(flpFilters);
            pFilters.VerticalScroll.Enabled = true;
        }

        //извлечение экспонатов, показ в dgv
        void exhibitsExtract(string exhibits, int find)
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(exhibits, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            dsExhibits = new DataSet();
            adapter.Fill(dsExhibits, "exhibits");
            connection.Close();

            if (dsExhibits.Tables[0].Rows.Count != 0)
            {
                dgvExhibits.DataSource = dsExhibits.Tables[0];
                if (coloringMode == true) forColoring(findStart);
                if (find != 1) 
                {
                    dgvExhibits.Columns["Общие.idExhibition"].Visible = false;
                    dgvExhibits.Columns["Фото"].Visible = false;
                }
                else dgvExhibits.Columns["idExhibition"].Visible = false;
                if (find != 1) dgvExhibits.Columns[tvFund.SelectedNode.Text + ".idExhibition"].Visible = false;

                //замена exhibitionName
                dgvExhibits.Columns["exhibitionName"].HeaderText = "Название экспоната";

                //замена _ на пробел
                for (int i = 0; i < dgvExhibits.Columns.Count; i++)
                {
                    if (dgvExhibits.Columns[i].HeaderText.Contains('_')) dgvExhibits.Columns[i].HeaderText = dgvExhibits.Columns[i].HeaderText.Replace("_", " ");
                }

                lblFind.Text = "Найдено: " + dsExhibits.Tables[0].Rows.Count.ToString();
            }
            else
            {
                lblFind.Text = "Найдено: 0";
                dgvExhibits.DataSource = dsExhibits.Tables[0];
                if (find != 1) dgvExhibits.Columns["Общие.idExhibition"].Visible = false;
                else dgvExhibits.Columns["idExhibition"].Visible = false;
                if (find != 1) dgvExhibits.Columns[tvFund.SelectedNode.Text + ".idExhibition"].Visible = false;
                //замена exhibitionName
                dgvExhibits.Columns["exhibitionName"].HeaderText = "Название экспоната";

                //замена _ на пробел
                for (int i = 0; i < dgvExhibits.Columns.Count; i++)
                {
                    if (dgvExhibits.Columns[i].HeaderText.Contains('_')) dgvExhibits.Columns[i].HeaderText = dgvExhibits.Columns[i].HeaderText.Replace("_", " ");
                }
            }
        }

        //выбор фильтра
        void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT Экспонаты.exhibitionName, Общие.*, " + selectedFund + ".* FROM Экспонаты, " + selectedFund + ", Общие WHERE Экспонаты.idExhibition = " + selectedFund + ".idExhibition AND Экспонаты.idExhibition = Общие.idExhibition";
            queryColor = "SELECT Экспонаты.*, Общие.*, " + selectedFund + ".* FROM Экспонаты, " + selectedFund + ", Общие WHERE Экспонаты.idExhibition = " + selectedFund + ".idExhibition AND Экспонаты.idExhibition = Общие.idExhibition";
            string table;
            if (Convert.ToInt32((sender as ComboBox).Tag) > generalCount) table = tvFund.SelectedNode.Text;
            else table = "Общие";
            string criterion = table + "." + (sender as ComboBox).Name.ToString() + " = '" + (sender as ComboBox).SelectedItem.ToString() + "'";
            arQueryConstructorAttributesValues[Convert.ToInt32((sender as ComboBox).Tag) - 1] = criterion;

            for (int i = 0; i < arQueryConstructorAttributesValues.Length; i++)
            {
                if (arQueryConstructorAttributesValues[i] != null)
                {
                    query = query + " AND " + arQueryConstructorAttributesValues[i];
                    queryColor = queryColor + " AND " + arQueryConstructorAttributesValues[i];
                }
            }
            exhibitsExtract(query, 0);

        }

        //выбор фонда
        private void tvFund_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (firstSelection != true)
            {
                if (tvFund.SelectedNode != tvFund.Nodes[0])
                {
                    string query = "SELECT Экспонаты.exhibitionName, Общие.*, " + tvFund.SelectedNode.Text + ".* FROM Экспонаты, " + tvFund.SelectedNode.Text + ", Общие WHERE Экспонаты.idExhibition = " + tvFund.SelectedNode.Text + ".idExhibition AND Экспонаты.idExhibition = Общие.idExhibition";
                    selectedFund = tvFund.SelectedNode.Text;
                    exhibitsExtract(query, 0);
                    filtersExtract();
                }
                else
                {
                    dgvExhibits.DataSource = null;
                    pFilters.Controls.Clear();
                    lblFind.Text = "Найдено: 0";
                }
                Array.Clear(arQueryConstructorAttributesValues, 0, arQueryConstructorAttributesValues.Length);
            }
            firstSelection = false;
        }

        //поиск
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (tbFind.Text != "")
            {
                string query = "SELECT Экспонаты.exhibitionName, Общие.* FROM Экспонаты, Общие WHERE Экспонаты.idExhibition = Общие.idExhibition AND Экспонаты.descriptionFind LIKE '%" + tbFind.Text + "%'";
                findStart = true;
                exhibitsExtract(query, 1);
            }
            else
            {
                MessageBox.Show("Введите текст для поиска");
            }
        }

        //добавление экспоната
        private void addExhibit(object sender, EventArgs e)
        {

            foreach (DataGridViewCell dgvCell in dgvExhibits.SelectedCells)
            {
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Visible == true) attr.Add(dgvCell.Value.ToString());
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "Общие.idExhibition") id = (int)dgvCell.Value;
            }

            if (tvFund.SelectedNode != tvFund.Nodes[0])
            {
                fAdd frmAddExh = new fAdd();
                frmAddExh.Owner = this;
                frmAddExh.connection_string = connection_string;
                frmAddExh.selectedFund = selectedFund;
                frmAddExh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите один из фондов!");
            }
        }

        //редактирование экспоната
        public void editExhibit(object sender, EventArgs e)
        {
            attr.Clear();
            kp = "";
            id = 0;
            foreach (DataGridViewCell dgvCell in dgvExhibits.SelectedCells)
            {
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Visible == true) attr.Add(dgvCell.Value.ToString());
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "КП_номер") kp = dgvCell.Value.ToString();
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "Общие.idExhibition") id = (int)dgvCell.Value;
            }

            if (tvFund.SelectedNode != tvFund.Nodes[0])
            {
                fEdit frmEditExh = new fEdit();
                frmEditExh.Owner = this;
                frmEditExh.connection_string = connection_string;
                frmEditExh.selectedFund = selectedFund;
                frmEditExh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите один из фондов!");
            }
        }

        //удаление экспоната
        private void deleteExhibit(object sender, EventArgs e)
        {
            string sql;
            id = 0;
            foreach (DataGridViewCell dgvCell in dgvExhibits.SelectedCells)
            {
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "Общие.idExhibition") id = (int)dgvCell.Value;
            }
            sql = "DELETE FROM Экспонаты WHERE idExhibition = " + id;
            sqlQuery(sql);

            sql = "DELETE FROM Общие WHERE idExhibition = " + id;
            sqlQuery(sql);

            sql = "DELETE FROM " + selectedFund + " WHERE idExhibition = " + id;
            sqlQuery(sql);

            refresh();
        }

        //просмотр экспоната
        private void viewExhibit(object sender, EventArgs e)
        {
            attr.Clear();
            kp = "";
            id = 0;
            foreach (DataGridViewCell dgvCell in dgvExhibits.SelectedCells)
            {
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Visible == true) attr.Add(dgvCell.Value.ToString());
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "КП_номер") kp = dgvCell.Value.ToString();
                if (dgvExhibits.Columns[dgvCell.ColumnIndex].Name == "Общие.idExhibition") id = (int)dgvCell.Value;
            }

            if (tvFund.SelectedNode != tvFund.Nodes[0])
            {
                fViewExhibit frmViewExh = new fViewExhibit();
                frmViewExh.Owner = this;
                frmViewExh.connection_string = connection_string;
                frmViewExh.selectedFund = selectedFund;
                frmViewExh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите один из фондов!");
            }
        }

        //обновление ds после операции
        public void refresh()
        {
            string query = "SELECT Экспонаты.exhibitionName, Общие.*, " + tvFund.SelectedNode.Text + ".* FROM Экспонаты, " + tvFund.SelectedNode.Text + ", Общие WHERE Экспонаты.idExhibition = " + tvFund.SelectedNode.Text + ".idExhibition AND Экспонаты.idExhibition = Общие.idExhibition";
            exhibitsExtract(query, 0);
            filtersExtract();
        }

        //открыть редактор коллекций
        private void collectionEditor(object sender, EventArgs e)
        {
            fColEdit frmColEdit = new fColEdit();
            frmColEdit.Owner = this;
            frmColEdit.ShowDialog();
        }

        //добавить в отчёт
        private void addToReport(object sender, EventArgs e)
        {
            if (reportExists == false)
            {
                frmReport = new fReport();
                reportExists = true;
                frmReport.Owner = this;

                frmReport.Show();

                frmReport.Left = this.Left + this.Width;
                frmReport.Top = this.Top;
                frmReport.Height = this.Height;

                DataColumn colNumber = new DataColumn("№ п/п", Type.GetType("System.String"));
                //colNumber.AutoIncrement = true;
                //colNumber.AutoIncrementSeed = 1;
                //colNumber.AutoIncrementStep = 1;

                DataColumn colName = new DataColumn("Наименование, краткое описание\nМатериал, техника, размер", Type.GetType("System.String"));

                DataColumn colKP = new DataColumn("КП (инвентарный номер)", Type.GetType("System.String"));

                DataColumn colSave = new DataColumn("Сохранность", Type.GetType("System.String"));

                DataColumn colPrice = new DataColumn("Страховая стоимость, руб.", Type.GetType("System.String"));

                frmReport.dtExhInReport.Columns.Add(colNumber);
                frmReport.dtExhInReport.Columns.Add(colName);
                frmReport.dtExhInReport.Columns.Add(colKP);
                frmReport.dtExhInReport.Columns.Add(colSave);
                frmReport.dtExhInReport.Columns.Add(colPrice);
            }

            DataRow drExhibit = frmReport.dtExhInReport.NewRow();

            string name = dgvExhibits.SelectedRows[0].Cells["exhibitionName"].Value.ToString();
            string kp = dgvExhibits.SelectedRows[0].Cells["КП_номер"].Value.ToString();
            string save = dgvExhibits.SelectedRows[0].Cells["Сохранность"].Value.ToString();
            string price = dgvExhibits.SelectedRows[0].Cells["Страховая_стоимость"].Value.ToString();

            int maxNum = 0;

            foreach (DataRow row in frmReport.dtExhInReport.Rows)
            {
                maxNum++;
            }

            drExhibit.ItemArray = new object[] {maxNum + 1, name, kp, price};

            frmReport.dtExhInReport.Rows.Add(drExhibit);
        }

        //перетаскивание формы
        private void locChanged(object sender, EventArgs e)
        {
            if (reportExists == true)
            {
                frmReport.Left = this.Left + this.Width;
                frmReport.Top = this.Top;
            }
        }

        //изменение размеров формы
        private void sizeChanged(object sender, EventArgs e)
        {
            if (reportExists == true)
            {
                frmReport.Left = this.Left + this.Width;
                frmReport.Top = this.Top;
                frmReport.Height = this.Height;
            }
        }

        //открытые контекстного меню
        private void openCMS(object sender, CancelEventArgs e)
        {
            if (dgvExhibits.Rows.Count > 0)
            {
                cmsDGV.Items[0].Enabled = true;
                cmsDGV.Items[1].Enabled = true;
                cmsDGV.Items[2].Enabled = true;
                cmsDGV.Items[3].Enabled = true;
            }
            else
            {
                if (tvFund.SelectedNode.Text.Contains("Фонды") == true) cmsDGV.Items[0].Enabled = false;
                else cmsDGV.Items[0].Enabled = true;
                cmsDGV.Items[1].Enabled = false;
                cmsDGV.Items[2].Enabled = false;
                cmsDGV.Items[3].Enabled = false;
            }
        }

        //щелчок на строке
        private void dgvExhibits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(rowInd.ToString());
            
            if ((rowInd != 404) & (rowInd <= dgvExhibits.Rows.Count)) dgvExhibits.Rows[rowInd].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
            if (rowInd <= dgvExhibits.Rows.Count) dgvExhibits.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            rowInd = e.RowIndex;

        }

        //цветно-бесцветно
        private void tsbColoringMode_Click(object sender, EventArgs e)
        {
            if (coloringMode == true)
            {
                coloringMode = false;
                tslColoringMode.Text = "ОСЭ (цвет): выкл.";
                refresh();
            }
            else
            {
                coloringMode = true;
                tslColoringMode.Text = "ОСЭ (цвет): вкл.";
                refresh();
            }
        }

    }
}