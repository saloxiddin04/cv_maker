using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace cv_maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string url_DB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=cv_maker1.mdb";
        string sqlUsers = "SELECT * FROM users";
        string sqlCountries = "SELECT * FROM countries";
        string sqlSkills = "SELECT * FROM skills";
        string sqlSocial = "SELECT * FROM social_links";

        OleDbConnection connection;
        OleDbCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            /*connection = new OleDbConnection(url_DB);
            cmd = new OleDbCommand(sqlUsers, connection);
            connection.Open();
            OleDbDataAdapter db = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            db.Fill(scores); */
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();  // Yangi formani ochish
            this.Hide();
        }

        private void btnOpenLogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();  // Yangi formani ochish
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

     
    }
}
