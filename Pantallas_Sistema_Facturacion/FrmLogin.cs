using System;
using System.Windows.Forms;
using .BLL.Servicios;
using .DAL.Repositorios;

namespace 
{
    public partial class FrmLogin : Form
    {
        private readonly IServicioUsuario _servicioUsuario;

        public FrmLogin()
        {
            InitializeComponent();
            _servicioUsuario = new ServicioUsuario(new RepositorioUsuario());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtUsuario_Click(object sender, EventArgs e) { }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            try
            {
                if (_servicioUsuario.ValidarCredenciales(usuario, contrasena))
                {
                    FrmPrincipal principal = new FrmPrincipal(usuario);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}