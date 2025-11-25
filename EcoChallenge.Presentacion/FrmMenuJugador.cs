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
    public partial class FrmMenuJugador : Form
    {
        public FrmMenuJugador()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if(cmbMisiones.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una misión.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void FrmMenuJugador_Load(object sender, EventArgs e)
        {

        }
    }
}
