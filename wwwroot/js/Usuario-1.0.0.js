window.onload= BuscarUsuarios();
function BuscarUsuarios(){
    $("#tbody-usuario").empty();
    $.ajax({
        url: '../../Usuario/BuscarUsuario',
        type: 'GET',
        dataType:'json',
        success: function (usuarios){
            $("#tbody-usuario").empty();
            $.each(usuarios, function(Index, usuario){
                var BotonEliminar='';
                var botones = '<button type="button" onclick="BuscarUsuario(' + usuario.usuarioId + ')" class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                        '<button type="button" onclick="EliminarUsuario(' + usuario.usuarioId  + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';
                        // if(usuario.eliminado){
                        //     BotonEliminar= 'table-danger';
                        //     botones = '<button type="button" onclick="EliminarUsuario(' + usuario.usuarioId + ', 1)" class="button-87" role="button">Activar</button>';
                        // }
                        $("#tbody-club").append('<tr class="' + BotonEliminar + '">'
                        + '<td class="text-center lt">' + usuario.nombre + '</td>'
                        + '<td class="text-center lt">'+ usuario.localidad + '</td>' 
                        + '<td class="text-center"' + usuario.edad+'</td>' + '</tr>'
                        + '<td class="text-center"' + usuario.telefono+'</td>' + '</tr>'
                        + '<td class="text-center"' + usuario.dni+'</td>' + '</tr>'
                        + '<td class="text-center"' + usuario.categoria+'</td>' + '</tr>'
                        + '<td class="text-center"' + botones +'</td>' + '</tr>');
            });
        },
        error :  function (xhr, status){
            alert('Error al cargar usuario');
        },
    });
}
function VaciarFormulario() {
    $("#Nombre").val('');
    $("#UsuarioId").val(0);
    $("#Localidad").val("");
    $("#Edad").val("");
    $("#Telefono").val("");
    $("#DNI").val("");
    $("#Categoria").val("");
}
//EDITAR USUARIO
function BuscarUsuario(usuarioId){
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
            $("#Edad").val(usuario.edad);
            $("#Telefono").val(usuario.telefono);
            $("#DNI").val(usuario.dni);
            $("#Categoria").val(usuario.categoria);
            $("#UsuarioId").val(usuario.usuarioId);

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
    let Edad=parseInt($("#Edad").val());
    let Telefono=$("#Telefono").val();
    let DNI=$("#DNI").val();
    let Categoria=$("#Categoria").val();
    $.ajax({
        url:'../../Usuario/GuardarUsuario',
        data: {UsuarioId: UsuarioId, Nombre: Nombre, Localidad: Localidad, Edad: Edad, Telefono: Telefono, DNI: DNI, Categoria: Categoria},
        type: 'POST',
        dataType: 'json',
        success: function (resultado){
            if(resultado){
                $("#ModalUsuario").modal("hide");
                BuscarUsuario();
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