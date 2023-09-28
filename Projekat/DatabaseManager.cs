using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class DatabaseManager
    {

        public static MySqlConnection GetConnection() { 
            return new MySqlConnection("Server=localhost;Database=quizes;Uid=root;Pwd=;");
        }
    }
}
