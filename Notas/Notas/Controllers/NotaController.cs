using CRUDCORE.Datos;
using Microsoft.AspNetCore.Mvc;
using Notas.Models;
using System.Data;

namespace Notiyas.Controllers
{
    public class NotaController : Controller
    {
        NotaDatos _NotaDatos = new NotaDatos();


        public IActionResult Mostrar(string titulo)
        {
            var oLista = _NotaDatos.Mostrar(); 

            if (!String.IsNullOrEmpty(titulo))
            {
                oLista = _NotaDatos.Bucar_Nota_Titulo(titulo);
            }
            CategoriaDatos _CategoriaDatos = new CategoriaDatos();
            List <Categoria> miListaCategoria= _CategoriaDatos.Mostrar();

            UsuarioDatos _UsuarioDatos = new UsuarioDatos();
            List<Usuario> miListaUsuario = _UsuarioDatos.Mostrar();

            ViewBag.ListaCategoria = miListaCategoria;
            ViewBag.ListaUsuario= miListaUsuario;

            return View(oLista);
        }

 
        [HttpPost]
        public IActionResult Insertar([FromBody] Nota modelo)
        {
            var _resultado =  _NotaDatos.Insertar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });


        }
        [HttpPut]
        public IActionResult  Editar([FromBody] Nota modelo)
        {
            var _resultado =  _NotaDatos.Editar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

        [HttpDelete]
        public IActionResult Eliminar(int idNota)
        {

            var respuesta = _NotaDatos.Eliminar(idNota);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
        }


    }
}
