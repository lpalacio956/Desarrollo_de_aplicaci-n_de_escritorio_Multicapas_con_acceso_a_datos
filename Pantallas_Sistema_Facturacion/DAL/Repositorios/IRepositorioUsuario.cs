using Pantallas_Sistema_Facturacion.Core.Modelos;

namespace Pantallas_Sistema_Facturacion.DAL.Repositorios
{
    public interface IRepositorioUsuario
    {
        Usuario ObtenerPorNombre(string nombreUsuario);
        bool ValidarContrasena(string nombreUsuario, string contrasena);
        void ActualizarContrasena(string nombreUsuario, string nuevaContrasena);
    }
}