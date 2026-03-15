using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BeresinDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Tambahkan event handler untuk Load
            this.Load += Form1_Load;
        }

        // Fungsi ini dijalankan saat Form dibuka
        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Buat Chart baru
            Chart chartTugas = new Chart();
            chartTugas.Dock = DockStyle.Fill; // Chart mengisi Form

            // 2. Tambahkan ChartArea
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Status";
            chartArea.AxisY.Title = "Jumlah";
            chartArea.AxisY.Minimum = 0;
            chartTugas.ChartAreas.Add(chartArea);

            // 3. Buat Series
            Series series = new Series("Jumlah Tugas");
            series.ChartType = SeriesChartType.Column; // Column, Pie, Line, dll.

            // 4. Tambahkan data contoh manual
            series.Points.AddXY("Selesai", 10);
            series.Points.AddXY("Proses", 5);
            series.Points.AddXY("Belum Mulai", 8);

            chartTugas.Series.Add(series);

            // 5. Tambahkan Chart ke Form
            this.Controls.Add(chartTugas);
        }
    }
}