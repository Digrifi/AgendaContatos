using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.BaseDeDados
{
    public static class ConnectionMySql
    {
        public static String ConnectionString { get; set; }
        public static String Server { get; set; }
        public static String Database { get; set; }
        public static String User { get; set; }
        public static String Password { get; set; }

        public static MySqlConnection GetConnection()
        {
            Server = "localhost";
            Database = "agendacontatos";
            User = "root";
            Password = "root";
            ConnectionString = $"Persist Security Info=False;server={Server};database={Database};uid={User};server={Server};uid={User};pwd='{Password}'";
            var conn = new MySqlConnection(ConnectionString);

            try
            {
                conn.Open();
            }
            catch (MySqlException myex)
            {
                MessageBox.Show(myex.Message, "Não foi Possível Conectar");
                throw;
            }

            return conn;
        }
    }
}

