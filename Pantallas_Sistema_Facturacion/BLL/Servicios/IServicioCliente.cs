using System.Data;
using .Core.Modelos;

namespace .BLL.Servicios
{
    public interface IServicioCliente
    {
        DataTable ObtenerClientesDataTable();
        void CrearCliente(Cliente cliente);
        void BorrarCliente(int id);
        void ActualizarCliente(Cliente cliente);
    }
}