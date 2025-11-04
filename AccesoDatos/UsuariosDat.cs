using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace AccesoDatos
{
    public class UsuariosDat
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario(1, "Administrador", "admin@eco.com", "1234", "Administrador"),
            new Usuario(2, "Jugador1", "jugador1@eco.com", "abcd", "Jugador")
        };

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public Usuario ObtenerUsuarioPorCorreoYContraseña(string correo, string contraseña)
        {
            return usuarios.FirstOrDefault(u => u.Correo == correo && u.Contraseña == contraseña);
        }
    }   
}
