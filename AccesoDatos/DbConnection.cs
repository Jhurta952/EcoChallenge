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
        private static DbConnection instancia;
        private readonly string cadenaConexion;

        private DbConnection()
        {
            cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=EcoChallengeDB; Integrated Security=True;";
        }

        public static DbConnection ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new DbConnection();
            }
            return instancia;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
