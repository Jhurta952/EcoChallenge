using Entidades;
using LogicaNegocio;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lblCorreo_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!correo.Contains("@") || !correo.Contains(".") || correo.Length < 5)
            {
                MessageBox.Show("El correo no tiene un formato valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioLog usuarioLog = new UsuarioLog();
            Usuario usuario = usuarioLog.IniciarSesion(correo, contraseña);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido {usuario.Nombre}({usuario.Rol})", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if(usuario.Rol == "Administrador")
                {
                    FrmMenuAdmin adminForm = new FrmMenuAdmin();
                    adminForm.Show();
                }
                else if (usuario.Rol == "Jugador")
                {
                    FrmMenuJugador jugadorForm = new FrmMenuJugador();
                    jugadorForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
