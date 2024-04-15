using CRUDCORE.Datos;
using Microsoft.AspNetCore.Mvc;
using Notas.Models;

namespace Notas.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos _UsuarioDatos = new UsuarioDatos();


        public IActionResult Mostrar(string idUsuario)
        {
            var oLista = _UsuarioDatos.Mostrar();

            if (!String.IsNullOrEmpty(idUsuario))
            {
                oLista = _UsuarioDatos.Bucar_Login_idUsuario(idUsuario);
            }

            return View(oLista);
        }


        public IActionResult BuscarUsuarioId(int idUsuario)
        {

            Usuario oLista = _UsuarioDatos.Obtener(idUsuario);

            return View(oLista);
        }


        [HttpPost]
        public IActionResult Insertar(Usuario usuario)
        {
            if (usuario.imgFoto != null && usuario.imgFoto.Length > 0)
            {

                using (var memoryStream = new MemoryStream())
                {
                    usuario.imgFoto.CopyTo(memoryStream);
                    usuario.imgFotoBytes = memoryStream.ToArray();
                }
            }
            //else {
            //    var img = Properties.Resources.NombreDeTuImagen; // Cambia 'NombreDeTuImagen' al nombre real de tu imagen

            //    // Convertir la imagen en un byte[]
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        img.Save(memoryStream, img.RawFormat);
            //        usuario.imgFotoBytes = memoryStream.ToArray();
            //    }
            //} 
         

            var respuesta = _UsuarioDatos.Insertar(usuario);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
             
        }



        [HttpDelete]
        public IActionResult Eliminar(int idUsuario)
        {

            var respuesta = _UsuarioDatos.Eliminar(idUsuario);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
        }


    
        [HttpPut]
        public IActionResult Editar(Usuario modelo)
        {

            if (modelo.imgFoto != null && modelo.imgFoto.Length > 0)
            {

                using (var memoryStream = new MemoryStream())
                {
                    modelo.imgFoto.CopyTo(memoryStream);
                    modelo.imgFotoBytes = memoryStream.ToArray();
                }
            }

            var _resultado = _UsuarioDatos.Editar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

 


    }
}
