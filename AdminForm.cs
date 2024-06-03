﻿using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Authorization
{
    public partial class AdminForm : Form
    {
        Point NP; 
        bool but = false, sbut = false, rename = false;
        public bool admPanel = true;
        public string adminLogin, id, status;
        int lastID;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (!rename)
            adminName.Text = adminLogin;

            DataBase db = new DataBase();
            SqlCommand command = new SqlCommand("SELECT login from users", db.GetConnection());

            db.OpenConnection(); //Открываем соединение
            SqlDataReader read = command.ExecuteReader(); //Считываем и извлекаем данные
            while (read.Read()) //Читаем пока есть данные
            {
                Users.Items.Add(read.GetValue(0).ToString()); //Добавляем данные в лист аитем
            }
            db.CloseConnection(); //Закрываем соединение 
            Permissions();
        }

        private void Permissions()
        {
            if (!admPanel)
            {
                AdminButton.BackColor = Color.LightGray; superAdminButton.BackColor = Color.LightGray;
                superAdminButton.Enabled = false; superAdminBehindBox.Enabled = false;
                AdminButton.Enabled = false; AdminBehindBox.Enabled = false;

                if (statusField.Text == "superadmin")
                { DelUsrButton.Enabled = false; RenameUsrButton.Enabled = false; DelUsrButton.BackColor = Color.FromArgb(255, 215, 228, 242); 
                    RenameUsrButton.BackColor = Color.FromArgb(255, 215, 228, 242); }
                else 
                {
                    DelUsrButton.Enabled = true; DelUsrButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                    RenameUsrButton.Enabled = true; RenameUsrButton.BackColor = Color.FromArgb(255, 153, 180, 209);

                    if (loginField.Text == adminName.Text)
                    {
                        DelUsrButton.Enabled = false; DelUsrButton.BackColor = Color.FromArgb(255, 215, 228, 242);
                    }
                }            
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            PortalForm portal = new PortalForm();
            portal.userLogin = adminName.Text;
            portal.Show();
            this.Close();
        }

        private void AuthorizationText_MouseDown(object sender, MouseEventArgs e)
        {
            NP = new Point(e.X, e.Y);
        }

        private void AuthorizationText_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - NP.X;
                this.Top += e.Y - NP.Y;
            }
        }

        private void AdminButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (loginField.Text != "")
            {
                if (but == false)
                {
                    AdminButton.CheckState = CheckState.Indeterminate; AdminButton.BackColor = Color.FromArgb(255, 215, 228, 242);
                    AdminButton.Checked = true; AdminButton.Enabled = false;
                    AdminButton_GiveAdmin();
                }
                but = true;
            }
            else AdminButton.CheckState = CheckState.Unchecked;
        }

        private void AdminBehindBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (loginField.Text != "")
            {
                if (but == true && e.Button == MouseButtons.Left)
                {
                    AdminButton.CheckState = CheckState.Unchecked; AdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                    AdminButton.Enabled = true; AdminButton.Checked = false;
                    but = false;
                    AdminButton_DropAdmin();
                }
            }
        }

        private void superAdminButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (loginField.Text != "")
            {
                if (sbut == false)
                {
                    superAdminButton.CheckState = CheckState.Indeterminate; superAdminButton.BackColor = Color.FromArgb(255, 215, 228, 242);
                    superAdminButton.Checked = true; superAdminButton.Enabled = false;
                    superAdminButton_GiveSuperAdmin();
                }
                sbut = true;
            }
            else superAdminButton.CheckState = CheckState.Unchecked;
        }

        private void superAdminBehindBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (loginField.Text != "")
            {
                if (sbut == true && e.Button == MouseButtons.Left)
                {
                    superAdminButton.CheckState = CheckState.Unchecked; superAdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                    superAdminButton.Enabled = true; superAdminButton.Checked = false;
                    sbut = false;
                    superAdminButton_DropAdmin();
                }
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.Show();
            this.Close();
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (Users.SelectedItem != null) 
            {
                loginField.Text = Users.SelectedItem.ToString();

                DataBase db = new DataBase();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT u.name as name, u.surname surname, a.permissions adm " +
                                                    "from users u " +
                                                    "LEFT JOIN admins a on a.user_login = u.login " +
                                                    "where u.login = @UL ", db.GetConnection());

                command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                nameField.Text = table.Rows[0]["name"].ToString();
                surnameField.Text = table.Rows[0]["surname"].ToString();
                statusField.Text = table.Rows[0]["adm"].ToString();

                StatusInfo();
                Permissions();
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            Searching();
        }

        private void UserSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Searching();
            }
        }

        private void Searching()
        {
            Users.Items.Clear();
            AdminForm_Load(this, EventArgs.Empty);            

            if (UserSearching.Text != "")
            {
                ListBox temp = new ListBox();

                for (int i = 0; i < Users.Items.Count; i++)
                {
                    string compare = Convert.ToString(Users.Items[i]);
                    if (compare.IndexOf(UserSearching.Text) >= 0) temp.Items.Add(compare);
                }
                Users.Items.Clear();
                if (temp.Items.Count > 0)
                {
                    Users.Items.AddRange(temp.Items);
                }                
            }
            if (loginField.Text != "") Users.SelectedItem = loginField.Text;
        }

        private void CheckUserID()
        {
            if (loginField.Text != "")
            {
                DataBase db = new DataBase();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT id from users WHERE login = @UL", db.GetConnection());

                command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                id = table.Rows[0]["id"].ToString();
            }
        }

        private void StatusCheck()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT a.permissions " +
                                                    "from users u " +
                                                    "LEFT JOIN admins a on a.user_login = u.login " +
                                                    "WHERE login = @UL", db.GetConnection());

            command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            statusField.Text = table.Rows[0]["permissions"].ToString();
            StatusInfo();
        }

        private void StatusInfo()
        {
            if (statusField.Text == "")
            {
                statusField.Text = "user"; statusField.ForeColor = Color.Green;
                AdminButton.CheckState = CheckState.Unchecked; superAdminButton.CheckState = CheckState.Unchecked;
                AdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                AdminButton.Enabled = true; AdminButton.Checked = false; but = false;
                superAdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                superAdminButton.Enabled = true; superAdminButton.Checked = false; sbut = false;
            }
            if (statusField.Text == "0")
            {
                statusField.Text = "admin"; statusField.ForeColor = Color.Blue;
                AdminButton.CheckState = CheckState.Indeterminate; superAdminButton.CheckState = CheckState.Unchecked;
                AdminButton.BackColor = Color.FromArgb(255, 215, 228, 242);
                AdminButton.Checked = true; AdminButton.Enabled = false; but = true;
                superAdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                superAdminButton.Enabled = true; superAdminButton.Checked = false; sbut = false;
                AdminBehindBox.Enabled = true;
            }
            if (statusField.Text == "1")
            {
                statusField.Text = "superadmin"; statusField.ForeColor = Color.DarkOrchid;
                AdminButton.CheckState = CheckState.Indeterminate; superAdminButton.CheckState = CheckState.Indeterminate;
                AdminButton.BackColor = Color.LightGray; //FromArgb(255, 215, 228, 242);
                AdminButton.Checked = true; AdminButton.Enabled = false; but = true;
                superAdminButton.BackColor = Color.FromArgb(255, 215, 228, 242);
                superAdminButton.Checked = true; superAdminButton.Enabled = false; sbut = true;
                AdminBehindBox.Enabled = false;
            }
        }

        private void AdminButton_GiveAdmin()
        {
            if (loginField.Text != "" || loginField.Text == "user")
            {
                CheckUserID(); CheckLastID();

                DataBase db = new DataBase();
                SqlCommand command = new SqlCommand("INSERT INTO admins (id, user_id, user_login, permissions)" +
                                                        "VALUES (@id, @uID, @UL, 0) ", db.GetConnection());

                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = lastID + 1;
                command.Parameters.Add("@uID", SqlDbType.NVarChar).Value = id;
                command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;                

                db.OpenConnection();
                command.ExecuteReader();
                db.CloseConnection(); //Закрываем соединение                 

                StatusCheck();
            }
        }

        private int CheckLastID()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT id from admins " +
                                               "ORDER BY id DESC", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            lastID = Convert.ToInt32(table.Rows[0]["id"].ToString());
            return lastID;
        }

        private void AdminButton_DropAdmin()
        {
            if (superAdminButton.CheckState != CheckState.Indeterminate)
            {
                if (loginField.Text != "")
                {
                    DataBase db = new DataBase();
                    SqlCommand command = new SqlCommand("DELETE FROM admins WHERE user_login = @UL", db.GetConnection());
                    command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;

                    db.OpenConnection();
                    command.ExecuteReader();
                    db.CloseConnection(); //Закрываем соединение 

                    StatusCheck();
                }
            }
        }

        private void RenameUsrButton_Click(object sender, EventArgs e)
        {
            if (loginField.Text != "")
            {
                string newLogin;
                RenameLogin rl = new RenameLogin();
                rl.UN = loginField.Text;
                this.Hide();
                if (rl.ShowDialog() == DialogResult.OK)
                {
                    newLogin = rl.UN;
                    this.Show();
                }
                else { this.Show(); return; }    

                RenameUser(loginField.Text, newLogin);
                if (adminName.Text == loginField.Text) { adminName.Text = newLogin; rename = true; }

                loginField.Text = newLogin;
                Users.Items.Clear();
                AdminForm_Load(this, EventArgs.Empty);
                rename = false;
                Users.SelectedItem = newLogin;                                
                StatusCheck();
                Permissions();                
            }
        }

        public void RenameUser(string oldLogin, string newLogin)
        {
            DataBase db = new DataBase();
            SqlCommand command = new SqlCommand("UPDATE users SET login = @NuL WHERE login = @UL", db.GetConnection());

            command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = oldLogin;
            command.Parameters.Add("@NuL", SqlDbType.NVarChar).Value = newLogin;

            db.OpenConnection();
            command.ExecuteReader();
            db.CloseConnection();  
        }

        private void superAdminButton_GiveSuperAdmin()
        {
            if (loginField.Text != "" && statusField.Text != "superadmin")
            {
                CheckUserID(); CheckLastID();

                DataBase db = new DataBase();
                SqlCommand command = new SqlCommand();
                if (statusField.Text == "user")
                {
                    command = new SqlCommand("INSERT INTO admins (id, user_id, user_login, permissions)" +
                                               "VALUES (@id, @uID, @UL, 1) ", db.GetConnection());
                }
                if (statusField.Text == "admin")
                {
                    command = new SqlCommand("UPDATE admins SET permissions = REPLACE(permissions, 0, 1) " +
                                               "where user_login = @UL ", db.GetConnection());
                }
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = lastID + 1;
                command.Parameters.Add("@uID", SqlDbType.NVarChar).Value = id;
                command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;                

                db.OpenConnection();
                command.ExecuteReader();
                db.CloseConnection(); //Закрываем соединение                 

                StatusCheck();                
            }
        }

        private void superAdminButton_DropAdmin()
        {
            if (statusField.Text == "superadmin")
            {
                if (loginField.Text != "")
                {
                    DataBase db = new DataBase();
                    SqlCommand command = new SqlCommand("UPDATE admins SET permissions = REPLACE(permissions, 1, 0) " +
                                                            "where user_login = @UL ", db.GetConnection());
                    command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = loginField.Text;

                    db.OpenConnection();
                    command.ExecuteReader();
                    db.CloseConnection(); 

                    AdminBehindBox.Enabled = true;

                    StatusCheck();
                }
            }
            else return;
        }

        private void DelUsrButton_Click(object sender, EventArgs e)
        {
            if (loginField.Text != "")
            {
                DeleteUser(loginField.Text);
                Users.Items.Clear();
                loginField.Text = ""; statusField.Text = "";
                nameField.Text = ""; surnameField.Text = "";
                AdminButton.CheckState = CheckState.Unchecked; superAdminButton.CheckState = CheckState.Unchecked;
                AdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                superAdminButton.BackColor = Color.FromArgb(255, 153, 180, 209);
                AdminForm_Load(this, EventArgs.Empty);
            }            
        }

        public void DeleteUser(string userLogin)
        {
            DataBase db = new DataBase();
            SqlCommand command = new SqlCommand("DELETE FROM users WHERE login = @UL", db.GetConnection());
            command.Parameters.Add("@UL", SqlDbType.NVarChar).Value = userLogin;

            db.OpenConnection();
            //command.ExecuteReader();
            if (command.ExecuteNonQuery() == 1) MessageBox.Show("Учетная запись успешно удалена");
            else MessageBox.Show("Ошибка удаления учетной записи");
            db.CloseConnection(); 
        }
    }
}
