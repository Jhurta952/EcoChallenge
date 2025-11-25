using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using AccesoDatos;

namespace EcoChallenge.Presentacion
{
    public partial class FrmMisionesAdmin : Form
    {
        private MisionRepository repo = new MisionRepository();

        public FrmMisionesAdmin()
        {
            InitializeComponent();
        }

        private void FrmMisionesAdmin_Load(object sender, EventArgs e)
        {
            CargarMisiones();
            cmbTipo.SelectedIndex = 0;
        }

        private void CargarMisiones()
        {
            dgvMisiones.DataSource = repo.ObtenerMisiones();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Mision nueva = new Mision
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Puntos = int.Parse(txtPuntos.Text),
                Tipo = cmbTipo.Text,
                Activa = chkActiva.Checked
            };

            if (repo.CrearMision(nueva))
            {
                MessageBox.Show("Misión creada correctamente.");
                CargarMisiones();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una misión.");
                return;
            }

            Mision m = (Mision)dgvMisiones.SelectedRows[0].DataBoundItem;

            m.Nombre = txtNombre.Text.Trim();
            m.Descripcion = txtDescripcion.Text.Trim();
            m.Puntos = int.Parse(txtPuntos.Text);
            m.Tipo = cmbTipo.Text;
            m.Activa = chkActiva.Checked;

            if (repo.EditarMision(m))
            {
                MessageBox.Show("Misión actualizada.");
                CargarMisiones();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una misión.");
                return;
            }

            int id = ((Mision)dgvMisiones.SelectedRows[0].DataBoundItem).Id;

            if (repo.EliminarMision(id))
            {
                MessageBox.Show("Misión eliminada.");
                CargarMisiones();
            }
        }

        private void dgvMisiones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMisiones.SelectedRows.Count == 0) return;

            Mision m = (Mision)dgvMisiones.SelectedRows[0].DataBoundItem;

            txtNombre.Text = m.Nombre;
            txtDescripcion.Text = m.Descripcion;
            txtPuntos.Text = m.Puntos.ToString();
            cmbTipo.Text = m.Tipo;
            chkActiva.Checked = m.Activa;
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            FrmMenuAdmin menu = new FrmMenuAdmin();
            menu.Show();
            this.Close();
        }
    }
}
