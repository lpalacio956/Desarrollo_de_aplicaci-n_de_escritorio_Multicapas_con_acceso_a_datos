using System;

namespace Pantallas_Sistema_Facturacion.Core.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}