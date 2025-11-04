using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class UsuarioLog
    {
        private UsuariosDat usuariosDal = new UsuariosDat();

        public Usuario IniciarSesion(string correo, string contraseña)
        {
            return usuariosDal.ObtenerUsuarioPorCorreoYContraseña(correo, contraseña);
        }
    }
}
