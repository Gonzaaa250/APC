window.onload = BuscarRanking();

function BuscarRanking() {
    $("#div-categorias").empty();
    $.ajax({
        url: '../../Ranking/BuscarRanking',
        type: 'GET',
        dataType: "json",
        data: {GeneroParametro: 2},
        success: function (rankingsMostrar) {


            $("#div-categorias").empty();



            $.each(rankingsMostrar, function (Index, ranking) {

                //INSERTAMOS EL NOMBRE DE LA CATEGORIA
                $("#div-categorias").append('<h2 style="text-align: center;">' + ranking.tipo + '°Categoria</h2>');

                var bodyCategoria = '';
                var botones='<button type="button" onclick="EliminarRanking(' + ranking.rankingId  + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';

                //LUEGO DEBEMOS RECORRER CADA JUGADOR DE ESA CATEGORIA 
                $.each(ranking.listadoJugadores, function (Index, jugador) {
                    bodyCategoria += '<tr>'
                        + '<td class="lt">' + jugador.nombre + '</td>'
                        + '<td class="lt">' + jugador.clubNombre + '</td>'
                        + '<td class="lt">' + jugador.puntos + '</td>'+
                        '<td class="lt">' + botones + '</td>'+'</tr>';

                });

                $("#div-categorias").append('<table class="table table-dark table-bordered table-striped">' +
                    '<thead>' +
                    '<tr>' +
                    '<th scope="col" class="lt">Nombre</th>' +
                    '<th scope="col" class="lt">Club</th>' +
                    '<th scope="col" class="lt">Puntos</th>' +
                    '<th scope="col" class="lt"></th>'+
                    '</tr>' +
                    '</thead>' +
                    '<tbody>' +
                    bodyCategoria +
                    '</tbody>' +
                    '</table>');

            });

        },
        error: function (xhr, status) {
            alert('Error al actualizar el ranking');
        },
    });
}
function VaciarFormulario() {

    $("#RankingId").val(0);
    $("#UsuarioId").val(0);
    $("#ClubNombreJugador").val('');
    $("#CategoriaNombreJugador").val('');
    $("#Puntos").val(0);

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

function BuscarInfoUsuario() {
    var usuarioId = $("#UsuarioId").val();
    $.ajax({
        url: '../../Usuario/BuscarUsuario',
        data: { UsuarioId: usuarioId },
        type: 'GET',
        dataType: "json",
        success: function (usuarios) {
            $("#ClubNombreJugador").val('');
            $("#CategoriaNombreJugador").val('');

            if (usuarios.length == 1) {
                let usuario = usuarios[0];
                $("#ClubNombreJugador").val(usuario.clubNombre);
                $("#CategoriaNombreJugador").val(usuario.categoriaNombre);
            }
        },
        error: function (xhr, status) {
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
// ELIMINAR RANKING
function EliminarRanking(RankingId, Eliminado) {
    Swal.fire({
        title: '¿Seguro de vaciar los puntos?',
        text: 'No podrás revertir esto!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, Vaciar',
        cancelButtonText: 'No, Cancelar'
    })
    .then((result) => {
        if (result.isConfirmed) {
            // CORRECCIÓN: Obtener el valor de Puntos antes de la llamada AJAX
            var Puntos = obtenerPuntos(); // Reemplaza obtenerPuntos() con la lógica adecuada para obtener el valor de Puntos
            $.ajax({
                url: '../../Ranking/EliminarRanking',
                data: { RankingId: RankingId, Eliminado: Eliminado, Puntos: Puntos },
                type: 'POST',
                dataType: 'json',
                success: function (resultado) {
                    if (resultado === -1) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'No se puede vaciar los puntos',
                        });
                    } else {
                        BuscarRanking();
                        Swal.fire(
                            'Eliminado',
                            'Su archivo ha sido eliminado',
                            'éxito'
                        );
                    }
                }
            });
        } else if (result.isDismissed) {
            Swal.fire(
                'Cancelado',
                'El vaciado de puntos se canceló',
                'error'
            );
        }
    });
}

// Agrega esta función para obtener el valor de Puntos
function obtenerPuntos() {
    return $("#div-categorias table tbody tr td:nth-child(3)").text();
}

