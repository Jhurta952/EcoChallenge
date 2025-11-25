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
        private readonly UsuarioRepository repo;

        public UsuarioLog()
        {
            repo = new UsuarioRepository();
        }

        public string Registrar(Usuario u)
        {
            if (repo.ExisteCorreo(u.Correo))
                return "El correo ya está registrado.";

            bool ok = repo.CrearUsuario(u);

            return ok ? "Registrado correctamente" : "Error al registrar";
        }

        public Usuario Login(string correo, string contrasena)
        {
            return repo.ObtenerPorCorreoYContrasena(correo, contrasena);
        }
    }
}
