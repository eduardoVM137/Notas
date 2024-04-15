namespace Notas.Models
{
    public class Detalle_Nota
    {
        public int _intidDetalle_Nota { get; set; }
        public int intidNota { get; set; }
        public int _intidUsuario { get; set; }
        public string _strDescripcion { get; set; }
        public byte[] _imgImagen { get; set; }
        public DateTime _dtFecha { get; set; }

        public string strEstado { get; set; }
        public Nota refNnota { get; set; }
        public Usuario refUsuario { get; set; }


    }
}
