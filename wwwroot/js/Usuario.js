

const _modeloUsuario = {
    idAccion: "", 
    intIdUsuario: 1, 
    strNombre: "",
    strEmail: "",
    imgFoto: null

     
}
function MostrarNotas() {


 


}
function previewImage() {
    const input = document.getElementById('image');
    const previewContainer = document.getElementById('previewContainer');
    const preview = document.getElementById('preview');

    const file = input.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            preview.src = e.target.result;
            previewContainer.style.display = 'block';
        }
        reader.readAsDataURL(file);
    }
}
 
function MostrarModal() {


    $("#txtNombre").val(_modeloUsuario.strNombre);
    $("#txtEmail").val(_modeloUsuario.strEmail);
    $("#image").val(_modeloUsuario.imgFoto);
    $("#modalUsuario").modal("show");

}
 


$(document).on("click", ".boton-nuevo-usuario", function () {

    _modeloUsuario.idAccion = "Nuevo"; 
    //_modeloUsuario.intIdUsuario =1; 
    _modeloUsuario.strNombre = "";
    _modeloUsuario.strEmail = "";
    _modeloUsuario.imgFoto = ""; 
    MostrarModal();

})

$(document).on("click", ".boton-editar-usuario", function () {


    _modeloUsuario.idAccion = "Editar";
    var idUsuario = $(this).data("idusuario");
    var nombre = $(this).data("nombre");
    var email = $(this).data("email");
    //var foto = $(this).data("foto"); 

    _modeloUsuario.intIdUsuario = idUsuario;
    _modeloUsuario.strNombre = nombre;
    _modeloUsuario.strEmail = email;
    //_modeloUsuario.imgFoto = foto; 

    $("#txtNombre").val(_modeloUsuario.strNombre);
    $("#txtEmail").val(_modeloUsuario.strEmail);
    //$("#txtFoto").val(_modeloUsuario.imgFoto); 

    //$("#cboDepartamento").val(_modeloEmpleado.idDepartamento == 0 ? $("#cboDepartamento option:first").val() : _modeloEmpleado.idDepartamento)

    MostrarModal();

})
function openEditModal(idUsuario) {
    var imgElement = document.getElementById("preview");
    imgElement.setAttribute("data-idusuario", idUsuario);
    imgElement.src = '/TuControlador/GetUserImage?idUsuario=' + idUsuario;
}


$(document).on("click", ".boton-eliminar-usuario", function () {


    var idUsuario = $(this).data("idusuario");
    var nombre = $(this).data("nombre");
    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar Nota "${nombre}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch(`/Usuario/Eliminar?idUsuario=${idUsuario}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Usuario Eliminada", "success");
                        MostrarNotas();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

    _modeloUsuario.idAccion = "";

})

$(document).on("click", ".boton-guardar-cambios-usuario", function () {
    _modeloUsuario.strNombre = $("#txtNombre").val();
    _modeloUsuario.strEmail = $("#txtEmail").val();

    const formData = new FormData();
    formData.append('intidUsuario', _modeloUsuario.intIdUsuario);
    formData.append('strNombre', _modeloUsuario.strNombre);
    formData.append('strEmail', _modeloUsuario.strEmail);

    const inputImagen = document.getElementById('image');
    const imagenSeleccionada = inputImagen.files[0];

    if (imagenSeleccionada) {
        formData.append('imgFoto', imagenSeleccionada);//agg imagen default
    }

    if (_modeloUsuario.idAccion == "Nuevo") {
        fetch('/Usuario/Insertar', {
            method: 'POST',
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
                    $("#modalUsuario").modal("hide");
                    Swal.fire("Listo!", "Usuario fue creado", "success");
                    MostrarNotas();
                } else {
                    Swal.fire("Lo sentimos", "No se pudo crear el usuario", "error");
                }
            })
            .catch(error => {
                console.error(error);
                Swal.fire("Error", "Hubo un problema al procesar la solicitud", "error");
            })
    }
    else {
        fetch("/Usuario/Editar", {
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
                    $("#modalUsuario").modal("hide");
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




    _modeloUsuario.idAccion = "";
});
