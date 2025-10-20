using System.Data;
using Pantallas_Sistema_Facturacion.Core.Modelos;
using Pantallas_Sistema_Facturacion.DAL.Repositorios;

namespace Pantallas_Sistema_Facturacion.BLL.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorioCliente _repositorio;

        public ServicioCliente(IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }

        public DataTable ObtenerClientesDataTable()
        {
            return _repositorio.ListarClientesDataTable();
        }

        public void CrearCliente(Cliente cliente)
        {
            _repositorio.CrearCliente(cliente);
        }

        public void BorrarCliente(int id)
        {
            _repositorio.BorrarCliente(id);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _repositorio.ActualizarCliente(cliente);
        }
    }
}