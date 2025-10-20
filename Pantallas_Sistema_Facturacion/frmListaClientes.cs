using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using .BLL.Servicios;
using .DAL.Repositorios;
using .Core.Modelos;

namespace 
{
    public partial class frmListaClientes : MaterialForm
    {
        private readonly IServicioCliente _servicioCliente;

        public frmListaClientes()
        {
            InitializeComponent();
            dgClientes.CellContentClick += dgClientes_CellContentClick;
            dgClientes.CellEndEdit += dgClientes_CellEndEdit;
            _servicioCliente = new ServicioCliente(new RepositorioCliente());
        }

        public void llenar_grid()
        {
            try
            {
                DataTable dt = _servicioCliente.ObtenerClientesDataTable();
                dgClientes.DataSource = dt;

                if (dgClientes.Columns.Contains("borrar"))
                    dgClientes.Columns.Remove("borrar");

                DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn
                {
                    Name = "borrar",
                    HeaderText = "Borrar",
                    Text = "Borrar",
                    UseColumnTextForButtonValue = true
                };
                dgClientes.Columns.Add(btnBorrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            dgClientes.ReadOnly = false;
            llenar_grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCliente nuevoCliente = new frmCliente();
            if (nuevoCliente.ShowDialog() == DialogResult.OK)
            {
                llenar_grid();
            }
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgClientes.Columns[e.ColumnIndex].Name == "borrar")
            {
                int id = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells["id"].Value);
                var confirm = MessageBox.Show("¿Está seguro de borrar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _servicioCliente.BorrarCliente(id);
                        MessageBox.Show("Cliente borrado correctamente.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenar_grid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al borrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells["id"].Value),
                    NombreCliente = dgClientes.Rows[e.RowIndex].Cells["nombre_cliente"].Value.ToString(),
                    Documento = dgClientes.Rows[e.RowIndex].Cells["documento"].Value.ToString(),
                    Direccion = dgClientes.Rows[e.RowIndex].Cells["direccion"].Value.ToString(),
                    Telefono = dgClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString(),
                    Email = dgClientes.Rows[e.RowIndex].Cells["email"].Value.ToString()
                };

                _servicioCliente.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}