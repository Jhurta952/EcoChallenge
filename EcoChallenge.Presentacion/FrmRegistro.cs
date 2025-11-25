using AccesoDatos;
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
    public partial class FrmRegistro : Form
    {
        private readonly UsuarioLog usuarioLog = new UsuarioLog();

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

            // ---------------- VALIDACIONES ---------------- //

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo debe contener letras y espacios.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains(".") || correo.Length < 5)
            {
                MessageBox.Show("El correo no tiene un formato válido.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra y un número.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contraseña != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Usuario nuevo = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = "Jugador"
            };


            string resultado = usuarioLog.Registrar(nuevo);

            MessageBox.Show(resultado);

            if (resultado == "Registrado correctamente")
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
