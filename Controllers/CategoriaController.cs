using CRUDCORE.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notas.Models;

namespace Notas.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos _CategoriaDatos = new CategoriaDatos();

        public IActionResult Mostrar(/*string titulo*/)
        {
            //var oLista = _CategoriaDatos.Mostrar();

            //if (!String.IsNullOrEmpty(titulo))
            //{
            //    oLista = _CategoriaDatos.Bucar_Categoria_Titulo(titulo);
            //}
            return View(/*oLista*/);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Categoria modelo)
        {
            var _resultado = _CategoriaDatos.Insertar(modelo);
            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }
        [HttpPut]
        public IActionResult Editar([FromBody] Categoria modelo)
        {
            var _resultado = _CategoriaDatos.Editar(modelo);
            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

        [HttpDelete]
        public IActionResult Eliminar(int idCategoria)
        {
            var respuesta = _CategoriaDatos.Eliminar(idCategoria);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
        }


    }
}
