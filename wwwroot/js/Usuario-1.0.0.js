window.onload= BuscarUsuario();
function BuscarUsuario() {
    $("#tbody-usuario").empty();
    $.ajax({
        url: '../../Usuario/BuscarUsuario',
        type: 'GET',
        dataType: 'json',
        success: function (usuarios) {
            $("#tbody-usuario").empty();
            $.each(usuarios, function (Index, usuario) {
                console.log(usuario);
                var BotonEliminar = '';
                var botones = '<button type="button" onclick="BuscarUsuarios(' + usuario.usuarioId + ')" class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                    '<button type="button" onclick="EliminarUsuario(' + usuario.usuarioId  + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';
                    var NombreC = usuario.club ? usuario.club.nombre :"";                  
                    var generoTexto = "Masculino";
                    if (usuario.genero == 2) {
                        generoTexto = "Femenino";
                    }
                    $("#tbody-usuario").append('<tr class="' + BotonEliminar + '">'
                        + '<td class="text-center lt">' + usuario.nombre + '</td>'
                        + '<td class="text-center lt">' + usuario.localidad + '</td>'
                        + '<td class="text-center lt">' + usuario.telefono + '</td>'
                        + '<td class="text-center lt">' + usuario.dni + '</td>'
                        + '<td class="text-center lt">' + NombreC + '</td>'
                        + '<td class="text-center lt">' + generoTexto + '</td>'
                        + '<td class="text-center lt">' + usuario.categoria + '</td>'
                        + '<td class="text-center">' + botones + '</td>' + '</tr>');
            });
        },
        error: function (xhr, status) {
            alert('Error al cargar usuario');
        },
    });
}

function VaciarFormulario() {
    $("#Nombre").val('');
    $("#UsuarioId").val(0);
    $("#Localidad").val("");
    $("#Telefono").val("");
    $("#DNI").val("");
}
//EDITAR USUARIO
function BuscarUsuarios(usuarioId){
$.ajax({
    url:'../../Usuario/BuscarUsuario',
    data: {UsuarioId: usuarioId},
    type: 'GET',
    dataType:"json",
    success: function(usuarios)
    {
        if(usuarios.length ==1){
            let usuario = usuarios[0];
            $("#Nombre").val(usuario.nombre);
            $("#Localidad").val(usuario.localidad);
            $("#Telefono").val(usuario.telefono);
            $("#DNI").val(usuario.dni);
            $("#Club").val(usuario.club);
            $("#Genero").val(usuario.genero);
            $("#UsuarioId").val(usuario.usuarioId);
            $("#Categoria").val(usuario.categoria)
            $("#ModalUsuario").modal("show");
        }
    },
    error: function(xhr, status){
        alert('Error al editar el usuario')
    }
});
}
//GUARDAR USUARIO
function GuardarUsuario(){
    let UsuarioId = $("#UsuarioId").val();
    let Nombre = $("#Nombre").val();
    let Localidad=$("#Localidad").val();
    let Telefono=$("#Telefono").val();
    let DNI=$("#DNI").val();
    let Genero=$("#Genero").val();
    let ClubId = $("#ClubId").val();
    let Categoria = $("#Categoria").val()
    
    $.ajax({
        url:'../../Usuario/GuardarUsuario',
        data: {UsuarioId: UsuarioId, Nombre: Nombre, Localidad: Localidad, Telefono: Telefono, DNI: DNI, Genero: Genero, ClubId: ClubId, Categoria: Categoria},
        type: 'POST',
        dataType: 'json',
        success: function (resultado){
            if(resultado){
                $("#ModalUsuario").modal("hide");
;
                BuscarUsuario();
                window.location.href="/"
                alert("Guardado Correctamente")
            } else{
                alert("Ya existe el usuario");
            }
        },
        error :  function (xhr, status){
            alert('No se pudo guardar el usuario');
        }
    });
}
// ELIMINAR USUARIO
function EliminarUsuario(UsuarioId, Eliminado){
$.ajax({
    url:'../../Usuario/EliminarUsuario',
    data:{'UsuarioId':UsuarioId, Eliminado:Eliminado},
    type:'POST',
    dataType: 'json',
    success: function(resultado){
        if(!resultado) {
            BuscarUsuario();
            console.log("Usuario Eliminado")
        }
    },
    error: function (xhr, status){
        alert('No se pudo eliminar el Usuario')
    }
});
}