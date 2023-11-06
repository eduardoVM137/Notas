
using System.Data.SqlClient;
using System.Data;
using Notas.Models;

namespace CRUDCORE.Datos
{
    public class Detalle_NotaDatos
    {

        public List<Detalle_Nota> Mostrar()
        {

            var oLista = new List<Detalle_Nota>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscar_Detalle_Nota_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                 
                        oLista.Add(new Detalle_Nota()
                        {

                            _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                            intidNota = Convert.ToInt32(dr["idNota"]),
                            _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                            _strDescripcion = dr["Descripcion"].ToString(),
                            //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                            _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                            strEstado = (dr["Realizado"].ToString()),
                            refNnota = new Nota()
                            {
                                intidNota = Convert.ToInt32(dr["idNota"]),
                                strTitulo = dr["Titulo"].ToString(),
                                dtFecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"].ToString())
                            },
                            refUsuario = new Usuario()
                            {
                                strNombre = dr["Nombre_Usuario"].ToString()


                            }


                        });

                    }
                }
            }

            return oLista;
        }

        public List<Detalle_Nota> spBuscar_Detalle_Nota_Pendientes(string idUsuario,bool Pendientes)
        {

            var oLista = new List<Detalle_Nota>();
            var cn = new Conexion();
             
            int miidusuario = Convert.ToInt32(idUsuario);
            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    string spLlamar = "spBuscar_Detalle_Nota_Pendientes";
                    if (!Pendientes)
                    {
                        spLlamar = "spBuscar_Detalle_Nota_Realizadas";
                    }
                    using (SqlCommand command = new SqlCommand(spLlamar, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; 
                        command.Parameters.AddWithValue("idUsuario", miidusuario);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Detalle_Nota()
                                {

                                    _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    _strDescripcion = dr["Descripcion"].ToString(),
                                    //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                                    _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                    strEstado = (dr["Realizado"].ToString()),
                                    refNnota = new Nota()
                                    {
                                        intidNota = Convert.ToInt32(dr["idNota"]),
                                        strTitulo = dr["Titulo"].ToString()
                                    },
                                    refUsuario=new Usuario()
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


        public List<Detalle_Nota> spBuscar_Detalle_Nota_Por_idNota_Usuario(string idNota, string idUsuario)
        {

            var oLista = new List<Detalle_Nota>();
            var cn = new Conexion();

            int miidnota = Convert.ToInt32(idNota);
            int miidusuario = Convert.ToInt32(idUsuario);
            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Detalle_Nota_Por_idNota_Usuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("idNota", miidnota);
                        command.Parameters.AddWithValue("idUsuario", miidusuario);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Detalle_Nota()
                                {

                                    _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    _strDescripcion = dr["Descripcion"].ToString(),
                                    //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                                    _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                    strEstado = (dr["Realizado"].ToString()),
                                    refNnota = new Nota()
                                    {
                                        intidNota = Convert.ToInt32(dr["idNota"]),
                                        strTitulo = dr["Titulo"].ToString(),
                                        dtFecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"].ToString())
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

        public List<Detalle_Nota> spBuscar_Detalle_Nota_Por_idNota(string idNota)
        {

            var oLista = new List<Detalle_Nota>();
            var cn = new Conexion();

            int miidnota = Convert.ToInt32(idNota);
            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Detalle_Nota_Por_idNota", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("idNota", miidnota);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Detalle_Nota()
                                {

                                    _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    _strDescripcion = dr["Descripcion"].ToString(),
                                    //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                                    _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                    strEstado = (dr["Realizado"].ToString()),
                                    refNnota = new Nota()
                                    {
                                        intidNota = Convert.ToInt32(dr["idNota"]),
                                        strTitulo = dr["Titulo"].ToString(),
                                        dtFecha_Creacion = Convert.ToDateTime(dr["Fecha_Creacion"].ToString())
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
        public List<Detalle_Nota> spBuscar_Detalle_Nota_Por_idUsuario(string idUsuario)
        {

            var oLista = new List<Detalle_Nota>();
            var cn = new Conexion();

            int miidusuario = Convert.ToInt32(idUsuario);
            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Detalle_Nota_Por_Usuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("idUsuario", miidusuario);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Detalle_Nota()
                                {

                                    _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    _strDescripcion = dr["Descripcion"].ToString(),
                                    //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                                    _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                    strEstado = (dr["Realizado"].ToString()),
                                    refNnota = new Nota()
                                    {
                                        intidNota = Convert.ToInt32(dr["idNota"]),
                                        strTitulo = dr["Titulo"].ToString()
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

        public List<Detalle_Nota> Bucar_Nota_Titulo(string miTitulo)
        {

            var oLista = new List<Detalle_Nota>();
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
                                oLista.Add(new Detalle_Nota()
                                {

                                    _intidDetalle_Nota = Convert.ToInt32(dr["idDetalle_Nota"]),
                                    intidNota = Convert.ToInt32(dr["idNota"]),
                                    _intidUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    _strDescripcion = dr["Descripcion"].ToString(),
                                    //miDtNota._imgImagen = Convert.ToByte(dr["Imagen"]);
                                    _dtFecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                    strEstado = dr["Realizado"].ToString(),
                                    refNnota = new Nota()
                                    {
                                        intidNota = Convert.ToInt32(dr["idNota"]),
                                        strTitulo = dr["Titulo"].ToString()
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

        public bool Insertar(Detalle_Nota miDtNota) {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spInsertar_DetalleNota", conexion);
                    cmd.Parameters.AddWithValue("idNota", miDtNota.intidNota);
                    cmd.Parameters.AddWithValue("idUsuario", miDtNota._intidUsuario);
                    cmd.Parameters.AddWithValue("descripcion", miDtNota._strDescripcion);
                    cmd.Parameters.AddWithValue("imagen", miDtNota._imgImagen);
                    cmd.Parameters.AddWithValue("fecha", miDtNota._dtFecha);
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




        public bool Cambiar_Estado_Detalle_Nota(Detalle_Nota miDtNota)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spCambiar_Estado_Detalle_Nota", conexion);
                    cmd.Parameters.AddWithValue("idDetalle_Nota", miDtNota._intidDetalle_Nota);
                    cmd.Parameters.AddWithValue("Estado", miDtNota.strEstado);
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




        public bool Eliminar(int idDtNota)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminar_Nota", conexion);
                    cmd.Parameters.AddWithValue("idDetalle_Nota", idDtNota);
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
