using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=calc.db");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(txtNum1.Text);
            int num2 = Convert.ToInt32(TxtNumber2.Text);

            int result = num1 + num2;

            txtresult.Text = result.ToString();

            con.Open();

            string query = "INSERT INTO Calculation VALUES (@Num1,@Num2,@Result)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@Num1", num1);
            cmd.Parameters.AddWithValue("@Num2", num2);
            cmd.Parameters.AddWithValue("@Result", result);

            cmd.ExecuteNonQuery();



            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Calculation", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }



        private void btnsub_Click(object sender, EventArgs e)
        {
            
            int num1 = Convert.ToInt32(txtNum1.Text);
            int num2 = Convert.ToInt32(TxtNumber2.Text);

            int result = num1 - num2;
            txtresult.Text = result.ToString();

            con.Open();

            string query = "INSERT INTO Calculation VALUES (@Num1,@Num2,@Result)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@Num1", num1);
            cmd.Parameters.AddWithValue("@Num2", num2);
            cmd.Parameters.AddWithValue("@Result", result);

            cmd.ExecuteNonQuery();

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Calculation", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void btnmul_Click(object sender, EventArgs e)
        
        {
            int num1 = Convert.ToInt32(txtNum1.Text);
            int num2 = Convert.ToInt32(TxtNumber2.Text);

            int result = num1 * num2;
            txtresult.Text = result.ToString();

            con.Open();

            string query = "INSERT INTO Calculation VALUES (@Num1,@Num2,@Result)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@Num1", num1);
            cmd.Parameters.AddWithValue("@Num2", num2);
            cmd.Parameters.AddWithValue("@Result", result);

            cmd.ExecuteNonQuery();

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Calculation", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void btndiv_Click(object sender, EventArgs e)
        {
            
            int num1 = Convert.ToInt32(txtNum1.Text);
            int num2 = Convert.ToInt32(TxtNumber2.Text);

            int result = num1 / num2;
            txtresult.Text = result.ToString();

            con.Open();

            string query = "INSERT INTO Calculation VALUES (@Num1,@Num2,@Result)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@Num1", num1);
            cmd.Parameters.AddWithValue("@Num2", num2);
            cmd.Parameters.AddWithValue("@Result", result);

            cmd.ExecuteNonQuery();

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Calculation", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtNum1.Clear();
            TxtNumber2.Clear();
            txtresult.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();

            string query = "CREATE TABLE IF NOT EXISTS Calculation (Num1 INTEGER, Num2 INTEGER, Result INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void txtresult_TextChanged(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(txtNum1.Text);
            int num2 = Convert.ToInt32(TxtNumber2.Text);

            int result = num1 + num2;

            txtresult.Text = result.ToString();
        }
    }
}
        
    

    

