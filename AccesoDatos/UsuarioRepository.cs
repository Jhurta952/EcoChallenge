using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;



namespace AccesoDatos
{
    public class UsuarioRepository
    {
        private readonly DbConnection conexion;

        public UsuarioRepository()
        {
            conexion = DbConnection.ObtenerInstancia();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO Usuarios (Nombre, Correo, Contrasena, Rol)
                                     VALUES (@Nombre, @Correo, @Contrasena, @Rol)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
                        cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al registrar usuario: " + ex.Message);
            }
        }

        public Usuario ObtenerPorCorreoYContrasena(string correo, string contrasena)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Usuarios 
                                     WHERE Correo=@Correo AND Contrasena=@Contrasena";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    Id = (int)reader["Id"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Correo = reader["Correo"].ToString(),
                                    Contraseña = reader["Contrasena"].ToString(),
                                    Rol = reader["Rol"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                                };
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al obtener usuario: " + ex.Message);
            }
        }

        public bool ExisteCorreo(string correo)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo=@Correo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al validar correo: " + ex.Message);
            }
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Usuarios";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Contraseña = reader["Contrasena"].ToString(),
                                Rol = reader["Rol"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            });
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al obtener usuarios: " + ex.Message);
            }
        }

        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"UPDATE Usuarios 
                                     SET Nombre=@Nombre, Correo=@Correo, Contrasena=@Contrasena, Rol=@Rol
                                     WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
                        cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al editar usuario: " + ex.Message);
            }
        }

        public bool EliminarUsuario(int id)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM Usuarios WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("❌ Error al eliminar usuario: " + ex.Message);
            }
        }
    }
}