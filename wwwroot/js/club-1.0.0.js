window.onload = BuscarClub();

function BuscarClub() {
    $("#tbody-club").empty();
    $.ajax({
        url: '../../Club/BuscarClub',
        type: 'GET',
        dataType: 'json',
        success: function (club) {
            $("#tbody-club").empty();
            $.each(club, function (Index, club) {
                var BotonEliminar = '';
                var botones = '<button type="button" onclick="BuscarClub(' + club.ClubId + ')" class="btn btn-primary btn-sm" style="margin-right:5px" onkeyup="this.value = this.value.toUpperCase()">Editar</button>' +
                    '<button type="button" onclick="EliminarClub(' + club.ClubId + ', 1)" class="btn btn-danger btn-sm">Eliminar</button>';

                if (club.Estado == 'E') {
                    BotonEliminar = 'table-danger';
                    botones = '<button type="button" onclick="EliminarClub(' + club.ClubId + ', 0)" class="btn btn-warning btn-sm">Activar</button>';
                }

                $("#tbody-club").append('<tr class="' + BotonEliminar + '">' + '<td>' + club.Nombre + '</td>' + '<td class="text-center">' + botones + '</td>' + '</tr>');
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
    console.log("ClubId:", ClubId);
    console.log("Eliminado:", Eliminado);

    $.ajax({
        url: '../../Club/EliminarClub',
        data: { ClubId: ClubId, Eliminado: Eliminado },
        type: 'POST',
        dataType: 'json',
        success: function (resultado) {
            console.log("Resultado:", resultado);
            if (resultado) {
                console.log("Club eliminado correctamente");
                BuscarClub();
            }
        },
        error: function (xhr, status) {
            console.log("Error al eliminar el club");
            alert('No se pudo eliminar el club');
        }
    });
}
