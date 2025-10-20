using System.Data;
using Pantallas_Sistema_Facturacion.Core.Modelos;

namespace Pantallas_Sistema_Facturacion.DAL.Repositorios
{
    public interface IRepositorioCliente
    {
        DataTable ListarClientesDataTable();
        void CrearCliente(Cliente cliente);
        void BorrarCliente(int id);
        void ActualizarCliente(Cliente cliente);
    }
}