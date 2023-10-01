window.onload = BuscarClub();

function BuscarClub() {
    $("#tbody-club").empty();
    $.ajax({
        url: '../../Club/BuscarClub',
        type: 'GET',
        dataType: 'json',
        success: function (clubes) {
            $("#tbody-club").empty();
            $.each(clubes, function (Index, club) {
                //console.log(club);
                var BotonEliminar = '';
                var botones = '<button type="button" onclick="BuscarClubes(' + club.clubId + ')" class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                    '<button type="button" onclick="EliminarClub(' + club.clubId + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';

                if (club.eliminado) {
                    BotonEliminar = 'table-danger';
                    botones = '<button type="button" onclick="EliminarClub(' + club.clubId + ', 0)" class="button-87" role="button">Activar</button>';
                }
                var imagen = '<td></td>';
                if (club.imagenBase64) {
                    //console.log(club.tipoImagen + "---" + club.imagenBase64);
                    imagen = '<td><img src="data:' + club.tipoImagen + ';base64,' + club.imagenBase64 + '" style="width: 100px;"/></td>';
                    //src='data:image/jpeg;base64, LzlqLzRBQ..
                }

                $("#tbody-club").append('<tr class="' + BotonEliminar + '">'
                    + '<td class="text-center lt">' + club.nombre + '</td>'
                    + '<td class="text-center lt">' + club.localidad + '</td>'
                    + imagen
                    + '<td class="text-center">' + botones + '</td>' +
                    '</tr>');

            });
        },
        error: function (xhr, status) {
            alert('Error al cargar los clubes');
        },
    });
}

function VaciarFormulario() {
    $("#Nombre").val('');
    $("#ClubId").val(0);
    $("#Localidad").val("");
    $("#Imagen").val("");
}
// EDITAR CLUB
function BuscarClubes(ClubId) {
    $.ajax({
        url: '../../Club/BuscarClub',
        data: { ClubId: ClubId },
        type: 'GET',
        dataType: "json",
        success: function (clubes) {
            if (clubes.length == 1) {
                let club = clubes[0];
                $("#Nombre").val(club.nombre);
                $("#Localidad").val(club.localidad);
                $("#ClubId").val(club.clubId);
                $("#ImagenBase64").val(club.imagenBase64);

                $("#ModalClub").modal("show");
            }
        },
        error: function (xhr, status) {
            alert("Error al editar el club")
        }
    });
}
/*GUARDAR CLUB*/
function GuardarClub() {
    //console.log("llegue");
    $("#texto-error").text("");
    let form = $("form#files");
    var formData = new FormData(form[0]);
    //console.log(form[0]);
    $.ajax({
        url: '../../Club/GuardarCLub',
        type: 'POST',
        data: formData,
        async: false,
        success: function (resultado) {
            if (resultado) {
                console.log(resultado);
                $("#ModalClub").modal("hide");
                BuscarClub();
            }
            else {
                console.log(resultado);
                $("#texto-error").text("Ya existe ese club");
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

/*Eliminar CLUB*/
function EliminarClub(ClubId, Eliminado) {

    $.ajax({
        url: '../../Club/EliminarClub',
        data: { ClubId: ClubId, Eliminado: Eliminado },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if(resultado = -1){
                alert("No se puede eliminar este club porque hay un jugador asociado a este")
            }
            if (resultado) {
                BuscarClub();
                console.log("Club eliminado correctamente");
                alert("Club eliminado");
            }
        },
        error: function (xhr, status) {
            alert('No se pudo eliminar el club');
        }
    });
}
