
using System.Data.SqlClient;
using System.Data;
using Notas.Models;

namespace CRUDCORE.Datos
{
    public class LoginDatos
    {

        public List<Login> Mostrar()
        {

            var oLista = new List<Login>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spMostrar_Login", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Login()
                        {
                            intidLogin = Convert.ToInt32(dr["idLogin"]),
                            intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                            strUsuario = dr["Usuario"].ToString(),
                            strContraseña = dr["Contraseña"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public Login Obtener(int idLogin)
        {

            var miLogin = new Login();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscar_Login_ID", conexion);
                cmd.Parameters.AddWithValue("idNota", idLogin);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        miLogin.intidLogin = Convert.ToInt32(dr["idNota"]);
                        miLogin.intidUsuario = Convert.ToInt32(dr["idUsuario"]);
                        miLogin.strUsuario = dr["Usuario"].ToString();
                        miLogin.strContraseña = dr["Contraseña"].ToString();

                    }
                }
            }

            return miLogin;
        }
        public bool ValidarUsuario(int idUsuario, string Usuario, string Contraseña)
        {


            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("usuario", Usuario);
                cmd.Parameters.AddWithValue("contraseña", Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        return true;
                    }

                }
            }

            return false;
        }
        public List<Login> Bucar_Login_idUsuario(int idUsuario)
        {

            var oLista = new List<Login>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Login_Usuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Login()
                                {
                                    intidLogin = Convert.ToInt32(dr["idLogin"]),
                                    intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    strUsuario = dr["Usuario"].ToString(),
                                    strContraseña = dr["Contraseña"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
            }
            return oLista;
        }
        public bool Insertar(Login miLogin)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spInsertar_Login", conexion);
                    cmd.Parameters.AddWithValue("idUsuario", miLogin.intidUsuario);
                    cmd.Parameters.AddWithValue("usuario", miLogin.strUsuario);
                    cmd.Parameters.AddWithValue("contraseña", miLogin.strContraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(Login miLogin)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEditar_Login", conexion);
                    cmd.Parameters.AddWithValue("idLogin", miLogin.intidLogin); 
                    cmd.Parameters.AddWithValue("usuario", miLogin.strUsuario);
                    cmd.Parameters.AddWithValue("contraseña", miLogin.strContraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int idLogin)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminar_Login", conexion);
                    cmd.Parameters.AddWithValue("idLogin", idLogin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
