using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using Pantallas_Sistema_Facturacion.BLL.Servicios;
using Pantallas_Sistema_Facturacion.DAL.Repositorios;

namespace 
{
    public partial class frmSeguridad : MaterialForm
    {
        private readonly string usuarioActual;
        private readonly IServicioUsuario _servicioUsuario;

        public frmSeguridad(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            _servicioUsuario = new ServicioUsuario(new RepositorioUsuario());
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            try
            {
                var usuario = _servicioUsuario.ObtenerPorNombre(usuarioActual);
                if (usuario != null)
                {
                    lblUsuario.Text = usuario.NombreUsuario;
                    lblRol.Text = usuario.Rol;
                }
                else
                {
                    lblUsuario.Text = usuarioActual;
                    lblRol.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string antigua = txtAntigua.Text.Trim();
            string nueva = txtNueva.Text.Trim();

            string mensaje;
            try
            {
                bool correcto = _servicioUsuario.CambiarContrasena(usuarioActual, antigua, nueva, out mensaje);
                if (correcto)
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}