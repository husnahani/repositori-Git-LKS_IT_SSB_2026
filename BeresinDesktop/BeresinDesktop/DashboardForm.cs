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
            SetWelcomeMessage(); // Tampilkan pesan role-based
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

            }
        }

        private void LoadData(string search = "")
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT CategoryID, CategoryName, Status FROM Categories WHERE 1=1";

                if (!string.IsNullOrEmpty(search))
                    query += " AND CategoryName LIKE @search";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                if (!string.IsNullOrEmpty(search))
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTugas.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        // Karena tabel Categories tidak ada filter status,
        // jika ada combobox status, event ini bisa dihilangkan atau dibuat kosong.
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kosongkan saja, atau hapus event ini kalau tidak dipakai
        }

        private void btnHapusTugas_Click(object sender, EventArgs e)
        {
            if (dgvTugas.SelectedRows.Count > 0)
            {
                int categoryId = Convert.ToInt32(dgvTugas.SelectedRows[0].Cells["CategoryID"].Value);
                var confirm = MessageBox.Show("Yakin ingin menghapus kategori ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = "DELETE FROM Categories WHERE CategoryID=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", categoryId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    LoadData(txtSearch.Text);
                }
            }
            else
            {
                MessageBox.Show("Pilih kategori yang ingin dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManajemenPengguna_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur Manajemen Pengguna hanya untuk Admin.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Bisa dihapus jika tidak ada aksi khusus
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTugas.CurrentRow == null) return;

            string id = dgvTugas.CurrentRow.Cells["CategoryID"].Value.ToString();

            // GUNAKAN DatabaseHelper agar tidak perlu variabel 'koneksi' lagi
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Categories SET CategoryName=@name, Status=@status WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtTambah.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatusFilter.Text);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Diubah!");
                LoadData();
            }
        }

        private void btnManajemenPengguna_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Categories (CategoryName, Status) VALUES (@name, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtTambah.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatusFilter.Text);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Ditambah!");
                LoadData();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHapusTugas_Click_1(object sender, EventArgs e)
        {
            if (dgvTugas.CurrentRow == null) return;

            string id = dgvTugas.CurrentRow.Cells["CategoryID"].Value.ToString();

            var confirm = MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // GUNAKAN DatabaseHelper juga di sini
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Categories WHERE CategoryID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            }
        }
    }
}
            
        
