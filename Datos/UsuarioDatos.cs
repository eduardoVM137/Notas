
using System.Data.SqlClient;
using System.Data;
using Notas.Models;

namespace CRUDCORE.Datos
{
    public class UsuarioDatos
    {
        public List<Usuario> Mostrar()
        {

            var oLista = new List<Usuario>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spMostrar_Usuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Usuario()
                        {
                            intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                            strNombre = dr["Nombre"].ToString(),
                            strEmail = dr["Email"].ToString(),
                            imgFotoBytes = (byte[])dr["Foto"]
                            //_imgFoto= Convert.ToByte(dr["Foto"]),
                            //dtFecha_Registro = Convert.ToDateTime(dr["Fecha_Registro"])
                        });

                    }
                }
            }

            return oLista;
        }

        public Usuario Obtener(int idUsuario)
        {

            var miUsuario = new Usuario();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscar_Usuario_Id", conexion);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        miUsuario.intidUsuario = Convert.ToInt32(dr["idUsuario"]);
                        miUsuario.strNombre = dr["Nombre"].ToString();
                        miUsuario.strEmail = dr["Email"].ToString();
                        //miUsuario._imgFoto = Convert.ToBase64String(dr["Foto"]);
                        //miUsuario.dtFecha_Registro = Convert.ToDateTime(dr["Fecha_Registro"]);
                    }
                }
            }

            return miUsuario;
        }
        public List<Usuario> Bucar_Login_idUsuario(string idUsuario)
        {

            var oLista = new List<Usuario>();
            var cn = new Conexion();
            int miid = Convert.ToInt32(idUsuario);
            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Login_Usuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idUsuario", miid);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Usuario()
                                {
                                    intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    strNombre = dr["Nombre"].ToString(),
                                    strEmail = dr["Email"].ToString(),
                                    ////_imgFoto = Convert.ToByte(dr["Foto"]),
                                    //dtFecha_Registro = Convert.ToDateTime(dr["Fecha_Registro"])
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

        public bool Insertar(Usuario miUsuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spInsertar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("@nombre", miUsuario.strNombre);
                    cmd.Parameters.AddWithValue("@email", miUsuario.strEmail);
                    cmd.Parameters.Add(new SqlParameter("@foto", SqlDbType.Image) { Value = miUsuario.imgFotoBytes });

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



        public bool Editar(Usuario miUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEditar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("idUsuario", miUsuario.intidUsuario);
                    cmd.Parameters.AddWithValue("nombre", miUsuario.strNombre);
                    cmd.Parameters.AddWithValue("email", miUsuario.strEmail);

                    cmd.Parameters.Add(new SqlParameter("@foto", SqlDbType.Image) { Value = miUsuario.imgFotoBytes });
                    //cmd.Parameters.AddWithValue("fecha_registro", miUsuario.dtFecha_Registro);
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

        public bool Eliminar(int idUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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
