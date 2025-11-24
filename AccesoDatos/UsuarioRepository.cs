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
        private readonly DbConnection conexion = DbConnection.ObtenerInstancia();

        // Registrar un nuevo usuario
        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"INSERT INTO Usuarios (Nombre, Correo, Contrasena, Rol)
                                     VALUES (@Nombre, @Correo, @Contrasena, @Rol)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar usuario: " + ex.Message);
            }
        }

        // Buscar usuario por correo y contraseña (inicio de sesión)
        public Usuario ObtenerPorCorreoYContrasena(string correo, string contrasena)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"SELECT * FROM Usuarios 
                                     WHERE Correo = @Correo AND Contrasena = @Contrasena";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Contraseña = reader["Contrasena"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar usuario: " + ex.Message);
            }
        }

        // Verificar si un correo ya existe
        public bool CorreoExiste(string correo)
        {
            try
            {
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", correo);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar correo: " + ex.Message);
            }
        }
    }
}
