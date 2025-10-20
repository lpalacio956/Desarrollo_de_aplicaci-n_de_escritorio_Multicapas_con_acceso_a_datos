using System;
using .Core.Modelos;
using .DAL.Repositorios;

namespace .BLL.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorio;

        public ServicioUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            return _repositorio.ObtenerPorNombre(nombreUsuario);
        }

        public bool ValidarCredenciales(string nombreUsuario, string contrasena)
        {
            return _repositorio.ValidarContrasena(nombreUsuario, contrasena);
        }

        public bool CambiarContrasena(string nombreUsuario, string antigua, string nueva, out string mensaje)
        {
            mensaje = null;

            if (string.IsNullOrWhiteSpace(antigua) || string.IsNullOrWhiteSpace(nueva))
            {
                mensaje = "Debe completar ambos campos.";
                return false;
            }

            if (!_repositorio.ValidarContrasena(nombreUsuario, antigua))
            {
                mensaje = "La contraseña antigua es incorrecta.";
                return false;
            }

            try
            {
                _repositorio.ActualizarContrasena(nombreUsuario, nueva);
                mensaje = "Contraseña actualizada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar la contraseña: " + ex.Message;
                return false;
            }
        }
    }
}