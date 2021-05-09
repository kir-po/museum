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
    public partial class fViewExhibit : Form
    {
        public string selectedFund;
        public string connection_string;
        public DataSet dsAttr;

        public fViewExhibit()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void fViewExhibit_Load(object sender, EventArgs e)
        {
            filtersExtract();
            this.Text = "Просмотр экспоната из коллекции '" + selectedFund + "'";
        }

        //изменить экспонат
        private void toEdit(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;
            this.Hide();
            frmMain.editExhibit(selectedFund as object, EventArgs.Empty);
            this.Close();
        }

        //извлечение атрибутов
        void filtersExtract()
        {
            fView frmMain = this.Owner as fView;

            if (selectedFund != "Фонды:")
            {
                string[] sqls = new string[] {"SELECT Экспонаты.exhibitionName, Общие.* FROM Экспонаты, Общие","SELECT * FROM " + selectedFund};
                attrFill(sqls);

                attrValueFill();
            }
        }

        //выполнение запросов на добавление атрибутов
        void attrFill(string[] query)
        {

            foreach (string sql in query)
            {
                //извлечение атрибутов
                OleDbConnection connection = new OleDbConnection(connection_string);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
                dsAttr = new DataSet();
                adapter.Fill(dsAttr, "attributes");
                connection.Close();

                //удаление ненужных столцов из DataSet
                dsAttr.Tables[0].Columns.Remove("idExhibition");
                if (sql == "SELECT Экспонаты.exhibitionName, Общие.* FROM Экспонаты, Общие") dsAttr.Tables[0].Columns.Remove("Фото");

                //создание полей для ввода атрибутов
                for (int i = 0; i < dsAttr.Tables[0].Columns.Count; i++)
                {
                    Label tbAttr = new Label();
                    Label lblAttr = new Label();
                    FlowLayoutPanel flpAttrBuffer = new FlowLayoutPanel();

                    tbAttr.AutoSize = true;

                    lblAttr.AutoSize = true;
                    lblAttr.Font = new Font(lblAttr.Font, lblAttr.Font.Style | FontStyle.Bold);

                    flpAttrBuffer.AutoSize = true;
                    flpAttrBuffer.Dock = DockStyle.Fill;
                    flpAttrBuffer.FlowDirection = FlowDirection.TopDown;
                    flpAttrBuffer.WrapContents = false;

                    if (dsAttr.Tables[0].Columns[i].ToString().Contains('_')) lblAttr.Text = dsAttr.Tables[0].Columns[i].ToString().Replace("_", " ");
                    else lblAttr.Text = dsAttr.Tables[0].Columns[i].ToString();
                    if (dsAttr.Tables[0].Columns[i].ToString() == "exhibitionName") lblAttr.Text = "Название экспоната";
                    lblAttr.Text = lblAttr.Text + ":";

                    tbAttr.Name = dsAttr.Tables[0].Columns[i].ToString();

                    flpAttrBuffer.Controls.Add(lblAttr);
                    flpAttrBuffer.Controls.Add(tbAttr);
                    tlpAttr.Controls.Add(flpAttrBuffer);
                }
            }

            dsAttr.Tables[0].Clear();
            this.Width = this.Width + 17;
        }

        //заполнение значениями текстбоксов
        void attrValueFill()
        {
            fView frmMain = this.Owner as fView;
            foreach (FlowLayoutPanel flpBuf in tlpAttr.Controls)
            {
                foreach (Control tb in flpBuf.Controls)
                {
                    if (tb.Name.ToString() != "")
                    {
                        if (frmMain.attr[0] != "") tb.Text = frmMain.attr[0];
                        else tb.Text = "-";
                        frmMain.attr.RemoveAt(0);
                    }
                }
            }

            existsImageFill();
        }

        //заполнение списка существующих изображений
        void existsImageFill()
        {
            fView frmMain = this.Owner as fView;

            if (Directory.Exists(frmMain.resPath + selectedFund + @"\" + frmMain.kp + @"\"))
            {
                string[] imagesInKp = Directory.GetFiles(frmMain.resPath + selectedFund + @"\" + frmMain.kp + @"\");

                FlowLayoutPanel flpImages = new FlowLayoutPanel();
                flpImages.AutoSize = true;

                if (imagesInKp.Length > 0)
                {
                    foreach (string path in imagesInKp)
                    {
                        PictureBox pbImage = new PictureBox();

                        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                        {
                            pbImage.Image = Image.FromStream(file);
                        }

                        pbImage.Width = 70;
                        pbImage.Height = 70;
                        pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                        pbImage.BorderStyle = BorderStyle.FixedSingle;
                        pbImage.Click += new EventHandler(pbImage_Click);
                        if (flpImages.Controls.Count == 0) pbMainImage.Image = pbImage.Image;

                        FlowLayoutPanel flpImageBuf = new FlowLayoutPanel();
                        flpImageBuf.Width = pbImage.Width + 4;
                        flpImageBuf.Height = pbImage.Height + 4;
                        flpImageBuf.FlowDirection = FlowDirection.TopDown;
                        flpImageBuf.WrapContents = false;
                        flpImageBuf.Controls.Add(pbImage);

                        flpImages.Controls.Add(flpImageBuf);
                    }

                    tlpImages.Controls.Add(flpImages);


                    //если изображения не привязаны
                }
                else
                {
                    Label lblNoImages = new Label();

                    lblNoImages.Text = "Изображения отсутствуют!";
                    lblNoImages.AutoSize = true;
                    lblNoImages.Top = tlpImages.Height / 2 - lblNoImages.Height / 2;
                    lblNoImages.Left = tlpImages.Width / 2 - lblNoImages.Width / 2 - 38;
                    lblNoImages.Font = new Font(lblNoImages.Font, lblNoImages.Font.Style | FontStyle.Bold);

                    tlpImages.Controls.Add(lblNoImages);
                }
            }
            else
            {
                Label lblNoImages = new Label();

                lblNoImages.Text = "Изображения отсутствуют!";
                lblNoImages.AutoSize = true;
                lblNoImages.Top = tlpImages.Height / 2 - lblNoImages.Height / 2;
                lblNoImages.Left = tlpImages.Width / 2 - lblNoImages.Width / 2 - 38;
                lblNoImages.Font = new Font(lblNoImages.Font, lblNoImages.Font.Style | FontStyle.Bold);

                tlpImages.Controls.Add(lblNoImages);
            }
        }

        //выбор изображения
        void pbImage_Click(object sender, EventArgs e)
        {
            pbMainImage.Image = (sender as PictureBox).Image;
        }
    }
}
