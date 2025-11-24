using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AccesoDatos
{
    public class DbConnection
    {
        private static SqlConnection instancia = null;

        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS; Database=EcoChallengeDB; Integrated Security=True;";

        private DbConnection() { }

        public static SqlConnection ObtenerConexion()
        {
            if (instancia == null)
                instancia = new SqlConnection(connectionString);

            return instancia;
        }
    }
}
