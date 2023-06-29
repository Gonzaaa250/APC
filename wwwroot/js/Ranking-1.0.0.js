window.onload = BuscarJugador();

function BuscarJugador(){
    $("#tbody-jugador").empty();
    $.ajax({
         // URL para la peticion
         url:'../../Jugadores/BuscarJugador',
         // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data:{},
         // especifica si será una petición POST o GET
         type: 'GET',
         // el tipo de información que se espera de respuesta
         dataType: 'json',
         // código a ejecutar si la petición es satisfactoria;
         // la respuesta es pasada como argumento a la función
         success: function(jugador){
            $("#tbody-jugador").empty();
            $.each(jugador, function (Index, jugador){
                //VARIABLES PARA DEFINIR BOTONES Y ESTETICA
                let BotonDesahabilitar ='';
                let botones= '<button type="button" onclick="Buscarjugador(' + jugador.jugadorId +')" class="btn btn-primary btn-sm" style="margin-right:5px" onkeyup="this.value = this.value.toUpperCase()">Editar</button>'+
                '<button type="button" onclick="Eliminarjugador(' + jugador.jugadorId +',1)" class="btn btn-danger btn-sm">Desahabilitar</button>';
                //DEFINE SI ESTA ELIMINADA
                if (jugador.Estado == 'E') {
                    BotonDesahabilitar= 'table-danger';
                    botones= '<button type="button" onclick="Eliminarjugador('+ jugador.jugadorId +',0)" class="btn btn-warning btn sm">Activar</button>';
                }
                $("#tbody-jugador").append('<tr class='+ BotonEliminar+'>'+ '<td>'+ jugador.nombre+'</td>'+ '<td class="text-center">'+ botones + '</td>' + '</tr>');
            })
         },
          // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            alert('Error al cargar jugador');
        },

        // código a ejecutar sin importar si la petición falló o no
        complete: function (xhr, status) {
            //alert('Petición realizada');
        }
         
    })
}
function VaciarFormulario() {
    $("#Nombre").val('');
    $("JugadorId").val(0);
}
function BuscarJugador(JugadorId){
    $.ajax({
        // la URL para la petición
        url: '../../Jugadores/BuscarJugador',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data: { JugadorId: JugadorId },
        // especifica si será una petición POST o GET
        type: 'GET',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function (jugador) {

            if (jugador.length == 1) {
                let jugador = jugador[0];
                $("#Nombre").val(jugador.nombre);
                $("#JugadorId").val(jugador.JugadorId);

                $("#ModalJugadores").modal("show");
            }
        },

        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            alert('Error al cargar jugador');
        },

        // código a ejecutar sin importar si la petición falló o no
        complete: function (xhr, status) {
            //alert('Petición realizada');
        }
    });
}
function GuardarJugador(){
    //JAVASCRIP
    // let descripcion1 = document.getElementById("Descripcion").value;
    // let descripcion2 = $("#Descripcion").val();
    // let categoriaID = $("#CategoriaID").val();
    $.ajax({
        // URL para la peticion
        url:'../../Jugadores/GuardarJugador',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data:{JugadorId: JugadorId}, //<=VER
        // especifica si será una petición POST o GET
        type: 'POST',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function(resultado){
            if(resultado){
                $("ModalJugador").modal("hide");
                BuscarJugador();
            }
            else{
                alert("Ya existe el jugador");
            }
        },

        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            alert('surgio un problema');
        }
    })
}
function Eliminarjugador( JugadorId, Eliminado){
    $.ajax({
        // URL para la peticion
        url:'../../Jugadores/EliminarJugador',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data:{JugadorId: JugadorId, Eliminado: Eliminado},
        // especifica si será una petición POST o GET
        type: 'POST',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function(resultado){
            if(resultado){
                BuscarJugador();
            }
        },

        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            alert('surgio un problema');
        }
    })
}