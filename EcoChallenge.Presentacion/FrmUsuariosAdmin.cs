using AccesoDatos;
using Entidades;
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
    public partial class FrmUsuariosAdmin : Form
    {
        private readonly UsuarioRepository repo = new UsuarioRepository();

        public FrmUsuariosAdmin()
        {
            InitializeComponent();
        }

        private void FrmUsuariosAdmin_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

            cmbRol.Items.Add("Jugador");
            cmbRol.Items.Add("Administrador");
            cmbRol.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = repo.ObtenerTodos();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            txtNombre.Text = u.Nombre;
            txtCorreo.Text = u.Correo;
            txtContraseña.Text = u.Contraseña;
            cmbRol.Text = u.Rol;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();


            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!nombre.All(c => char.IsLetter(c) || c == ' ' || nombre.Length < 5))
            {
                MessageBox.Show("El nombre solo debe contener letras, espacios y al menos 5 caracteres.");
                return;
            }

            if (!correo.Contains("@") || !correo.Contains(".") || correo.Length < 5)
            {
                MessageBox.Show("El correo no tiene un formato válido.");
                return;
            }

            if (contraseña.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.");
                return;
            }

            if (!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra y un número.");
                return;
            }

            Usuario nuevo = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = cmbRol.Text
            };

            if (repo.CrearUsuario(nuevo))
            {
                MessageBox.Show("Usuario creado correctamente.");
                CargarUsuarios();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtContraseña.Clear();
                cmbRol.SelectedIndex = -1;
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            Usuario u = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string rol = cmbRol.Text.Trim();


            if (!string.IsNullOrEmpty(nombre) && !nombre.All(c => char.IsLetter(c) || c == ' ' || nombre.Length <5 ))
            {
                MessageBox.Show("El nombre solo debe contener letras, espacios y al menos 5 caracteres.");
                return;
            }

            if (!string.IsNullOrEmpty(correo) && (!correo.Contains("@") || !correo.Contains(".") || correo.Length < 5))
            {
                MessageBox.Show("El correo no tiene un formato válido.");
                return;
            }

            if (!string.IsNullOrEmpty(contraseña))
            {
                if (contraseña.Length < 4)
                {
                    MessageBox.Show("La contraseña debe tener al menos 4 caracteres.");
                    return;
                }

                if (!contraseña.Any(char.IsLetter) || !contraseña.Any(char.IsDigit))
                {
                    MessageBox.Show("La contraseña debe contener al menos una letra y un número.");
                    return;
                }

                u.Contraseña = contraseña;
            }

            if (!string.IsNullOrEmpty(nombre)) u.Nombre = nombre;
            if (!string.IsNullOrEmpty(correo)) u.Correo = correo;
            if (!string.IsNullOrEmpty(rol))
            {
                if (rol != "Administrador" && rol != "Jugador")
                {
                    MessageBox.Show("Debe seleccionar un rol válido.");
                    return;
                }
                u.Rol = rol;
            }

            if (repo.EditarUsuario(u))
            {
                MessageBox.Show("Usuario actualizado.");
                CargarUsuarios();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            int id = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).Id;

            if (repo.EliminarUsuario(id))
            {
                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenuAdmin menu = new FrmMenuAdmin();
            menu.Show();
            this.Close();
        }
    }
}