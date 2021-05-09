using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace museum
{
    public partial class fReport : Form
    {
        public DataTable dtExhInReport = new DataTable();

        public fReport()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void formLoad(object sender, EventArgs e)
        {
            dgvExhInReport.DataSource = dtExhInReport;
        }

        //закрытие формы
        private void formClosing(object sender, FormClosingEventArgs e)
        {
            fView frmMain = this.Owner as fView;

            frmMain.reportExists = false;
        }

        private void cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createForm(object sender, EventArgs e)
        {
            if (dtExhInReport.Rows.Count > 0)
            {
                Word.Application w = new Word.Application();

                //Заголовок документов
                w.Documents.Application.Caption = "Отчёт";
                object missing = System.Reflection.Missing.Value;

                //Создание нового документа
                Word.Document wReport = w.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Создание таблицы
                Word.Range rngReport = wReport.Range(0, 0);
                Word.Table tReport = wReport.Tables.Add(rngReport, dgvExhInReport.Rows.Count + 1, dgvExhInReport.Columns.Count, ref missing, ref missing);
                tReport.Borders.Enable = 1;
                tReport.Range.Paragraphs.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
                tReport.Range.Paragraphs.SpaceAfter = 0;

                foreach (Word.Row row in tReport.Rows)
                {
                    foreach (Word.Cell cell in row.Cells)
                    {
                        //MessageBox.Show("Номер строки: " + row.Index.ToString() + "; Номер ячейки: " + cell.ColumnIndex.ToString());
                        cell.Range.Font.Name = "times new roman";
                        cell.Range.Font.Size = 12;
                        cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                        if (row.Index == 1)
                        {
                            cell.Range.Text = dgvExhInReport.Columns[cell.ColumnIndex - 1].HeaderText;
                            cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        else
                        {
                            cell.Range.Text = dgvExhInReport.Rows[row.Index - 2].Cells[cell.ColumnIndex - 1].Value.ToString();
                            if (cell.ColumnIndex == 2)
                            {
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else
                            {
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                        }
                    }
                }

                w.Visible = true;
            }
            else
            {
                MessageBox.Show("Таблица не содержит строк!");
            }
        }

        //удаление экспоната из отчёта
        private void deleteExhFromReport(object sender, EventArgs e)
        {
            dtExhInReport.Rows[dgvExhInReport.SelectedRows[0].Index].Delete();

            int Num = 0;
            foreach (DataRow row in dtExhInReport.Rows)
            {
                Num++;
                row[0] = Num;
            }
        }

    }
}
