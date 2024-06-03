﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    class DataBase
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programming\\C_sharp\\Authorization_MSSQL_VisualStudio\\alexsav.mdf;Integrated Security=True");
        //MySqlConnection connection = new MySqlConnection("server = localhost; port = 3306; username = root; password = root; database = savinan");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void CheckConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Нет соединения с БД");
                return;
            }
        }
    }
}
