using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace museum
{
    public partial class fColEdit : Form
    {
        bool firstSelection = true;
        string selectedFund = "";
        List<string> attrNames = new List<string>();

        public fColEdit()
        {
            InitializeComponent();
        }

        //после загрузки формы
        private void fColEdit_Load(object sender, EventArgs e)
        {
            fundsExtract();
        }

        //извлечение коллекций
        void fundsExtract()
        {
            fView frmMain = this.Owner as fView;

            if (frmMain.admin == true)
            {
                tsbtnAddCol.Enabled = true;
                tspbtnDelCol.Enabled = true;
                tsbtnAddCol.Enabled = true;

                OleDbConnection connection = new OleDbConnection(frmMain.connection_string);
                connection.Open();
                DataTable dtFunds = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                connection.Close();

                tvFund.Nodes.Add("Фонды:");
                foreach (DataRow item in dtFunds.Rows)
                {
                    if ((string)item["TABLE_NAME"] != "Экспонаты" & (string)item["TABLE_NAME"] != "Пользователи")
                    {
                        tvFund.Nodes[0].Nodes.Add((string)item["TABLE_NAME"]);
                    }
                }
                tvFund.ExpandAll();
            }
            else
            {
                tsbtnAddCol.Enabled = false;
                tspbtnDelCol.Enabled = false;
                tsbtnAddCol.Enabled = false;

                string sql = "SELECT * FROM Пользователи WHERE user = '" + frmMain.user + "'";
                string[] collections;
                DataSet dsCollections = new DataSet();

                OleDbConnection connection = new OleDbConnection(frmMain.connection_string);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                OleDbCommandBuilder comBuilder1 = new OleDbCommandBuilder(adapter);
                dsCollections = new DataSet();
                adapter.Fill(dsCollections, "Collections");
                connection.Close();

                string bufCollections = dsCollections.Tables[0].Rows[0][2].ToString();
                collections = bufCollections.Remove(bufCollections.Length - 1).Split('|');

                tvFund.Nodes.Add("Фонды:");
                foreach (string str in collections)
                {
                    tvFund.Nodes[0].Nodes.Add(str);
                }
                tvFund.ExpandAll();
            }
        }

        //выбор фонда
        private void selectFund(object sender, TreeViewEventArgs e)
        {
            if (firstSelection != true)
            {
                selectedFund = tvFund.SelectedNode.Text;

                if (tvFund.SelectedNode.Text != "Фонды:")
                {
                    fView frmMain = this.Owner as fView;
                    string sql = "SELECT * FROM " + selectedFund + " WHERE idExhibition = 1";
                    DataSet dsAttributes = new DataSet();

                    lbAttr.Items.Clear();
                    attrNames.Clear();

                    OleDbConnection connection = new OleDbConnection(frmMain.connection_string);
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                    OleDbCommandBuilder comBuilder1 = new OleDbCommandBuilder(adapter);
                    dsAttributes = new DataSet();
                    adapter.Fill(dsAttributes, "Attributes");
                    connection.Close();

                    foreach (DataColumn dcAttr in dsAttributes.Tables[0].Columns)
                    {
                        if (dcAttr.ToString() != "idExhibition")
                        {
                            if (dcAttr.ToString().Contains('_')) lbAttr.Items.Add(dcAttr.ToString().Replace("_", " "));
                            else lbAttr.Items.Add(dcAttr.ToString());

                            attrNames.Add(dcAttr.ToString());
                        }
                    }

                    lblFindCount.Text = "Найдено: " + lbAttr.Items.Count.ToString();
                }
                else
                {
                    tbAttr.Text = "";
                    lbNewAttr.Items.Clear();
                    lbAttr.Items.Clear();
                    lblFindCount.Text = "Найдено: 0";
                }
            }
            else firstSelection = false;
        }

        private void attrSelect(object sender, EventArgs e)
        {
            MessageBox.Show(attrNames[lbAttr.SelectedIndex]);
        }

        //активация, деактивация пунктов контекстного меню
        private void cmsLBAttrOpening(object sender, CancelEventArgs e)
        {
            if (lbAttr.Items[lbAttr.SelectedIndex].ToString().Contains("Удалено:"))
            {
                (sender as ContextMenuStrip).Items[0].Enabled = true;
                (sender as ContextMenuStrip).Items[1].Enabled = false;
            }
            else
            {
                (sender as ContextMenuStrip).Items[0].Enabled = false;
                (sender as ContextMenuStrip).Items[1].Enabled = true;
            }
        }

        //удаление атрибута
        private void attrDelete(object sender, EventArgs e)
        {
            if ((lbAttr.Items[lbAttr.SelectedIndex].ToString() == "КП номер") | 
                (lbAttr.Items[lbAttr.SelectedIndex].ToString() == "Инвентарный номер") | 
                (lbAttr.Items[lbAttr.SelectedIndex].ToString() == "Сохранность") | 
                (lbAttr.Items[lbAttr.SelectedIndex].ToString() == "Фото") | 
                (lbAttr.Items[lbAttr.SelectedIndex].ToString() == "Страховая стоимость"))
            {
                MessageBox.Show("Удаление данного атрибута невозможно!");
            }
            else
            {
                lbAttr.Items[lbAttr.SelectedIndex] = "Удалено: " + lbAttr.Items[lbAttr.SelectedIndex].ToString();
            }
        }

        //удалить новый атрибут
        private void deleteNewAttr(object sender, EventArgs e)
        {
            lbNewAttr.Items.RemoveAt(lbNewAttr.SelectedIndex);
        }

        //восстановить атрибут
        private void attrRestore(object sender, EventArgs e)
        {
            lbAttr.Items[lbAttr.SelectedIndex] = lbAttr.Items[lbAttr.SelectedIndex].ToString().Remove(0, 9);
        }

        //добавление атрибута
        private void addAttr(object sender, EventArgs e)
        {
            if (tbAttr.Text != "" && tbAttr.Text.Contains("Удалено:") == false) lbNewAttr.Items.Add(tbAttr.Text);
            else MessageBox.Show("Поле не заполнено либо содержит недопустимые символы (слова)!");
        }

        //сохранить изменения
        private void saveChanges(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;

            OleDbConnection connection = new OleDbConnection(frmMain.connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + selectedFund, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            DataSet dsBuffer = new DataSet();
            adapter.Fill(dsBuffer, "Rows");
            connection.Close();

            //добавление
            if (lbNewAttr.Items.Count > 0)
            {
                for (int i = 0; i < lbNewAttr.Items.Count; i++)
                {
                    if (lbNewAttr.Items[i].ToString().Contains(' ')) lbNewAttr.Items[i] = lbNewAttr.Items[i].ToString().Replace(" ", "_");
                    string sqlQuery = "ALTER TABLE " + selectedFund + " ADD COLUMN [" + lbNewAttr.Items[i].ToString() + "] text(255)";
                    frmMain.sqlQuery(sqlQuery);

                    for (int j = 0; j < dsBuffer.Tables[0].Rows.Count; j++)
                    {
                        sqlQuery = "UPDATE " + selectedFund + " SET [" + lbNewAttr.Items[i].ToString() + "] = ''";
                        frmMain.sqlQuery(sqlQuery);
                    }
                }
            }

            //удаление атрибута
            for (int i = 0; i < lbAttr.Items.Count; i++)
            {
                if (lbAttr.Items[i].ToString().Contains("Удалено: "))
                {
                    connection = new OleDbConnection(frmMain.connection_string);
                    frmMain.sqlQuery("ALTER TABLE " + selectedFund + " DROP [" + attrNames[i] + "]");
                }
            }

            tbAttr.Text = "";
            lbAttr.Items.Clear();
            lbNewAttr.Items.Clear();

            frmMain.tvFund.Nodes.Clear();
            frmMain.fundsExtract();
            frmMain.selectedFund = frmMain.tvFund.Nodes[0].Nodes[0].Text;
            frmMain.filtersExtract();
        }

        //добавление коллекции
        private void addCollection(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;

            if ((sender as ToolStripButton).Name == "tsbtnAddCol")
            {
                tslblCollName.Visible = true;
                tstbCollName.Visible = true;
                tsbtnCollName.Visible = true;
                tssepCollName.Visible = true;
                tsbtnCollNameCancel.Visible = true;
            }
            else
            {
                try
                {
                    tslblCollName.Visible = false;
                    tstbCollName.Visible = false;
                    tsbtnCollName.Visible = false;
                    tssepCollName.Visible = false;
                    tsbtnCollNameCancel.Visible = false;

                    if (tstbCollName.Text != "")
                    {
                        frmMain.sqlQuery("CREATE TABLE " + tstbCollName.Text + " (idExhibition int)");
                        tvFund.Nodes.Clear();
                        fundsExtract();
                        frmMain.tvFund.Nodes.Clear();
                        frmMain.firstSelection = true;
                        frmMain.fundsExtract();
                    }
                    else MessageBox.Show("Введите название коллекции!");

                    tstbCollName.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //отмена добавления
        private void addCollectionCancel(object sender, EventArgs e)
        {
            tslblCollName.Visible = false;
            tstbCollName.Visible = false;
            tstbCollName.Text = "";
            tsbtnCollName.Visible = false;
            tssepCollName.Visible = false;
            tsbtnCollNameCancel.Visible = false;
        }

        //удаление коллекции
        private void delCollection(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;

            if (tvFund.SelectedNode.Text != "Фонды:")
            {
                if (tvFund.SelectedNode.Text != "Общие")
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить коллекцию '" + tvFund.SelectedNode.Text + "'?", "Удаление коллекции", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string sql = "SELECT * FROM " + tvFund.SelectedNode.Text;
                        string selFund = tvFund.SelectedNode.Text;

                        OleDbConnection connection = new OleDbConnection(frmMain.connection_string);

                        connection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                        OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
                        DataSet dsDelExh = new DataSet();
                        adapter.Fill(dsDelExh, "delExhibition");
                        connection.Close();

                        for (int i = 0; i < dsDelExh.Tables[0].Rows.Count; i++)
                        {
                            frmMain.sqlQuery("DELETE FROM Общие WHERE idExhibition = " + dsDelExh.Tables[0].Rows[i]["idExhibition"]);
                            frmMain.sqlQuery("DELETE FROM Экспонаты WHERE idExhibition = " + dsDelExh.Tables[0].Rows[i]["idExhibition"]);
                        }

                        frmMain.sqlQuery("DROP TABLE " + tvFund.SelectedNode.Text);

                        MessageBox.Show("Коллекция '" + selFund + "' удалена!");

                        tvFund.Nodes.Clear();
                        fundsExtract();
                        frmMain.firstSelection = true;
                        frmMain.tvFund.Nodes.Clear();
                        frmMain.fundsExtract();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //ничего
                    }
                }
                else MessageBox.Show("Нельзя удалить данную коллекцию!");
            }
            else MessageBox.Show("Выберите один из фондов!");
        }

        //закрытие 
        private void fColEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            fView frmMain = this.Owner as fView;

            firstSelection = true;
            frmMain.firstSelection = true;
        }

        private void tbAttr_TextChanged(object sender, EventArgs e)
        {
            if (tbAttr.Text.Contains('-'))
            {
                tbAttr.Text = tbAttr.Text.Substring(0, tbAttr.Text.Length - 1);
                MessageBox.Show("Название атрибута не может содержать знак '-'!");
            }
        }
    }
}
