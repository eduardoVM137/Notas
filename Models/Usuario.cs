namespace Notas.Models
{
    public class Usuario
    {
            public int intidUsuario { get; set; }
            public string strNombre { get; set; }
            public string strEmail { get; set; }
            public IFormFile imgFoto { get; set; } // Para recibir el archivo desde el front-end
            public byte[] imgFotoBytes { get; set; } // Para guardar y enviar el archivo a la base de datos
       


    }
}
