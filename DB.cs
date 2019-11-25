using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Jegyfoglalo
{
    class DB
    {
        private SQLiteConnection conn = new SQLiteConnection("data source = DB-jegyfoglalas.db");
        
        public SQLiteConnection GetConnection()
        {
            return conn;
        }

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}
