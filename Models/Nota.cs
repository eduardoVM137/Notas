using System.ComponentModel.DataAnnotations;

namespace Notas.Models
{
    public class Nota
    {

        public string? strTitulo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public int intidNota { get; set; }
        public int intidUsuario_Creador { get; set; }
        public int intidCategoria { get; set; }
        public DateTime dtFecha_Creacion { get; set; }
        public string strComentario { get; set; }

        public Usuario refUsuario { get; set; }
        public Categoria refCategoria { get; set; } 

    }
}
