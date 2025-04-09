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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        //string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=cv_maker1.mdb";
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cv_maker1.mdb";

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username va parol kiritish shart!";
                return;
            }

            string hashedPassword = Helpers.HashPassword(password); // Hash qilingan parol

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = ?";
                    string checkUserEmail = "SELECT COUNT(*) FROM users WHERE email = ?";

                    using (OleDbCommand checkCmd = new OleDbCommand(checkUserQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("?", username);

                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            lblMessage.Text = "Bu username allaqachon mavjud!";
                            return;
                        }
                    }

                    using (OleDbCommand checkCmd = new OleDbCommand(checkUserEmail, connection))
                    {
                        checkCmd.Parameters.AddWithValue("?", email);

                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            lblMessage.Text = "Bu email allaqachon mavjud!";
                            return;
                        }
                    }

                    // Yangi foydalanuvchini qo'shish
                    string insertQuery = "INSERT INTO users(`username`, `email`, `password`, `role`) VALUES(username, email, password, role);";
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                    {
                        cmd.Parameters.Add("username", OleDbType.VarChar).Value = username;
                        cmd.Parameters.Add("email", OleDbType.VarChar).Value = email;
                        cmd.Parameters.Add("password", OleDbType.VarChar).Value = hashedPassword;
                        cmd.Parameters.Add("role", OleDbType.VarChar).Value = "client";
                        cmd.ExecuteNonQuery();
                    }

                    lblMessage.Text = "Muvaffaqiyatli ro‘yxatdan o‘tildi!";
                    MessageBox.Show("Muvaffaqiyatli ro‘yxatdan o‘tildi");
                    Login loginForm = new Login();
                    loginForm.Show();  // Yangi formani ochish
                    this.Hide();
                    connection.Close();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Xatolik: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Umumiy xatolik: " + ex.Message);
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
