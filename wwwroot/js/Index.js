//$(document).ready(function () {
//    tbNotas = $("#tbNotas").DataTable({
//        "columnDefs": [{
//            "targets": -1,
//            "data": null,
//            "defaultContent": "<div class='text-center'><div class='btn-group'><button name ='accion' value ='editar'class='btn btn-primary btnEditar'>Editar</button><button class='btn btn-danger btnBorrar'>Borrar</button></div></div>"
//        }],

//        "language": {
//            "lengthMenu": "Mostrar _MENU_ registros",
//            "zeroRecords": "No se encontraron resultados",
//            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
//            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
//            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
//            "sSearch": "Buscar:",
//            "oPaginate": {
//                "sFirst": "Primero",
//                "sLast": "Último",
//                "sNext": "Siguiente",
//                "sPrevious": "Anterior"
//            },
//            "sProcessing": "Procesando...",
//        }
//    });

//    $("#btnNuevo").click(function () {
//        $(".modal-header").css("background-color", "#1cc88a");
//        $(".modal-header").css("color", "white");
//        $(".modal-title").text("Nueva Tarea");
//        $("#modalCRUDInsertar").modal("show");
//        id = null; 



//    });
//$("#btnEditar").click(function () {
//    $(".modal-header").css("background-color", "#1cc88a");
//    $(".modal-header").css("color", "white");
//    $(".modal-title").text("Editar Tarea");
//    $("#modalCRUDInsertar").modal("show");
//    id = null;
//    opcion = 1; //alta



//});

const _modeloNota = {
    idAccion: "",
    intIdNota: 8,
    intIdUsuario_Creador: 1,
    intIdCategoria: 1,
    strTitulo: "",
    strComentario: ""



}
function MostrarNotas() {


    //fetch("/Categoria/MostrarLista")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response)
    //    })
    //    .then(responseJson => {

    //        if (responseJson.length > 0) {
    //            responseJson.forEach((item) => {

    //                $("#cboCategoria").append(
    //                    $("<option>").val("1").text("ffff")
    //                )

    //            })
    //        }

    //    })



}




//document.addEventListener("DOMContentLoaded", function () { 
//    MostrarNotas();






//}, false)


function MostrarModal() {

    // Usa los datos renderizados en el HTML para llenar el combo box
    //categoriasData.forEach((item) => {
    //    const option = document.createElement("option");
    //    option.value = item.intIdCategoria;
    //    option.textContent = item.strTitulo;
    //    document.getElementById("cboCategoria").appendChild(option);
    //});

    $("#modalNota").modal("show");

}



$(document).on("click", ".boton-nuevo-nota", function () {

    _modeloNota.idAccion = "Nuevo";
    _modeloNota.intIdNota = 66;
    _modeloNota.intIdUsuario_Creador = 1;
    _modeloNota.intIdCategoria = 1;
    _modeloNota.strComentario = "";
    _modeloNota.strTitulo = "";
    MostrarModal();

})

$(document).on("click", ".boton-editar-nota", function () {


    _modeloNota.idAccion = "Editar";
    var idNota = $(this).data("idnota");
    var titulo = $(this).data("titulo");
    var comentario = $(this).data("comentario");
    _modeloNota.intIdNota = idNota;
    _modeloNota.strTitulo = titulo;
    _modeloNota.strComentario = comentario;

    $("#txtTitulo").val(_modeloNota.strTitulo);
    $("#txtComentario").val(_modeloNota.strComentario);

    //$("#cboDepartamento").val(_modeloEmpleado.idDepartamento == 0 ? $("#cboDepartamento option:first").val() : _modeloEmpleado.idDepartamento)

    MostrarModal();

})

$(document).on("click", ".boton-eliminar-nota", function () {


    var idNota = $(this).data("idnota");
    var titulo = $(this).data("titulo");
    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar Nota "${titulo}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch(`/Nota/Eliminar?idNota=${idNota}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Nota Eliminada", "success");
                        MostrarNotas();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

    _modeloNota.idAccion = "";

})

$(document).on("click", ".boton-detalle-nota", function () {



    //var idNota = $(this).data("idNota");
    //var idUsuario = "1"//$(this).data("descripcion");
    //window.location.href = "/Detalle_Nota/Mostrar?idNota=" + idNota + "&idUsuario=" + encodeURIComponent(idUsuario);


})

//$(document).on("click", ".btn-sm boton-detalle-nota", function () {
//    var idUsuario = "1";
//    var IdNota = $(this).data("idnota");
//    var url = "/Detalle_Nota/Mostrar?idNota=" + encodeURIComponent(idNota) +
//        "&idUsuario=" + encodeURIComponent(idUsuario);

//    window.location.href = url;
//}

$(document).on("click", ".boton-guardar-cambios-nota", function () {

    _modeloNota.strTitulo = $("#txtTitulo").val();
    _modeloNota.strComentario = $("#txtComentario").val();
    _modeloNota.intIdCategoria = 1;
    _modeloNota.intIdUsuario_Creador = 1;
    _modeloNota.f = 1;

    if (_modeloNota.idAccion == "Nuevo") {

        fetch("/Nota/Insertar", {
            method: "POST",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(_modeloNota)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {//ff

                if (responseJson.valor) {
                    $("#modalNota").modal("hide");
                    Swal.fire("Listo!", "Nota fue creada", "success");
                    MostrarNotas();//ff
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo crear", "error");
            })

    } else {

        fetch("/Nota/Editar", {//ff
            method: "PUT",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(_modeloNota)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {//ffff

                if (responseJson.valor) {
                    $("#modalNota").modal("hide");
                    Swal.fire("Listo!", "La Nota fue Actualizada", "success");
                    MostrarNotas();//ff
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
            })

    }

    _modeloNota.idAccion = "";

})