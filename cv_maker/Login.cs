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
using System.Security.Cryptography;

namespace cv_maker
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string url_DB = Helpers.url_DB;


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Iltimos, barcha maydonlarni to'ldiring!";
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(url_DB))
                {
                    connection.Open();
                    string query = "SELECT `password` FROM `users` WHERE `email` = ?;";
                    
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = email;
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string hashedPasswordFromDB = result.ToString();
                            string hashedInputPassword = Helpers.HashPassword(password);

                            if (hashedInputPassword == hashedPasswordFromDB)
                            {
                                MessageBox.Show("Muvaffaqiyatli tizimga kirdingiz!");
                                this.Hide();
                                Form1 mainForm = new Form1();
                                mainForm.Show();
                            }
                            else
                            {
                                lblMessage.Text = "Email yoki parol noto‘g‘ri!";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Bunday foydalanuvchi topilmadi!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
