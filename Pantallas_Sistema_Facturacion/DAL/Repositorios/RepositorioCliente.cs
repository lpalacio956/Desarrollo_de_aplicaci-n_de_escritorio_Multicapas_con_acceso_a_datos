using System;
using System.Data;
using MySql.Data.MySqlClient;
using Pantallas_Sistema_Facturacion.Core.Modelos;

namespace Pantallas_Sistema_Facturacion.DAL.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public DataTable ListarClientesDataTable()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nombre_cliente, documento, direccion, telefono, email FROM clientes";
                using (var da = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void CrearCliente(Cliente cliente)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO clientes (nombre_cliente, documento, direccion, telefono, email) VALUES (@nombre, @documento, @direccion, @telefono, @email)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.NombreCliente);
                    cmd.Parameters.AddWithValue("@documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BorrarCliente(int id)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM clientes WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE clientes SET nombre_cliente=@nombre, documento=@documento, direccion=@direccion, telefono=@telefono, email=@email WHERE id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.NombreCliente);
                    cmd.Parameters.AddWithValue("@documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cmd.Parameters.AddWithValue("@id", cliente.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}