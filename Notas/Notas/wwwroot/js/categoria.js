
const _modeloCategoria = {
    idAccion: "",
    intIdCategoria: 0,
    strTitulo: "",
    strDescripcion: ""



}// Call the dataTables jQuery plugin
$(document).ready(function () {
    new DataTable('#example');
});

//$(document).ready(function () {
//    tbNotas = $("#dataTable").DataTable({
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

function MostrarCategoria() {

    //fetch("/Nota/Mostrar")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response)
    //    })
    //    .then(responseJson => {//fff
    //        if (responseJson.length > 0) {

    //            $("#tbNotas tbody").html("");


    //            responseJson.forEach((nota) => {
    //                $("#tbNotas tbody").append(
    //                    $("<tr>").append(
    //                        $("<td>").text(nota.intIdNota),
    //                        $("<td>").text(nota.strTitulo),
    //                        $("<td>").text(nota.strComentario)

    //                    )
    //                )
    //            })

    //        }


    //    })



}




document.addEventListener("DOMContentLoaded", function () {
    MostrarCategoria();

    //fetch("/Categoria/Mostrar")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response)
    //    })
    //    .then(responseJson => {

    //        if (responseJson.length > 0) {
    //            responseJson.forEach((item) => {
    //                $("#cboCategoria").append(
    //                    $("<option>").val(item.intIdCategoria).text(item.strTitulo)
    //                )
    //            })
    //        }

    //    })




}, false)


function MostrarModal() {

    $("#txtTitulo").val(_modeloCategoria.strTitulo);
    $("#txtDescripcion").val(_modeloCategoria.strDescripcion);

    // $("#cboDepartamento").val(_modeloEmpleado.idDepartamento == 0 ? $("#cboDepartamento option:first").val() : _modeloEmpleado.idDepartamento)

    $("#modalCategoria").modal("show");

}



$(document).on("click", ".boton-nuevo-categoria", function () {

    _modeloCategoria.idAccion = "Nuevo";
    _modeloCategoria.intIdCategoria = 0;
    _modeloCategoria.strDescripcion = "";
    _modeloCategoria.strTitulo = "";
    MostrarModal();

})

$(document).on("click", ".boton-editar-categoria", function () {


    _modeloCategoria.idAccion = "Editar";
    var idCategoria = $(this).data("idcategoria");
    var titulo = $(this).data("titulo");
    var descripcion = $(this).data("descripcion");
    _modeloCategoria.intIdCategoria = idCategoria;
    _modeloCategoria.strTitulo = titulo;
    _modeloCategoria.strDescripcion = descripcion;

    MostrarModal();

})

$(document).on("click", ".boton-eliminar-categoria", function () {


    var idCategoria = $(this).data("idcategoria");
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

            fetch(`/Categoria/Eliminar?idCategoria=${idCategoria}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Categoria Eliminada", "success");
                        MostrarCategoria();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

    _modeloCategoria.idAccion = "";

})



$(document).on("click", ".boton-guardar-cambios-categoria", function () {

    _modeloCategoria.strTitulo = $("#txtTitulo").val();
    _modeloCategoria.strDescripcion = $("#txtDescripcion").val();

    if (_modeloCategoria.idAccion == "Nuevo") {

        fetch("/Categoria/Insertar", {
            method: "POST",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(_modeloCategoria)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {//ff

                if (responseJson.valor) {
                    $("#modalCategoria").modal("hide");
                    Swal.fire("Listo!", "Categoria fue creada", "success");
                    MostrarCategoria();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo crear", "error");
            })

    } else {

        fetch("/Categoria/Editar", {
            method: "PUT",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(_modeloCategoria)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {

                if (responseJson.valor) {
                    $("#modalCategoria").modal("hide");
                    Swal.fire("Listo!", "La Categoria fue Actualizada", "success");
                    MostrarCategoria();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
            })

    }

    _modeloCategoria.idAccion = "";

})