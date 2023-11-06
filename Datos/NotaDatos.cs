
using System.Data.SqlClient;
using System.Data;
using Notas.Models;

namespace CRUDCORE.Datos
{
    public class NotaDatos
    {

        public List<Nota> Mostrar()
        {

            var oLista = new List<Nota>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spMostrar_NotaT", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Nota()
                        {
                            intidNota = Convert.ToInt32(dr["idNota"]),
                            strTitulo = dr["Titulo"].ToString(),
                            strComentario = dr["Comentario"].ToString(),
                            dtFecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"].ToString()),
                            refCategoria =new Categoria()
                            {

                                strTitulo= dr["Titulo_Categoria"].ToString()
                            },
                            refUsuario =new Usuario()
                            {

                                strNombre = dr["Nombre_Usuario"].ToString()
                            }
                    });

                    }
                }
            }

            return oLista;
        }

        public Nota Obtener(int idNota)
        {

            var miNota = new Nota(); 

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscar_NotaID", conexion);
                cmd.Parameters.AddWithValue("idNota", idNota);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        miNota.intidNota = Convert.ToInt32(dr["idNota"]);
                        miNota.strTitulo = dr["Titulo"].ToString();
                        miNota.strComentario = dr["Comentario"].ToString();
                        miNota.strComentario = dr["Comentario"].ToString();
                        miNota.dtFecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"].ToString());

                        miNota.refCategoria = new Categoria()
                        {
                            strTitulo = dr["Titulo_Categoria"].ToString()
                        };
                        miNota.refUsuario = new Usuario()
                        {

                            strNombre = dr["Nombre_Usuario"].ToString()
                        };

                    }
                }
            }

            return miNota;
        }
        public List<Nota> Bucar_Nota_Titulo(string miTitulo)
        {

            var oLista = new List<Nota>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Nota_Titulo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@titulo", miTitulo);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Nota()
                                {
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    strTitulo = dr["Titulo"].ToString(),
                                    strComentario = dr["Comentario"].ToString(),
                                    refCategoria = new Categoria()
                                    {

                                        strTitulo = dr["Titulo_Categoria"].ToString()
                                    },
                                    refUsuario = new Usuario()
                                    {

                                        strNombre = dr["Nombre_Usuario"].ToString()
                                    }
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

        public bool Insertar(Nota miNota) {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spInsertar_Nota", conexion);
                    cmd.Parameters.AddWithValue("idUsuario_Creador", miNota.intidUsuario_Creador);
                    cmd.Parameters.AddWithValue("idCategoria", miNota.intidCategoria);
                    cmd.Parameters.AddWithValue("titulo", miNota.strTitulo);
                    cmd.Parameters.AddWithValue("comentario", miNota.strComentario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e) {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(Nota miNota)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEditar_Nota  ", conexion);
                    cmd.Parameters.AddWithValue("idNota", miNota.intidNota);
                    cmd.Parameters.AddWithValue("idCategoria", miNota.intidCategoria);
                    cmd.Parameters.AddWithValue("titulo", miNota.strTitulo);
                    cmd.Parameters.AddWithValue("comentario", miNota.strComentario);
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

        public bool Eliminar(int idNota)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminar_Nota", conexion);
                    cmd.Parameters.AddWithValue("idNota", idNota);
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
