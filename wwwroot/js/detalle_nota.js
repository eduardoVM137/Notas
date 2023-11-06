
const _modeloDetalleNota = {
    strTitulo: "",
    strComentario: "",
    idAccion: "",
    intIdDetalle_Nota: 0,
    intIdNota: 0,
    intIdUsuario: 0,
    strDescripcion: "",
    imgImagen: "",
    dtFecha: "",
    strEstado: ""



}
function MostrarDetalleNota() {

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
    // MostrarCategoria();

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



    $("#txtTitulo").val(_modeloDetalleNota.strTitulo);
    $("#txtComentario").val(_modeloDetalleNota.strComentario);
    $("#txtDescripcion").val(_modeloDetalleNota.strDescripcion);
    $("#txtImagen").val(_modeloDetalleNota.imgImagen);
    const dtFechaInput = document.getElementById('dtFecha');
    dtFechaInput.value = _modeloDetalleNota.dtFecha;

    $("#txtRealizado").val(_modeloDetalleNota.blRealizado);
    // $("#cboDepartamento").val(_modeloEmpleado.idDepartamento == 0 ? $("#cboDepartamento option:first").val() : _modeloEmpleado.idDepartamento)

    $("#modalDtNota").modal("show");


}




$(document).on("click", ".boton-nuevo-dtnota", function () {

    _modeloDetalleNota.idAccion = "Nuevo";
    _modeloDetalleNota.intIdDetalle_Nota = 0;
    _modeloDetalleNota.intIdNota = 0;
    _modeloDetalleNota.intIdUsuario = 0;
    _modeloDetalleNota.strDescripcion = "";
    _modeloDetalleNota.imgImagen = "";

    const fechaTexto = "2023-08-07 15:30";

    // Convertir la fecha de texto en un objeto de fecha
    const fechaObj = new Date(fechaTexto.replace(' ', 'T'));


    const fechaFormateada = fechaObj.toISOString().slice(0, 16);

    _modeloDetalleNota.dtFecha = fechaFormateada;
    _modeloDetalleNota.blRealizado = false;
    MostrarModal();

})


$(document).on("click", ".boton-cambiar-dtnota", function () {

    _modeloDetalleNota.idAccion = "";
     _modeloDetalleNota.intIdDetalle_Nota = $(this).data("iddt_nota");
     _modeloDetalleNota.strEstado = $(this).data("estado");



    const formData = new FormData();
    formData.append('_intidDetalle_Nota', _modeloDetalleNota.intIdDetalle_Nota);
    formData.append('strEstado', _modeloDetalleNota.strEstado); 

    fetch("/Detalle_Nota/Cambiar_Estado", {
        method: "PUT",
        body: formData
    })

        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la solicitud');
            }
            return response.json();
        })
        .then(data => {
            if (data.valor) { 
                Swal.fire("Listo!", "Usuario fue Actualizado", "success");
                MostrarNotas();
            } else {
                Swal.fire("Lo sentimos", "No se pudo Editar el usuario", "error");
            }
        })
        .catch(error => {
            console.error(error);
            Swal.fire("Error", "Hubo un problema al procesar la solicitud", "error");
        })
}




    _modeloDetalleNota.idAccion = "";
});



$(document).on("click", ".boton-eliminar-dtnota", function () {


    var idDetalle_Nota = $(this).data("iddt_nota");
    var descripcion = $(this).data("descripcion");
    _modeloDetalleNota.intIdDetalle_Nota = idDetalle_Nota;
    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar Nota "${descripcion}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch("/Detalle_Nota/Finalizar", {
                method: "PUT",
                headers: { "Content-Type": "application/json; charset=utf-8" },
                body: JSON.stringify(_modeloDetalleNota)
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        //   $("#modalCategoria").modal("hide");
                        Swal.fire("Listo!", "La Categoria fue Actualizada", "success");
                        //        MostrarCategoria();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
                })

        }



    })

    _modeloDetalleNota.idAccion = "";

})



$(document).on("click", ".boton-guardar-cambios-dtnota", function () {

    _modeloDetalleNota.strTitulo = $("#txtTitulo").val();
    _modeloDetalleNota.strDescripcion = $("#txtDescripcion").val();

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