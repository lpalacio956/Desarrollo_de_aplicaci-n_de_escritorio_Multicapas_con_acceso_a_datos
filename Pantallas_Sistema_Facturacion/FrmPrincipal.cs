using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace 
{
    public partial class FrmPrincipal : MaterialForm
    {
        private string usuarioActual;

        public FrmPrincipal(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }
        private void AbrirForm(Form formHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(formHijo);
            formHijo.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmListaClientes frmListaClientes = new frmListaClientes();
            AbrirForm(frmListaClientes);
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            frmSeguridad frmSeguridad = new frmSeguridad(usuarioActual);
            AbrirForm(frmSeguridad);
        }
    }
}
