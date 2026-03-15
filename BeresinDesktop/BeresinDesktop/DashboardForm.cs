using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeresinDesktop
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetAccessRestriction();
            SetWelcomeMessage(); // Tambahkan ini
            LoadData();
        }

        // Menampilkan pesan role-based
        private void SetWelcomeMessage()
        {
            if (LoginForm.CurrentRole == "Admin")
            {
                lblWelcome.Text = "Selamat Datang Admin, Anda memiliki akses penuh";
            }
            else
            {
                lblWelcome.Text = "Selamat Datang Pengguna, akses terbatas";
            }
        }

        private void SetAccessRestriction()
        {
            if (LoginForm.CurrentRole != "Admin")
            {
                btnHapusTugas.Visible = false;
                btnManajemenPengguna.Visible = false;
            }
        }

        private void LoadData(string search = "", string status = "")
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT Id, NamaTugas, Status FROM Tugas WHERE 1=1";

                if (!string.IsNullOrEmpty(search))
                    query += " AND NamaTugas LIKE @search";

                if (!string.IsNullOrEmpty(status) && status != "Semua")
                    query += " AND Status=@status";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                if (!string.IsNullOrEmpty(search))
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                if (!string.IsNullOrEmpty(status) && status != "Semua")
                    da.SelectCommand.Parameters.AddWithValue("@status", status);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTugas.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text, cmbStatusFilter.Text);
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text, cmbStatusFilter.Text);
        }

        private void btnHapusTugas_Click(object sender, EventArgs e)
        {
            if (dgvTugas.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dgvTugas.SelectedRows[0].Cells["Id"].Value);
                var confirm = MessageBox.Show("Yakin ingin menghapus tugas ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = "DELETE FROM Tugas WHERE Id=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", taskId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    LoadData(txtSearch.Text, cmbStatusFilter.Text);
                }
            }
            else
            {
                MessageBox.Show("Pilih tugas yang ingin dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManajemenPengguna_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur Manajemen Pengguna hanya untuk Admin.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}