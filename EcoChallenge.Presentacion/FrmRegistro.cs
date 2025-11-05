using Entidades;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoChallenge.Presentacion
{
    public partial class FrmRegistro : Form
    {
        private UsuariosDat usuariosDat = new UsuariosDat();
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string confirmar = txtConfirmar.Text.Trim();

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!nombre.All(c=> char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo debe contener letras y espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!correo.Contains("@") || !correo.Contains(".") || correo.Length < 5)
            {
                MessageBox.Show("El correo no tiene un formato valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra y un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contraseña != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existente = usuariosDat.ObtenerUsuarios().FirstOrDefault(u => u.Correo == correo);
            if(existente != null)
            {
                MessageBox.Show("Ya existe un usuario con ese correo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario nuevo = new Usuario()
            {
                Id = usuariosDat.ObtenerUsuarios().Count + 1,
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = "Jugador"
            };

            usuariosDat.ObtenerUsuarios().Add(nuevo);
            MessageBox.Show("¡Registro exitoso! Ahora puedes iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }
    }
}
