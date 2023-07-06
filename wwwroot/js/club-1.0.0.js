window.onload = BuscarClub();

 function BuscarClub(){
    $("#tbody-club").empty();
     $.ajax({
         // URL para la peticion
         url:'../../Club/BuscarClub',
         // la información a enviar
         // (también es posible utilizar una cadena de datos)
         data:{},
          // especifica si será una petición POST o GET
          type: 'GET',
          // el tipo de información que se espera de respuesta
          dataType: 'json',
          // código a ejecutar si la petición es satisfactoria;
          // la respuesta es pasada como argumento a la función
          success: function(club) {
             $("#tbody-club").empty();
             $.each(club, function (Index, club){
                 //VARIABLES PARA DEFINIR BOTONES Y ESTETICA
                 let BotonDesahabilitar ='';
                 let botones= '<button type="button" onclick="BuscarClub(' + club.ClubId +') class="btn btn-primary btn-sm" style="margin-right:5px" onkeyup="this.value = this.value.toUpperCase()">Editar</button>'+
                 '<button type="button" onclick="EliminarClub(' + club.ClubId +',1)" class="btn btn-danger btn-sm">Desahabilitar</button>';
                 //DEFINE SI ESTA ELIMINADA
                if (club.Estado == 'E') {
                     BotonDesahabilitar= 'table-danger';
                     botones= '<button type="button" onclick="EliminarClub('+ club.ClubId +',0)" class="btn btn-warning btn sm">Activar</button>';
                 }
                 $("#tbody-club").append('<tr class='+ BotonEliminar+'>'+ '<td>'+ club.nombre+'</td>'+ '<td class="text-center">'+ botones + '</td>' + '</tr>');
             })
          },
        
        
        
          // código a ejecutar si la petición falla;
         // son pasados como argumentos a la función
         // el objeto de la petición en crudo y código de estatus de la petición
         error: function (xhr, status) {
             alert('Error al cargar club');
         },

         // código a ejecutar sin importar si la petición falló o no
        complete: function (xhr, status) {
            alert('Petición realizada');
        }
     })
    

 }
 function VaciarFormulario() {
     $("#Nombre").val('');
     $("#ClubId").val(0);
 }

 function GuardarClub(){
     //JAVASCRIP
      let Nombre = document.getElementById("Nombre").value;
      let Direccion = $("#Direccion").val();
      let ClubId = $("#ClubId").val();
    console.log(Nombre);
    console.log(Direccion);
    console.log(ClubId);
    $.ajax({
        // URL para la peticion
         url:'../../Club/GuardarClub',
         // la información a enviar
         // (también es posible utilizar una cadena de datos)
         data:{ClubId: ClubId, Nombre: Nombre, Direccion: Direccion}, 
         // especifica si será una petición POST o GET
         type: 'POST',
         // el tipo de información que se espera de respuesta
         dataType: 'json',
          // código a ejecutar si la petición es satisfactoria;
          // la respuesta es pasada como argumento a la función
         success: function(resultado){
             if(resultado){
                $("ModalClub").modal("hide");
                 BuscarClub();
             }
             else{
                 alert("Ya existe el club");
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
 function EliminarClub( ClubId, Eliminado){
     $.ajax({
         // URL para la peticion
         url:'../../Club/EliminarClub',
         // la información a enviar
         // (también es posible utilizar una cadena de datos)
         data:{ClubId: ClubId, Eliminado: Eliminado},
         // especifica si será una petición POST o GET
         type: 'POST',
         // el tipo de información que se espera de respuesta
         dataType: 'json',
         // código a ejecutar si la petición es satisfactoria;
         // la respuesta es pasada como argumento a la función
         success: function(resultado){
             if(resultado){
                 BuscarClub();
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