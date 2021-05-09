using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace museum
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        //проверка введённых данных
        private void login(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;
            string connection_string = frmMain.connection_string;
            string sql = "SELECT * FROM Пользователи WHERE user = '" + tbLogin.Text + "' AND password = '" + tbPass.Text + "'";
            DataSet dsBuffer = new DataSet();

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            OleDbCommandBuilder comBuilder1 = new OleDbCommandBuilder(adapter);
            dsBuffer = new DataSet();
            adapter.Fill(dsBuffer, "login");
            connection.Close();

            if (dsBuffer.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Авторизация успешна!");
                frmMain.user = dsBuffer.Tables[0].Rows[0]["user"].ToString();
                if (dsBuffer.Tables[0].Rows[0]["adminornot"].ToString() != "1")
                {
                    frmMain.fundsAccess.AddRange(dsBuffer.Tables[0].Rows[0]["fundAccess"].ToString().Split('|'));
                    frmMain.admin = false;
                }
                else
                {
                    frmMain.admin = true;
                    frmMain.fundsAccess.Clear();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователь с такой парой логин - пароль не найдел либо данные введены неверно!");
            }
            
        }

        //отмена и выход из приложения
        private void close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //регистрация
        private void registration(object sender, EventArgs e)
        {
            fView frmMain = this.Owner as fView;
            string connection_string = frmMain.connection_string;
            string sql = "SELECT * FROM Пользователи WHERE user = '" + tbLogin.Text + "' AND password = '" + tbPass.Text + "'";
            DataSet dsBuffer = new DataSet();

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            OleDbCommandBuilder comBuilder1 = new OleDbCommandBuilder(adapter);
            dsBuffer = new DataSet();
            adapter.Fill(dsBuffer, "login");
            connection.Close();

            if (dsBuffer.Tables[0].Rows.Count > 0 && dsBuffer.Tables[0].Rows[0]["adminornot"].ToString() == "1")
            {
                fReg fReg = new fReg();

                fReg.Owner = this;
                fReg.ShowDialog();
            }
            else
            {
                MessageBox.Show("На выполнение данного действия имеет права только администратор!");
            }

        }

        private void enterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin.PerformClick();
            }
        }

    }
}
