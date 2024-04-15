using CRUDCORE.Datos;
using Microsoft.AspNetCore.Mvc;
using Notas.Models;

namespace Notas.Controllers
{
    public class Detalle_NotaController : Controller
    {
        Detalle_NotaDatos _Detalle_NotaDatos = new Detalle_NotaDatos();

        public IActionResult Mostrar(string idNota, string idUsuario/*,string Categoria,string Usuario_creador*/)
        {
            var oLista = _Detalle_NotaDatos.Mostrar();
            ViewBag.VerDetalle = false;

      
            NotaDatos _NotaDatos = new NotaDatos();
            List<Nota> miListaNotas = _NotaDatos.Mostrar();

            UsuarioDatos _UsuarioDatos = new UsuarioDatos();
            List<Usuario> miListaUsuario = _UsuarioDatos.Mostrar();

            ViewBag.ListaUsuario = miListaUsuario;
            ViewBag.ListaNota = miListaNotas;
            if (!String.IsNullOrEmpty(idNota) && !String.IsNullOrEmpty(idUsuario))//no estan vacias--falta ninguna
            {
                oLista = _Detalle_NotaDatos.spBuscar_Detalle_Nota_Por_idNota_Usuario(idNota, idUsuario);

                Nota objeto = _NotaDatos.Obtener(Convert.ToInt32(idNota));
                ViewBag.miNota = objeto;
                ViewBag.VerDetalle = true;
                //ViewBag.UsuarioCreador = Usuario_creador;
                //ViewBag.NombreCategoria = Categoria;
            }
            else if (String.IsNullOrEmpty(idNota) && !String.IsNullOrEmpty(idUsuario))//vacia solo idnota --falta idnota
            {
                oLista = _Detalle_NotaDatos.spBuscar_Detalle_Nota_Por_idUsuario(idUsuario);
            }
            else if (!String.IsNullOrEmpty(idNota) && String.IsNullOrEmpty(idUsuario))//vacia  solo idusuario--falta idusuario
            {
                oLista = _Detalle_NotaDatos.spBuscar_Detalle_Nota_Por_idNota(idNota);
                Nota objeto = _NotaDatos.Obtener(Convert.ToInt32(idNota));
                ViewBag.miNota = objeto;
                ViewBag.VerDetalle = true;
            }


            return View(oLista);
        }
        public IActionResult MostrarPendientes(/*string idUsuario*/ bool Pendientes)
        {
            var oLista = _Detalle_NotaDatos.spBuscar_Detalle_Nota_Pendientes("1",Pendientes);


            NotaDatos _NotaDatos = new NotaDatos();
            List<Nota> miListaNotas = _NotaDatos.Mostrar();

            UsuarioDatos _UsuarioDatos = new UsuarioDatos();
            List<Usuario> miListaUsuario = _UsuarioDatos.Mostrar();

            ViewBag.ListaUsuario = miListaUsuario;
            ViewBag.ListaNota = miListaNotas;
            return View(oLista);
        }
        //public IActionResult MostrarAsignadasPorNota(/*string idNota */)
        //{
        //    var oLista = _Detalle_NotaDatos.spBuscar_Detalle_Nota_Por_idNota("1");
        //    return View(oLista);
        //}

        public IActionResult BuscarNotaId(int idnota)
        {

            NotaDatos _NotaDatos = new NotaDatos();
            Nota oLista = _NotaDatos.Obtener(idnota);



            return View(oLista);
        }
        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Detalle_Nota modelo)
        {
            var _resultado = _Detalle_NotaDatos.Insertar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });


        }
        [HttpPut]
        public IActionResult Cambiar_Estado(Detalle_Nota modelo)
        { 
            var _resultado = _Detalle_NotaDatos.Cambiar_Estado_Detalle_Nota(modelo);
            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });

        }

  

        [HttpDelete]
        public IActionResult Eliminar(int idDetalleNota)
        {

            var respuesta = _Detalle_NotaDatos.Eliminar(idDetalleNota);

            if (respuesta)
                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = respuesta, msg = "errror" });
        }


    }
}
