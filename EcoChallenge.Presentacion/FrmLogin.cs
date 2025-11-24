using Entidades;
using LogicaNegocio;
using System;
using AccesoDatos;
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

            txtContraseña.Clear();
            txtCorreo.Clear();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistro frm = new FrmRegistro();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                var conexion = DbConnection.ObtenerConexion();
                conexion.Open();
                MessageBox.Show("Conexión exitosa a SQL Server");
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }

        }
    }
}
