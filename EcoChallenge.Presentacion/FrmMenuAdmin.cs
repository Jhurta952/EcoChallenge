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
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void btnMisiones_Click(object sender, EventArgs e)
        {
            FrmMisionesAdmin misionesAdmin = new FrmMisionesAdmin();
            misionesAdmin.Show();
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuariosAdmin usuariosAdmin = new FrmUsuariosAdmin();
            usuariosAdmin.Show();
        }
    }
}
