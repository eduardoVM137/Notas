using CRUDCORE.Datos;
using Microsoft.AspNetCore.Mvc;
using Notas.Models;

namespace Notas.Controllers
{
    public class LoginController : Controller
    {
        LoginDatos _LoginDatos = new LoginDatos();


        public IActionResult Mostrar(/*int idUsuario*/)
        {
            //var oLista = _LoginDatos.Mostrar();

            //if (!String.IsNullOrEmpty(idUsuario))
            //{
            //    oLista = _LoginDatos.Bucar_Nota_Titulo(titulo);
            //}
            //public IActionResult Mostrar()
            //{
            //    //var oLista = _LoginDatos.Mostrar();

            //    //if (!String.IsNullOrEmpty(titulo))
            //    //{
            //    //    oLista = _LoginDatos.Bucar_Nota_Titulo(titulo);
            //    //}

            //    return View();
            //}

            return View();
        }
        public IActionResult Mantemiento(int idUsuario)
        {
            var oLista = _LoginDatos.Mostrar();

            if (!String.IsNullOrEmpty(Convert.ToString(idUsuario)))
            {
                UsuarioDatos _UsuarioDatos = new UsuarioDatos();
                ViewBag.objUsuario = _UsuarioDatos.Obtener(idUsuario);
                oLista = _LoginDatos.Bucar_Login_idUsuario(idUsuario);
            }


            return View(oLista);
        }


        public IActionResult BuscarLogin(string Usuario, string Contraseña)
        {

            int idUsuario = 1; // Definir el idUsuario como constante o de alguna otra manera
            LoginDatos _LoginDatos = new LoginDatos();
            bool ExisteElUsuario = _LoginDatos.ValidarUsuario(idUsuario, Usuario, Contraseña);

            ViewBag.ExisteElUsuario = ExisteElUsuario;

            return View();
        }


        [HttpPost]
        public IActionResult Insertar([FromBody] Login miLogin)
        {
            var _resultado = _LoginDatos.Insertar(miLogin);


            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });


        }
        [HttpPut]
        public IActionResult Editar([FromBody] Login miLogin)
        {
            var _resultado = _LoginDatos.Editar(miLogin);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

        [HttpDelete]
        public IActionResult Eliminar(int idLogin)
        {

            var respuesta = _LoginDatos.Eliminar(idLogin);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
        }

    }
}
