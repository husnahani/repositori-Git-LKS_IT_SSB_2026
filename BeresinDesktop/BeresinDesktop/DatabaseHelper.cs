using System.Data.SqlClient;

namespace BeresinDesktop
{
    public static class DatabaseHelper
    {
        // Connection string, sesuaikan dengan server/database kamu
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=BeresinDB;Trusted_Connection=True;";

        // Mendapatkan SqlConnection siap pakai
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}