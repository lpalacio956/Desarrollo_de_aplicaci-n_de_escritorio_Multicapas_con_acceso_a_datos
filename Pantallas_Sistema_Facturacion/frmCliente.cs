using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using Pantallas_Sistema_Facturacion.Core.Modelos;
using Pantallas_Sistema_Facturacion.BLL.Servicios;
using Pantallas_Sistema_Facturacion.DAL.Repositorios;

namespace Pantallas_Sistema_Facturacion
{
    public partial class frmCliente : MaterialForm
    {
        private readonly IServicioCliente _servicioCliente;

        public frmCliente()
        {
            InitializeComponent();
            _servicioCliente = new ServicioCliente(new RepositorioCliente());
        }

        private void frmEditarCliente_Load(object sender, EventArgs e) { }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string documento = txtDocumento.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(documento) ||
                string.IsNullOrEmpty(direccion) ||
                string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cliente = new Cliente
                {
                    NombreCliente = nombre,
                    Documento = documento,
                    Direccion = direccion,
                    Telefono = telefono,
                    Email = email
                };

                _servicioCliente.CrearCliente(cliente);
                MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}