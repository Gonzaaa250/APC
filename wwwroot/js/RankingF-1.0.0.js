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
//GUARDAR RANKING
function GuardarRanking() {
    let RankingId = $("#RankingId").val();
    let Nombre = $("#Nombre").val();
    let Club = $("#Club").val();
    let Puntos = $("#Puntos").val();
    let Categoria = $("#CategoriaId").val();
    let Genero = $("#Genero").val();
    $.ajax({
        url: '../../Ranking/GuardarRanking',
        data: { RankingId: RankingId, Nombre: Nombre, Club: Club, Puntos: Puntos, Categoria: Categoria, Genero: Genero },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if (resultado) {
                if (Categoria === 1) {

                }
                else if (Categoria == 2) {

                }
                else if (Categoria == 3) {

                }
                else if (Categoria === 4) {

                }
                else if (Categoria === 5) { 

                }
                else if (Categoria === 6) { 

                }
                else if (Categoria === 7) { 

                }
                else if (Categoria === 8) { 
                    
                }
                $("#ModalRanking").modal("hide");
                BuscarRanking();
                alert('guardado correctamente')
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
