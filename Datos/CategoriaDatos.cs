
using System.Data.SqlClient;
using System.Data;
using Notas.Models;

namespace CRUDCORE.Datos
{
    public class CategoriaDatos
    {

        public List<Categoria> Mostrar()
        {

            var oLista = new List<Categoria>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spMostrar_Categorias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Categoria()
                        {
                            intIdCategoria = Convert.ToInt32(dr["idCategoria"]),
                            strTitulo = dr["Titulo"].ToString(),
                            strDescripcion = dr["Descripcion"].ToString()
                    });

                    }
                }
            }

            return oLista;
        }

        public Categoria Obtener(int idCategoria)
        {

            var miNota = new Categoria();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spBuscar_CategoriaID", conexion);
                cmd.Parameters.AddWithValue("idCategoria", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        miNota.intIdCategoria = Convert.ToInt32(dr["idCategoria"]);
                        miNota.strTitulo = dr["Titulo"].ToString();
                        miNota.strDescripcion = dr["Descripcion"].ToString();
                    }
                }
            }

            return miNota;
        }
        public List<Categoria> Bucar_Categoria_Titulo(string miTitulo)
        {

            var oLista = new List<Categoria>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spBuscar_Categoria_Titulo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("titulo", miTitulo);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oLista.Add(new Categoria()
                                {
                                    intIdCategoria = Convert.ToInt32(reader["idCategoria"]),
                                    strTitulo = reader["Titulo"].ToString(),
                                    strDescripcion = reader["Descripcion"].ToString()
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

        public bool Insertar(Categoria miCategoria) {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spInsertar_Categoria", conexion); 
                    cmd.Parameters.AddWithValue("titulo", miCategoria.strTitulo);
                    cmd.Parameters.AddWithValue("descripcion", miCategoria.strDescripcion);
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


        public bool Editar(Categoria miCategoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEditar_Categoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoria", miCategoria.intIdCategoria);
                    cmd.Parameters.AddWithValue("titulo", miCategoria.strTitulo);
                    cmd.Parameters.AddWithValue("descripcion", miCategoria.strDescripcion);
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

        public bool Eliminar(int idCategoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spEliminar_Categoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoria", idCategoria);
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
