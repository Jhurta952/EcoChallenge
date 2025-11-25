using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;



namespace AccesoDatos
{
    public class JugadorRepository
    {
        private readonly SqlConnection conn;

        public JugadorRepository()
        {
            conn = DbConnection.ObtenerInstancia().ObtenerConexion();
        }

        public List<Mision> ObtenerMisionesDiarias()
        {
            List<Mision> misiones = new List<Mision>();
            try
            {
                conn.Open();
                string query = "SELECT TOP 3 * FROM Misiones WHERE Activa = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        misiones.Add(new Mision
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Puntos = (int)dr["Puntos"]
                        });
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return misiones;
        }

        public bool CompletarMision(int idUsuario, int idMision)
        {
            try
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM Progreso WHERE IdUsuario=@idUsuario AND IdMision=@idMision";
                using (SqlCommand cmdCheck = new SqlCommand(check, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdCheck.Parameters.AddWithValue("@idMision", idMision);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0)
                    {
                        string insert = "INSERT INTO Progreso (IdUsuario, IdMision, Completada, FechaAsignacion, FechaCompletada) " +
                                        "VALUES (@idUsuario, @idMision, 1, GETDATE(), GETDATE())";
                        using (SqlCommand cmdInsert = new SqlCommand(insert, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdInsert.Parameters.AddWithValue("@idMision", idMision);
                            return cmdInsert.ExecuteNonQuery() > 0;
                        }
                    }
                    else
                    {
                        string update = "UPDATE Progreso SET Completada=1, FechaCompletada=GETDATE() " +
                                        "WHERE IdUsuario=@idUsuario AND IdMision=@idMision";
                        using (SqlCommand cmdUpdate = new SqlCommand(update, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdUpdate.Parameters.AddWithValue("@idMision", idMision);
                            return cmdUpdate.ExecuteNonQuery() > 0;
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Recompensa> ObtenerRecompensas(int idUsuario)
        {
            List<Recompensa> recompensas = new List<Recompensa>();
            try
            {
                conn.Open();
                string query = "SELECT r.Id, r.Nombre, r.Descripcion, r.PuntosNecesarios " +
                               "FROM Recompensas r " +
                               "JOIN UsuariosRecompensas ur ON r.Id = ur.IdRecompensa " +
                               "WHERE ur.IdUsuario = @idUsuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            recompensas.Add(new Recompensa
                            {
                                Id = (int)dr["Id"],
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                PuntosRequeridos = (int)dr["PuntosNecesarios"]
                            });
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return recompensas;
        }

        public int ObtenerPuntosTotales(int idUsuario)
        {
            int puntos = 0;
            try
            {
                conn.Open();
                string query = "SELECT SUM(m.Puntos) FROM Progreso p " +
                               "JOIN Misiones m ON p.IdMision = m.Id " +
                               "WHERE p.IdUsuario=@idUsuario AND p.Completada=1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    object result = cmd.ExecuteScalar();
                    puntos = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            finally
            {
                conn.Close();
            }
            return puntos;
        }
    }
}
