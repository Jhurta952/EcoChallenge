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
    public partial class FrmMenuJugador : Form
    {
        JugadorRepository repo = new JugadorRepository();
        Usuario jugador;
        int puntosTotales = 0;

        public FrmMenuJugador(Usuario u)
        {
            InitializeComponent();
            jugador = u;
        }

        private void FrmMenuJugador_Load(object sender, EventArgs e)
        {
            CargarMisiones();
            CargarPuntos();
            VerificarRecompensasAutomaticas();
            CargarRecompensas();
        }

        private void CargarMisiones()
        {
            List<Mision> lista = repo.ObtenerMisionesDiarias();
            dgvMisiones.DataSource = lista;

            dgvMisiones.Columns["Id"].Visible = false;
            dgvMisiones.Columns["Activa"].Visible = false;
            dgvMisiones.Columns["Tipo"].Visible = false;
        }

        private void CargarRecompensas()
        {
            List<Recompensa> lista = repo.ObtenerRecompensas(jugador.Id);
            dgvRecompensas.DataSource = lista;

            if (dgvRecompensas.Columns.Contains("IdRecompensa"))
                dgvRecompensas.Columns["IdRecompensa"].Visible = false;
        }

        private void CargarPuntos()
        {
            puntosTotales = repo.ObtenerPuntosTotales(jugador.Id);
            lblPuntosTotales.Text = "Puntos Totales: " + puntosTotales;
        }

        private void VerificarRecompensasAutomaticas()
        {
            List<Recompensa> todas = repo.ObtenerTodasLasRecompensas();
            List<Recompensa> actuales = repo.ObtenerRecompensas(jugador.Id);

            foreach (Recompensa r in todas)
            {
                bool yaLaTiene = actuales.Any(x => x.Id == r.Id);
                if (!yaLaTiene && puntosTotales >= r.PuntosRequeridos)
                {
                    repo.AsignarRecompensa(jugador.Id, r.Id);
                    MessageBox.Show("¡Nueva recompensa obtenida: " + r.Nombre + "!");
                }
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una misión.");
                return;
            }

            int idMision = Convert.ToInt32(dgvMisiones.SelectedRows[0].Cells["Id"].Value);
            bool ok = repo.CompletarMision(jugador.Id, idMision);

            if (ok)
            {
                MessageBox.Show("¡Misión completada!");
                CargarMisiones();
                CargarPuntos();
                VerificarRecompensasAutomaticas();
                CargarRecompensas();
            }
            else
            {
                MessageBox.Show("Esta misión ya fue completada.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmLogin().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
