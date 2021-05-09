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
    public partial class fReg : Form
    {
        string connection_string = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\museum.mdb";
        string editingUser;

        bool existsUserEdit = false;

        DataSet dsUsers = new DataSet();
        DataSet dsCollections = new DataSet();

        public fReg()
        {
            InitializeComponent();

            loadUsers();
            loadCollections();
        }

        //sql-запрос
        public void sqlQuery(string sql)
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //загрузка существующих пользователей
        void loadUsers()
        {
            dsUsers.Clear();

            string sql = "SELECT * FROM Пользователи ORDER BY user";

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);

            adapter.Fill(dsUsers, "Users");
            connection.Close();

            string[] users = new string[dsUsers.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow usr in dsUsers.Tables[0].Rows)
            {
                users[i] = usr[0].ToString();
                i++;
            }

            cbUsers.Items.AddRange(users);
            existsUserEdit = false;
        }

        //загрузка существующих коллекций
        void loadCollections()
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            DataTable dtFunds = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            connection.Close();

            foreach (DataRow item in dtFunds.Rows)
            {
                if ((string)item["TABLE_NAME"] != "Экспонаты" & (string)item["TABLE_NAME"] != "Общие" & (string)item["TABLE_NAME"] != "Пользователи")
                {
                    clbCollections.Items.Add(item["TABLE_NAME"].ToString());
                }
            }
        }

        //создать нового пользоователя
        private void newUser(object sender, EventArgs e)
        {
            existsUserEdit = false;
            btnDeleteUser.Enabled = false;
            tbLogin.Text = "";
            tbPass.Text = "";
            cbUsers.Text = "";
            clbCollections.Enabled = true;

            for (int i = 0; i < clbCollections.Items.Count; i++)
            {
                clbCollections.SetItemChecked(i, false);
            }
        }

        //выбор существующего пользователя
        private void selectExistsUser(object sender, EventArgs e)
        {
            DataSet dsBufUser = new DataSet();

            existsUserEdit = true;
            btnDeleteUser.Enabled = true;
            editingUser = (sender as ComboBox).SelectedItem.ToString();

            string sql = "SELECT * FROM Пользователи WHERE user = '" + (sender as ComboBox).SelectedItem.ToString() + "'";
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            adapter.Fill(dsBufUser, "Users");
            connection.Close();

            tbLogin.Text = dsBufUser.Tables[0].Rows[0][0].ToString();
            tbPass.Text = dsBufUser.Tables[0].Rows[0][1].ToString();
            string bufAcces;
            if (dsBufUser.Tables[0].Rows[0][2].ToString() != "")
            {
                bufAcces = dsBufUser.Tables[0].Rows[0][2].ToString().Remove(dsBufUser.Tables[0].Rows[0][2].ToString().Length - 1);
            }
            else
            {
                bufAcces = "";
            }
            string[] access = bufAcces.Split('|');

            if (dsBufUser.Tables[0].Rows[0]["adminornot"].ToString() == "1") //если админ
            {
                cbAdminStatus.Checked = true;

                //проверка коллекций
                for (int i = 0; i < clbCollections.Items.Count; i++)
                {
                    clbCollections.SetItemChecked(i, true);
                }

                clbCollections.Enabled = false;
            }
            else //если не админ
            {
                cbAdminStatus.Checked = false;

                //проверка коллекций
                for (int i = 0; i < clbCollections.Items.Count; i++)
                {
                    clbCollections.SetItemChecked(i,false);
                }

                foreach (string usrAccess in access)
                {
                    for (int i = 0; i < clbCollections.Items.Count; i++)
                    {
                        if (clbCollections.Items[i].ToString() == usrAccess)
                        {
                            clbCollections.SetItemChecked(i,true);
                        }
                    }
                }
            }
        }

        //сохранить изменения
        private void saveUser(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPass.Text != "")
            {
                fView frmMain = this.Owner as fView;
                string access = "";
                string sql;

                if (cbAdminStatus.Checked != true)
                {
                    for (int i = 0; i < clbCollections.Items.Count; i++)
                    {
                        if (clbCollections.GetItemChecked(i)) access = access + clbCollections.Items[i].ToString() + @"|";
                    }
                }

                if (existsUserEdit == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите изменить данные пользователя '" + editingUser + "'?", "Редактирование существующего пользователя", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (cbAdminStatus.Checked == true) sql = "UPDATE Пользователи SET [user] = '" + tbLogin.Text + "', [password] = '" + tbPass.Text + "', [adminornot] = '1' WHERE user = '" + editingUser + "'";
                        else sql = "UPDATE Пользователи SET [user] = '" + tbLogin.Text + "', [password] = '" + tbPass.Text + "', [fundAccess] = '" + access + "', [adminornot] = '0' WHERE user = '" + editingUser + "'";

                        sqlQuery(sql);

                        MessageBox.Show("Данные пользователя '" + editingUser + "' изменены");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Данные пользователя " + editingUser + " не были изменены");
                    }

                    existsUserEdit = false;
                    btnDeleteUser.Enabled = false;
                    tbLogin.Text = "";
                    tbPass.Text = "";
                    cbUsers.Text = "";
                    clbCollections.Enabled = true;

                    for (int i = 0; i < clbCollections.Items.Count; i++)
                    {
                        clbCollections.SetItemChecked(i, false);
                    }
                }
                else
                {
                    if (cbAdminStatus.Checked == true) sql = "INSERT INTO Пользователи ([user], [password], [fundAccess], [adminornot]) values ('" + tbLogin.Text + "', '" + tbPass.Text + "', '', '1')";
                    else sql = "INSERT INTO Пользователи ([user], [password], [fundAccess], [adminornot]) values ('" + tbLogin.Text + "', '" + tbPass.Text + "', '" + access + "', '0')";

                    sqlQuery(sql);

                    MessageBox.Show("Пользователь добавлен!");

                    existsUserEdit = false;
                    btnDeleteUser.Enabled = false;
                    tbLogin.Text = "";
                    tbPass.Text = "";
                    cbUsers.Text = "";
                    clbCollections.Enabled = true;

                    for (int i = 0; i < clbCollections.Items.Count; i++)
                    {
                        clbCollections.SetItemChecked(i, false);
                    }
                }
                cbUsers.Items.Clear();
                loadUsers();
            }
            else MessageBox.Show("Поля 'Логин' и 'Пароль' не могут быть пустыми!");


        }

        //админ или нет?
        private void adminOrNot(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                clbCollections.Enabled = false;
            }
            else
            {
                clbCollections.Enabled = true;
            }
        }

        //удалить существующего пользователя
        private void deleteUser(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить пользователя '" + editingUser + "'?", "Удаление существующего пользователя", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                existsUserEdit = false;
                btnDeleteUser.Enabled = false;
                tbLogin.Text = "";
                tbPass.Text = "";
                cbUsers.Text = "";
                clbCollections.Enabled = true;

                for (int i = 0; i < clbCollections.Items.Count; i++)
                {
                    clbCollections.SetItemChecked(i, false);
                }

                string sql = "DELETE FROM Пользователи WHERE user = '" + editingUser + "'";
                sqlQuery(sql);

                cbUsers.Items.Clear();
                loadUsers();

                MessageBox.Show("Пользователь '" + editingUser + "' удалён!");
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Пользователь " + editingUser + " не был удалён!");
            }










            
        }
    }
}
