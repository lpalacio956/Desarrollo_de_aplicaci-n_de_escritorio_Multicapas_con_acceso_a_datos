using System;
using MySql.Data.MySqlClient;
using Pantallas_Sistema_Facturacion.Core.Modelos;

namespace Pantallas_Sistema_Facturacion.DAL.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT usuario, rol, contrasena FROM usuarios WHERE usuario = @usuario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                NombreUsuario = reader["usuario"].ToString(),
                                Rol = reader["rol"].ToString(),
                                Contrasena = reader["contrasena"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool ValidarContrasena(string nombreUsuario, string contrasena)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND contrasena = @contrasena";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void ActualizarContrasena(string nombreUsuario, string nuevaContrasena)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string update = "UPDATE usuarios SET contrasena = @nueva WHERE usuario = @usuario";
                using (var cmd = new MySqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@nueva", nuevaContrasena);
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}