﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPage.User_Controls
{
    public partial class UC_Account : UserControl
    {
        public UC_Account()
        {
            InitializeComponent();
        }

        private void UC_Account_Load(object sender, EventArgs e)
        {
            string ConString = "datasource=localhost;database=ACICStance_Corner;username=root;password=navi#7oaaK6";
            string Query = "SELECT * FROM Admin";
            MySqlConnection conn = new MySqlConnection(ConString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataReader myReader;

            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string adminName = myReader.GetString(myReader.GetOrdinal("Admin_Name"));
                    string adminSRCode = myReader.GetString(myReader.GetOrdinal("Admin_SRCode"));
                    DateTime adminLastLog = myReader.GetDateTime(myReader.GetOrdinal("LastLoginDate"));

                    dataGridView1.Rows.Add(adminName, adminSRCode,adminLastLog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting: " + ex, "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
    }

    internal class MySQLDataReader
    {
    }
}
