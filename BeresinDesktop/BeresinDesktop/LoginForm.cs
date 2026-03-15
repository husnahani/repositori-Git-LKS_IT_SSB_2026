using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeresinDesktop
{
    public partial class LoginForm : Form
    {
        public static string CurrentRole; // Menyimpan role user

        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*'; // sembunyikan password
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi input kosong
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        CurrentRole = result.ToString();

                        // Buka Dashboard
                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}