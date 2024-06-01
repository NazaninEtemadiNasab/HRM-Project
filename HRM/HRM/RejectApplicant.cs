﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HRM
{
    public partial class RejectApplicant : Form
    {
        public RejectApplicant()
        {
            InitializeComponent();
        }

        private void RejectApplicant_Load(object sender, EventArgs e)
        {

            refresh();
        }


        void refresh()
        {
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT * FROM ApplicantsTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");

                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add( dr["id"] + ":" + "Ssn:" + dr["ssn"] +" "+ "Firstname:" + dr["firstname"] + " " + "Lastname:" + dr["lastname"] + " " + "Age:" + dr["age"] + " " + "Address:" + dr["address"] + " " + "Mobile:" + dr["mobile"] + " " + "Email:" + dr["email"] + " " + "Job:" + dr["job"] + " " + "WorkExperience:" + dr["experience"]);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            int index = id.IndexOf(":");
            id = id.Substring(0, index);
            try
            {
                string query = "DELETE FROM ApplicantsTable WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("DELETE OK");
                    refresh();
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

    }
}
