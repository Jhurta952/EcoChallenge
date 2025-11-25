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

        public Usuario IniciarSesion(string correo, string contrasena)
        {
            return repo.ObtenerPorCorreoYContrasena(correo, contrasena);
        }

        public string Registrar(Usuario u)
        {
            if (repo.ExisteCorreo(u.Correo))
                return "El correo ya está registrado.";

            bool ok = repo.CrearUsuario(u);
            return ok ? "Registrado correctamente" : "Error al registrar";
        }

        public List<Usuario> ListarUsuarios()
        {
            return repo.ObtenerTodos();
        }

        public string EditarUsuario(Usuario u)
        {
            bool ok = repo.EditarUsuario(u);

            return ok ? "Usuario actualizado correctamente"
                      : "No se pudo actualizar el usuario";
        }

        public string EliminarUsuario(int id)
        {
            bool ok = repo.EliminarUsuario(id);

            return ok ? "Usuario eliminado correctamente"
                      : "No se pudo eliminar el usuario";
        }
    }
}