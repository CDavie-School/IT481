using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LinqToDB.Data;

namespace IT481_U2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            try

            {

                String str = "Data Source=DESKTOP-FP2LT21\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

                String query = "select * from data";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                DataSet ds = new DataSet();

                MessageBox.Show("connect with sql server");

                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }

        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            String str = "Data Source=DESKTOP-FP2LT21\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd;
            string sql = "SELECT count(CustomerID) FROM dbo.Customers";
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                MessageBox.Show("Customer Count:" +rows_count.ToString());
                con.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnNames_Click(object sender, EventArgs e)
        {
            String str = "Data Source=DESKTOP-FP2LT21\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            SqlCommand command = new SqlCommand
                (
                "SELECT CompanyName " +
                "FROM dbo.Customers " +
                "ORDER BY CompanyName", con
                );

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listBox1.Items.Add(reader["CompanyName"].ToString());
                    //MessageBox.Show(reader["CompanyName"].ToString());
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            
            
            
        }
    }
}
