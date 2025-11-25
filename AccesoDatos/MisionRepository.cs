using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class MisionRepository
    {
        public List<Mision> ObtenerMisiones()
        {
            List<Mision> lista = new List<Mision>();

            string query = "SELECT Id, Nombre, Descripcion, Puntos, Tipo, Activa FROM Misiones";

            try
            {
                using (SqlConnection conexion = DbConnection.ObtenerInstancia().ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Mision
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                            Descripcion = dr.GetString(2),
                            Puntos = dr.GetInt32(3),
                            Tipo = dr.GetString(4),
                            Activa = dr.GetBoolean(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo misiones: " + ex.Message);
            }

            return lista;
        }

        public bool CrearMision(Mision mision)
        {
            string query = @"INSERT INTO Misiones (Nombre, Descripcion, Puntos, Tipo, Activa)
                             VALUES (@n, @d, @p, @t, @a)";

            try
            {
                using (SqlConnection conexion = DbConnection.ObtenerInstancia().ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@n", mision.Nombre);
                    cmd.Parameters.AddWithValue("@d", mision.Descripcion);
                    cmd.Parameters.AddWithValue("@p", mision.Puntos);
                    cmd.Parameters.AddWithValue("@t", mision.Tipo);
                    cmd.Parameters.AddWithValue("@a", mision.Activa);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando misión: " + ex.Message);
            }
        }

        public bool EditarMision(Mision mision)
        {
            string query = @"UPDATE Misiones
                             SET Nombre=@n, Descripcion=@d, Puntos=@p, Tipo=@t, Activa=@a
                             WHERE Id=@id";

            try
            {
                using (SqlConnection conexion = DbConnection.ObtenerInstancia().ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", mision.Id);
                    cmd.Parameters.AddWithValue("@n", mision.Nombre);
                    cmd.Parameters.AddWithValue("@d", mision.Descripcion);
                    cmd.Parameters.AddWithValue("@p", mision.Puntos);
                    cmd.Parameters.AddWithValue("@t", mision.Tipo);
                    cmd.Parameters.AddWithValue("@a", mision.Activa);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error editando misión: " + ex.Message);
            }
        }

        public bool EliminarMision(int id)
        {
            string query = "DELETE FROM Misiones WHERE Id=@id";

            try
            {
                using (SqlConnection conexion = DbConnection.ObtenerInstancia().ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminando misión: " + ex.Message);
            }
        }
    }
}