using Pantallas_Sistema_Facturacion.Core.Modelos;

namespace Pantallas_Sistema_Facturacion.BLL.Servicios
{
    public interface IServicioUsuario
    {
        Usuario ObtenerPorNombre(string nombreUsuario);
        bool ValidarCredenciales(string nombreUsuario, string contrasena);
        bool CambiarContrasena(string nombreUsuario, string antigua, string nueva, out string mensaje);
    }
}