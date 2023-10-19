window.onload = BuscarRanking();

function BuscarRanking() {
    $("#tbody-ranking").empty();
    $.ajax({
        url: '../../Ranking/BuscarRanking',
        type: 'GET',
        dataType: "json",
        success: function (rankings) {
            $("#tbody-ranking").empty();
            $.each(rankings, function (Index, ranking) {
                var BotonEliminar = "";
                var botones = 'button type="button" onclick="BuscarRankings(' + ranking.rankingId + ') class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                    '<button type="button" onclick="EliminarRanking(' + ranking.rankingId + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';
                // if(usuario.eliminado){
                //     BotonEliminar= 'table-danger';
                //     botones = '<button type="button" onclick="EliminarUsuario(' + usuario.rankingId + ', 1)" class="button-87" role="button">Activar</button>';
                // }
                $("#tbody-ranking").append('<tr class="' + BotonEliminar + '">'
                    + '<td class="text-center lt>' + ranking.nombre + '</td>'
                    + '<td class="text-center lt>' + ranking.localidad + '</td>'
                    + '<td class="text-center lt>' + ranking.club + '</td>'
                    + '<td class="text-center lt">' + ranking.puntos + '</td>'
                    + '<td class="text-center>' + botones + '</td>' + '</tr>');
            });
        },
        error: function (xhr, status) {
            alert('Error al actualizar el ranking');
        },
    });
}
function VaciarFormulario() {
    $("#Nombre").val('');
    $("#RankingId").val(0);
    $("#Localidad").val("");
    $("#Club").val("");
    $("#Puntos").val("");
    $("#Categoria").val("");
}
function BuscarRankings(rankingId) {
    $.ajax({
        url: '../../Ranking/BuscarRanking',
        data: { RankingId: rankingId },
        type: 'GET',
        dataType: "json",
        success: function (ranking) {
            console.log("entra");
            if (ranking.length == 1) {
                let ranking = ranking[0];
                $('#Nombre').val(ranking.nombre);
                $('#RankingId').val(ranking.rankingId);
                $('#Localidad').val(ranking.localidad);
                $('#Club').val(ranking.club);
                $('#Puntos').val(ranking.puntos);
                $('#Categoria').val(ranking.categoria);

                $('#ModalRanking').modal('show')
            }
        },
        error: function (xhr, status) {
            alert('Error al editar')
        }
    });
}

$("#UsuarioId").change(function () {
    BuscarInfoUsuario();
});

function BuscarInfoUsuario(){
var usuarioId = $("#UsuarioId").val();
    $.ajax({
        url:'../../Usuario/BuscarUsuario',
        data: {UsuarioId: usuarioId},
        type: 'GET',
        dataType:"json",
        success: function(usuarios)
        {
            if(usuarios.length ==1){
                let usuario = usuarios[0];            
                $("#ClubNombreJugador").val(usuario.clubNombre);             
                $("#CategoriaNombreJugador").val(usuario.categoriaNombre);               
            }
        },
        error: function(xhr, status){
            alert('Error al buscar informacion del jugador');
        }
    });
    }


//GUARDAR RANKING
function GuardarRanking() {
    let rankingId = $("#RankingId").val();
    var usuarioId = $("#UsuarioId").val();
    let puntos = $("#Puntos").val();
    $.ajax({
        url: '../../Ranking/GuardarRanking',
        data: { RankingId: rankingId, UsuarioId: usuarioId, Puntos: puntos },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if (resultado) {
                $("#ModalRanking").modal("hide");
                BuscarRanking();
               
            }
            else {
                alert('No se pudo guardar');
            }
        },
        error: function (xhr, status) {
            alert('Ocurrio un error');
        }
    })
}

//ELIMINAR RANKING
function EliminarRanking(RankingId, Eliminado) {
    $.ajax({
        url: '../../Ranking/EliminarRanking',
        data: { RankingId: RankingId, Eliminado: Eliminado },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if (!resultado) {
                BuscarRanking();
                console.log("Eliminado")
            }
        },
        error: function (xhr, status) {
            alert('Error al eliminar')
        }
    });
}
//Modal
// function obtenerInformacionUsuario() {
//     var usuarioId = $("#UsuarioId").val();

//     $.ajax({
//         url: "../../Ranking/ObtenerInformacionUsuario", // Reemplaza con tu endpoint real
//         type: "GET",
//         data: { usuarioId: usuarioId },
//         success: function(data) {
//             // Actualiza los campos del modal con la información recibida
//             $("#Club").val(data.clubId); // Asigna el valor del club al campo
//             $("#CategoriaId").val(data.categoriaId); // Asigna el valor de la categoría al campo
//         },
//         error: function() {
//             alert("Error al obtener la información del usuario.");
//         }
//     });
// }
