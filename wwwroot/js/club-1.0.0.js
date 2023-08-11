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
                var BotonEliminar = '';
                var botones = '<button type="button" onclick="BuscarClub(' + club.clubId + ')" class="button-81" role="button"><img src="../css/img/lapiz.png" alt=""></button>' +
                    '<button type="button" onclick="EliminarClub(' + club.clubId + ', 1)" class="button-82" role="button"><img src="../css/img/tachito.png" alt=""></button>';

                if (club.eliminado) {
                    BotonEliminar = 'table-danger';
                    botones = '<button type="button" onclick="EliminarClub(' + club.clubId + ', 0)" class="button-87" role="button">Activar</button>';
                }

                $("#tbody-club").append('<tr class="' + BotonEliminar + '">' 
                + '<td class="text-center lt">' + club.nombre + '</td>' 
                + '<td class="text-center lt">' + club.localidad + '</td>' + 
                '<td class="text-center">' + botones + '</td>' + '</tr>');
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
}

function GuardarClub() {
    let ClubId = $("#ClubId").val();
    let Nombre = $("#Nombre").val();
    let Localidad = $("#Localidad").val();
    $.ajax({
        url: '../../Club/GuardarClub',
        data: { ClubId: ClubId, Nombre: Nombre, Localidad: Localidad },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if (resultado) {
                $("#ModalClub").modal("hide");
                BuscarClub();
            } else {
                alert("Ya existe el club");
            }
        },
        error: function (xhr, status) {
            alert('No se pudo guardar el club');
        }
    });
}

function EliminarClub(ClubId, Eliminado) {

    $.ajax({
        url: '../../Club/EliminarClub',
        data: { ClubId: ClubId, Eliminado: Eliminado },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            if (resultado) {
                BuscarClub();
                console.log("Club eliminado correctamente");
            }
        },
        error: function (xhr, status) {;
            alert('No se pudo eliminar el club');
        }
    });
}
