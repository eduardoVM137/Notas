 
const _modeloLogin = {
    idAccion: "",
    intIdLogin: 889,
    intIdUsuario: 1,
    strUsuario:"",
    strContraseña: ""

     
}
 


//document.addEventListener("DOMContentLoaded", function () { 
//    MostrarNotas();

 




//}, false)


function MostrarModal() {

 

    $("#modalLogin").modal("show");

}



$(document).on("click", ".boton-nuevo-Login", function () {

    _modeloLogin.idAccion = "Nuevo";
    _modeloLogin.intIdLogin = 100;
    _modeloLogin.intIdUsuario = 1;//sacarlo de la vista
    _modeloLogin.strUsuario = "1";
    _modeloLogin.strContraseña = "1"; 
    MostrarModal();

})

$(document).on("click", ".boton-editar-Login", function () {


    _modeloLogin.idAccion = "Editar";
    var miidLogin = $(this).data("idlogin");
    var miusuario = $(this).data("usuario");
    var micontraseña = $(this).data("contraseña");
    _modeloLogin.intIdLogin = miidLogin;
    _modeloLogin.strUsuario = miusuario;
    _modeloLogin.strContraseña = micontraseña;
    $("#txtUsuarioLogin").val(_modeloLogin.strUsuario);
    $("#txtContraseñaLogin").val(_modeloLogin.strContraseña);
    MostrarModal();
     
})

$(document).on("click", ".boton-eliminar-Login", function () {


    var idLogin = $(this).data("idlogin");
    var usuario= $(this).data("usuario");
    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar Usuario "${usuario}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch(`/Login/Eliminar?idLogin=${idLogin}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Acceso Eliminado", "success");
                        MostrarNotas();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

    _modeloLogin.idAccion = "";

})

 

 
$(document).on("click", ".boton-guardar-cambios-Login", function () {

    _modeloLogin.strUsuario = $("#txtUsuarioLogin").val();
    _modeloLogin.strContraseña = $("#txtContraseñaLogin").val();

    if (_modeloLogin.idAccion == "Nuevo") {

            fetch("/Login/Insertar", {
                method: "POST",
                headers: { "Content-Type": "application/json; charset=utf-8" },
                body: JSON.stringify(_modeloLogin)
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {//ff

                    if (responseJson.valor) {
                        $("#modalLogin").modal("hide");
                        Swal.fire("Listo!", "Nota fue creada", "success");
                        
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo crear", "error");
                })

        } else {

            fetch("/Login/Editar", {//ff
                method: "PUT",
                headers: { "Content-Type": "application/json; charset=utf-8" },
                body: JSON.stringify(_modeloLogin)
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {//ffff

                    if (responseJson.valor) {
                        $("#modalLogin").modal("hide");
                        Swal.fire("Listo!", "La Nota fue Actualizada", "success");
                        
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
                })

        }

    _modeloLogin.idAccion = "";

    })