using System;
using System.Data;
using System.Data.SqlClient;

namespace GPSPrzebiegi
{
    /// <summary>
    /// Singleton :)
    /// </summary>
    public sealed class DatabaseCon
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        private static DatabaseCon _instance;

        private DatabaseCon()
        {
            con = new SqlConnection();
            con.ConnectionString = "user id=sa;" +
            "password=P@ssw0rt12;Data Source=192.168.1.100; " +
            "Trusted_Connection=no;" +
            "database=ERPXL_Lechtom; " +
            "connection timeout = 400";

        }
        public static DatabaseCon GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseCon();
            }
            return _instance;  
        }
        /// <summary>
        /// Metoda do select, zwraca DT
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable QueryEx(string query)
        {
            dt = new DataTable();
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandTimeout = 120;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                Logs.writeEventLog(ex.ToString());
            }
            return dt;
        }
        /// <summary>
        /// Metoda do wywołania query bez Select (bez zwrotu DT)
        /// </summary>
        /// <param name="query"></param>
        public void NonQueryEx(string query)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandTimeout = 120;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Logs.writeEventLog(ex.ToString());
            }
        }

    }
}
