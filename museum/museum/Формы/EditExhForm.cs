using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace museum
{
    public partial class fEdit : Form
    {
        public string selectedFund;
        public string connection_string;
        public DataSet dsAttr;

        public fEdit()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            filtersExtract();
            this.Text = "Изменение экспоната из коллекции '" + selectedFund + "'";
        }

        //извлечение атрибутов
        void filtersExtract()
        {
            if (selectedFund != "Фонды:")
            {
                attrFill("SELECT Экспонаты.exhibitionName, Общие.* FROM Экспонаты, Общие", splitContainer1.Panel1);
                attrFill("SELECT * FROM " + selectedFund, splitContainer1.Panel2);

                attrValueFill();
            }
        }

        //выполнение запросов на добавление атрибутов
        void attrFill(string query, SplitterPanel p)
        {
            fView frmMain = this.Owner as fView;

            //извлечение атрибутов
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            dsAttr = new DataSet();
            adapter.Fill(dsAttr, "attributes");
            connection.Close();

            //удаление ненужных столцов из DataSet
            dsAttr.Tables[0].Columns.Remove("idExhibition");
            if (p == splitContainer1.Panel1) dsAttr.Tables[0].Columns.Remove("Фото");

            //создание полей для ввода атрибутов
            FlowLayoutPanel flpAttr = new FlowLayoutPanel();
            if (p == splitContainer1.Panel1) flpAttr.Name = "flpMain";
            else flpAttr.Name = "flpMisc";
            flpAttr.Dock = DockStyle.Fill;
            flpAttr.AutoSize = true;

            for (int i = 0; i < dsAttr.Tables[0].Columns.Count; i++)
            {
                TextBox tbAttr = new TextBox();
                ComboBox cbAttr = new ComboBox();
                DateTimePicker dtpAttr = new DateTimePicker();
                Label lblAttr = new Label();
                FlowLayoutPanel flpAttrBuffer = new FlowLayoutPanel();

                tbAttr.Width = 130;
                dtpAttr.Width = 130;
                dtpAttr.Format = DateTimePickerFormat.Custom;
                dtpAttr.CustomFormat = "dd.MM.yy' 'hh:mm:ss";
                dtpAttr.ValueChanged += new EventHandler(dtpAttr_ValueChanged);
                cbAttr.Width = 130;
                cbAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                switch (dsAttr.Tables[0].Columns[i].Caption)
                {
                    case "Способ_поступления":
                        cbAttr.Items.AddRange(frmMain.sposobPostupleniya);
                        break;
                    case "Типология_по_8-НК":
                        cbAttr.Items.AddRange(frmMain.tipologiyaPo8NK);
                        break;
                    case "Форма_собственности":
                        cbAttr.Items.AddRange(frmMain.formaSobstvennosti);
                        break;
                    case "Ограничение_на_публикацию_на_портале":
                        cbAttr.Items.AddRange(frmMain.ogranicheniye);
                        break;
                    case "Категория_ценности_музейного_предмета":
                        cbAttr.Items.AddRange(frmMain.kategoriyaCennosti);
                        break;
                }
                lblAttr.AutoSize = true;
                flpAttrBuffer.AutoSize = true;
                flpAttrBuffer.FlowDirection = FlowDirection.TopDown;
                flpAttrBuffer.WrapContents = false;

                if (dsAttr.Tables[0].Columns[i].ToString().Contains('_')) lblAttr.Text = dsAttr.Tables[0].Columns[i].ToString().Replace("_", " ");
                else lblAttr.Text = dsAttr.Tables[0].Columns[i].ToString();
                if (dsAttr.Tables[0].Columns[i].ToString() == "exhibitionName") lblAttr.Text = "Название экспоната";

                string bufLabelName = lblAttr.Text;
                if (lblAttr.Text.Length > 20)
                {
                    lblAttr.Text = lblAttr.Text.Substring(0, 17) + "...";
                    ToolTip tooltip = new ToolTip();
                    tooltip.AutoPopDelay = 5000;
                    tooltip.InitialDelay = 1000;
                    tooltip.ReshowDelay = 500;
                    tooltip.ShowAlways = true;

                    tooltip.SetToolTip(lblAttr, bufLabelName);
                }

                string bufDTPText = dtpAttr.Value.ToString();
                ToolTip tooltipDTP = new ToolTip();
                tooltipDTP.AutoPopDelay = 5000;
                tooltipDTP.InitialDelay = 1000;
                tooltipDTP.ReshowDelay = 500;
                tooltipDTP.ShowAlways = true;

                tooltipDTP.SetToolTip(dtpAttr, bufDTPText);

                tbAttr.Name = dsAttr.Tables[0].Columns[i].ToString();
                cbAttr.Name = dsAttr.Tables[0].Columns[i].ToString();
                dtpAttr.Name = dsAttr.Tables[0].Columns[i].ToString();

                tbAttr.Tag = i + 1;
                cbAttr.Tag = i + 1;

                flpAttrBuffer.Controls.Add(lblAttr);
                if ((dsAttr.Tables[0].Columns[i].Caption == "Способ_поступления") |
                    (dsAttr.Tables[0].Columns[i].Caption == "Типология_по_8-НК") |
                    (dsAttr.Tables[0].Columns[i].Caption == "Форма_собственности") |
                    (dsAttr.Tables[0].Columns[i].Caption == "Ограничение_на_публикацию_на_портале") |
                    (dsAttr.Tables[0].Columns[i].Caption == "Категория_ценности_музейного_предмета"))
                {
                    flpAttrBuffer.Controls.Add(cbAttr);
                }
                else if ((dsAttr.Tables[0].Columns[i].Caption == "Дата_записи_о_предмете_в_книге_поступлений_основного_фонда_музея"))
                {
                    flpAttrBuffer.Controls.Add(dtpAttr);
                }
                else flpAttrBuffer.Controls.Add(tbAttr);
                flpAttr.Controls.Add(flpAttrBuffer);
            }
            p.Controls.Clear();
            dsAttr.Tables[0].Clear();
            p.Controls.Add(flpAttr);
        }

        //привязка подсказки при изменении даты
        void dtpAttr_ValueChanged(object sender, EventArgs e)
        {
            string bufDTPText = (sender as DateTimePicker).Value.ToString();
            ToolTip tooltipDTP = new ToolTip();
            tooltipDTP.AutoPopDelay = 5000;
            tooltipDTP.InitialDelay = 1000;
            tooltipDTP.ReshowDelay = 500;
            tooltipDTP.ShowAlways = true;
            tooltipDTP.SetToolTip((sender as DateTimePicker), bufDTPText);
        }

        //заполнение значениями текстбоксов
        void attrValueFill()
        {
            fView frmMain = this.Owner as fView;

            foreach (FlowLayoutPanel flpBuf in (splitContainer1.Panel1.Controls["flpMain"] as FlowLayoutPanel).Controls)
            {
                foreach (Control tcb in flpBuf.Controls)
                {
                    if ((tcb.GetType().ToString() == "System.Windows.Forms.TextBox") | 
                        (tcb.GetType().ToString() == "System.Windows.Forms.ComboBox") |
                        (tcb.GetType().ToString() == "System.Windows.Forms.DateTimePicker"))
                    {
                        tcb.Text = frmMain.attr[0];
                        frmMain.attr.RemoveAt(0);
                    }
                }
            }

            foreach (FlowLayoutPanel flpBuf in (splitContainer1.Panel2.Controls["flpMisc"] as FlowLayoutPanel).Controls)
            {
                foreach (Control tcb in flpBuf.Controls)
                {
                    if ((tcb.GetType().ToString() == "System.Windows.Forms.TextBox") |
                        (tcb.GetType().ToString() == "System.Windows.Forms.ComboBox") |
                        (tcb.GetType().ToString() == "System.Windows.Forms.DateTimePicker"))
                    {
                        tcb.Text = frmMain.attr[0];
                        frmMain.attr.RemoveAt(0);
                    }
                }
            }
            existsImageFill();
        }

        //заполнение листбокса с существующими изображениями
        void existsImageFill()
        {
            fView frmMain = this.Owner as fView;

            if (Directory.Exists(frmMain.resPath + selectedFund + @"\" + frmMain.kp + @"\"))
            {
                string[] imagesInKp = Directory.GetFiles(frmMain.resPath + selectedFund + @"\" + frmMain.kp + @"\");
                lbExistsImg.Items.AddRange(imagesInKp);
            }
        }

        //отмена редактирования
        private void cancelAdd(object sender, EventArgs e)
        {
            this.Close();
        }

        //изменение экспоната
        private void addExhibit(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;
            string sql = "";
            string values_sql = "";
            string descriptionFind_sql = "";
            bool collectionOwner = false;

            foreach (string col in frmMain.fundsAccess)
            {
                if (col == selectedFund) collectionOwner = true;
            }

            if (collectionOwner == true | frmMain.admin == true)
            {
                foreach (FlowLayoutPanel flpBuf in (splitContainer1.Panel1.Controls["flpMain"] as FlowLayoutPanel).Controls)
                {
                    foreach (Control tcb in flpBuf.Controls)
                    {
                        if ((tcb.GetType().ToString() == "System.Windows.Forms.TextBox") |
                            (tcb.GetType().ToString() == "System.Windows.Forms.ComboBox") |
                            (tcb.GetType().ToString() == "System.Windows.Forms.DateTimePicker"))
                        {
                            if (tcb.Name == "exhibitionName")
                            {
                                sql = "UPDATE Экспонаты SET exportStatus = 'toCorrect(noXML)', exhibitionName = '" + tcb.Text + "', fundTable = '" + selectedFund + "' WHERE idExhibition = " + frmMain.id;
                                descriptionFind_sql = selectedFund + "_" + tcb.Text + "_";
                                //Вставка атрибутов в таблицу "Экспонаты", кроме "descriptionFind"
                                frmMain.editStatus = true;
                                frmMain.sqlQuery(sql);
                                sql = "UPDATE Общие SET ";
                            }
                            else
                            {
                                sql = sql + "[" + tcb.Name + "] = '" + tcb.Text + "', ";
                                values_sql = values_sql + "'" + tcb.Text + "', ";
                            }
                        }
                    }
                }
                //Вставка атрибутов в таблицу "Общие"
                sql = sql.Remove(sql.Length - 2) + " WHERE idExhibition = " + frmMain.id;
                values_sql = values_sql.Remove(values_sql.Length - 2);
                descriptionFind_sql = descriptionFind_sql + values_sql.Replace("'", "").Replace(", ", "_");
                frmMain.editStatus = true;
                frmMain.sqlQuery(sql);

                sql = "UPDATE " + selectedFund + " SET ";
                if (frmMain.exStatus == false)
                {
                    //Вставка атрибутов в таблицу выбранной коллекции
                    string selValues_sql = "";
                    foreach (FlowLayoutPanel flpBuf in (splitContainer1.Panel2.Controls["flpMisc"] as FlowLayoutPanel).Controls)
                    {
                        foreach (Control tcb in flpBuf.Controls)
                        {
                            if ((tcb.GetType().ToString() == "System.Windows.Forms.TextBox") |
                                (tcb.GetType().ToString() == "System.Windows.Forms.ComboBox") |
                                (tcb.GetType().ToString() == "System.Windows.Forms.DateTimePicker"))
                            {
                                sql = sql + "[" + tcb.Name + "] = '" + tcb.Text + "', ";
                                selValues_sql = selValues_sql + "'" + tcb.Text + "', ";
                            }
                        }
                    }

                    if ((splitContainer1.Panel2.Controls["flpMisc"] as FlowLayoutPanel).Controls.Count > 0)
                    {
                        sql = sql.Remove(sql.Length - 2) + " WHERE idExhibition = " + frmMain.id;
                        selValues_sql = selValues_sql.Remove(selValues_sql.Length - 2);
                        frmMain.editStatus = true;
                        frmMain.sqlQuery(sql);

                        //Вставка атрибутов в descriptionFind
                        sql = "UPDATE Экспонаты SET exportStatus = 'toCorrect(noXML)', descriptionFind = '" + descriptionFind_sql + "_" + selValues_sql.Replace("'", "").Replace(", ", "_") + "' WHERE idExhibition = " + frmMain.id;
                        frmMain.editStatus = true;
                        frmMain.sqlQuery(sql);
                    }
                    else
                    {
                        //Вставка атрибутов в descriptionFind
                        sql = "UPDATE Экспонаты SET exportStatus = 'toCorrect(noXML)', descriptionFind = '" + descriptionFind_sql + "' WHERE idExhibition = " + frmMain.id;
                        frmMain.editStatus = true;
                        frmMain.sqlQuery(sql);
                    }

                    //Редактирование изображений:
                    //изменение старых
                    pbImage.Image = null;
                    pbImage.Image = museum.Properties.Resources.image;
                    pbImage.Invalidate();

                    if (lbExistsImg.Items.Count > 0)
                    {
                        foreach (string imagePath in lbExistsImg.Items)
                        {
                            if (imagePath.Contains("Удалено: "))
                            {
                                try
                                {
                                    File.Delete(imagePath.Remove(0, 9));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }

                    //добавление новых
                    if (!(Directory.Exists(frmMain.resPath + selectedFund)))
                    {
                        Directory.CreateDirectory(frmMain.resPath + selectedFund);
                    }
                    if (!(Directory.Exists(frmMain.resPath + selectedFund + @"\" + frmMain.kp)))
                    {
                        Directory.CreateDirectory(frmMain.resPath + selectedFund + @"\" + frmMain.kp);
                    }
                    //если обе папки уже существуют
                    {
                        foreach (string imgPath in lbImages.Items)
                        {
                            File.Copy(imgPath, frmMain.resPath + selectedFund + @"\" + frmMain.kp + @"\" + (imgPath.Split('\u005c')).Last().ToString(), true);
                        }
                        frmMain.editStatus = true;
                        frmMain.sqlQuery("UPDATE Общие SET Фото = '" + frmMain.resPath + selectedFund + @"\" + frmMain.kp + "' WHERE idExhibition = " + frmMain.id);
                    }

                    MessageBox.Show("Экспонат обновлён");
                }
                lbImages.Items.Clear();
                lbExistsImg.Items.Clear();
                existsImageFill();
                frmMain.exStatus = false;
                frmMain.refresh();
            }
            else MessageBox.Show("У Вас нет доступа к этой коллекции");
        }

        //добавляем изображения в lbImages
        private void addImageToList(object sender, EventArgs e)
        {
            string[] picPathes;

            ofdAddPicture.Filter = "Изображения (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png|Все файлы (*.*)|*.*";
            if (ofdAddPicture.ShowDialog() == DialogResult.Cancel) return;
            picPathes = ofdAddPicture.FileNames;

            lbImages.Items.AddRange(picPathes);
            var items = lbImages.Items.Cast<string>().Distinct().ToList();
            lbImages.Items.Clear();
            items.ForEach(i => lbImages.Items.Add(i));

            lbImages.SelectedIndex = 0;
            using (var file = new FileStream(lbImages.Text, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
            {
                pbImage.Image = Image.FromStream(file);
            }

        }

        //выбор изображения
        private void lbImages_Click(object sender, EventArgs e)
        {
            string image;
            if ((sender as ListBox).Name == "lbImages")
            {
                if (lbImages.Items.Count > 0)
                {
                    image = lbImages.Text;
                    using (var file = new FileStream(image, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                    {
                        pbImage.Image = Image.FromStream(file);
                    }
                }
            }
            else
            {
                if (lbExistsImg.Items.Count > 0)
                {
                    if (!(lbExistsImg.Text.Contains("Удалено: ")))
                    {
                        if (lbExistsImg.SelectedIndex != -1)
                        {
                            image = lbExistsImg.Items[lbExistsImg.SelectedIndex].ToString();
                            using (var file = new FileStream(image, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                            {
                                pbImage.Image = Image.FromStream(file);
                            }
                        }
                    }
                    else
                    {
                        if (lbExistsImg.SelectedIndex != -1)
                        {
                            image = lbExistsImg.Items[lbExistsImg.SelectedIndex].ToString().Remove(0, 9);
                            using (var file = new FileStream(image, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                            {
                                pbImage.Image = Image.FromStream(file);
                            }
                        }
                    }
                }
            }
        }

        //всплывающее меню добавления изображений
        private void cmsImageAddOpening(object sender, CancelEventArgs e)
        {
            if (lbImages.SelectedIndex == -1) cmsImageAdd.Items[1].ForeColor = Color.Gray;
            else cmsImageAdd.Items[1].ForeColor = Color.Black;
        }

        //всплывающее меню редактирования существующих изображений
        private void cmsImageEditExistsOpening(object sender, CancelEventArgs e)
        {
            if (lbExistsImg.Items.Count > 0)
            {
                cmsImageEditExists.Items[0].Enabled = true;
                cmsImageEditExists.Items[1].Enabled = true;

                if (lbExistsImg.Items[lbExistsImg.SelectedIndex].ToString().Contains("Удалено"))
                {
                    cmsImageEditExists.Items[1].Visible = false;
                    cmsImageEditExists.Items[0].Visible = true;
                }
                else
                {
                    cmsImageEditExists.Items[1].Visible = true;
                    cmsImageEditExists.Items[0].Visible = false;
                }
            }
            else
            {
                cmsImageEditExists.Items[0].Enabled = false;
                cmsImageEditExists.Items[1].Enabled = false;
            }
        }

        //удалить изображение из списка
        private void imageDelete(object sender, EventArgs e)
        {
            if (lbImages.SelectedIndex != -1) lbImages.Items.RemoveAt(lbImages.SelectedIndex);
        }

        //восстановить в список существующих изображений
        private void restoreImage(object sender, EventArgs e)
        {
            lbExistsImg.Items[lbExistsImg.SelectedIndex] = lbExistsImg.Items[lbExistsImg.SelectedIndex].ToString().Remove(0, 9);
        }

        //удалить из списка существущих изображений
        private void deleteExistsImg(object sender, EventArgs e)
        {
            string selectedImage = lbExistsImg.Items[lbExistsImg.SelectedIndex].ToString();
            lbExistsImg.Items[lbExistsImg.SelectedIndex] = "Удалено: " + selectedImage;
        }
    }
}
