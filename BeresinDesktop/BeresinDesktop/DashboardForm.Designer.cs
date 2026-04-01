namespace BeresinDesktop
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            dgvTugas = new DataGridView();
            cmbStatusFilter = new ComboBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapusTugas = new Button();
            lblWelcome = new Label();
            btnManajementPengguna = new Button();
            txtTambah = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTugas).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 75);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvTugas
            // 
            dgvTugas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTugas.Location = new Point(12, 130);
            dgvTugas.Name = "dgvTugas";
            dgvTugas.RowHeadersWidth = 62;
            dgvTugas.Size = new Size(596, 348);
            dgvTugas.TabIndex = 1;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "Semua", "Pending", "Selesai" });
            cmbStatusFilter.Location = new Point(416, 71);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(182, 33);
            cmbStatusFilter.TabIndex = 2;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(655, 130);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(112, 34);
            btnTambah.TabIndex = 3;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(655, 194);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapusTugas
            // 
            btnHapusTugas.Location = new Point(655, 254);
            btnHapusTugas.Name = "btnHapusTugas";
            btnHapusTugas.Size = new Size(112, 34);
            btnHapusTugas.TabIndex = 5;
            btnHapusTugas.Text = "Hapus Tugas";
            btnHapusTugas.UseVisualStyleBackColor = true;
            btnHapusTugas.Click += btnHapusTugas_Click_1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(41, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(59, 25);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "label1";
            lblWelcome.Click += label1_Click;
            // 
            // btnManajementPengguna
            // 
            btnManajementPengguna.Location = new Point(655, 72);
            btnManajementPengguna.Name = "btnManajementPengguna";
            btnManajementPengguna.Size = new Size(112, 34);
            btnManajementPengguna.TabIndex = 8;
            btnManajementPengguna.Text = "Manajement";
            btnManajementPengguna.UseVisualStyleBackColor = true;
            btnManajementPengguna.Click += button1_Click;
            // 
            // txtTambah
            // 
            txtTambah.Location = new Point(205, 75);
            txtTambah.Name = "txtTambah";
            txtTambah.Size = new Size(150, 31);
            txtTambah.TabIndex = 9;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTambah);
            Controls.Add(btnManajementPengguna);
            Controls.Add(lblWelcome);
            Controls.Add(btnHapusTugas);
            Controls.Add(btnEdit);
            Controls.Add(btnTambah);
            Controls.Add(cmbStatusFilter);
            Controls.Add(dgvTugas);
            Controls.Add(txtSearch);
            Name = "DashboardForm";
            Text = "DashboardForm";
            Load += DashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTugas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dgvTugas;
        private ComboBox cmbStatusFilter;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapusTugas;
        private Label lblWelcome;
        private Button btnManajementPengguna;
        private TextBox txtTambah;
    }
}