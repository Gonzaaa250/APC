window.onload = BuscarRankings();

function BuscarRankings(){
$("#tbody-ranking").empty();
$.ajax({
    url: '../../Ranking/BuscarRanking',
    type:'GET',
    dataType:"json",
    success : function(rankings){
        $("#tbody-ranking").empty();
        $.each(rankings, function(Index, ranking){
            var BotonEliminar ="";
            var botones = 'button type="button" onclick="BuscarRanking(' + ranking.rankingId + ') class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
            '<button type="button" onclick="EliminarRanking(' + ranking.rankingId + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';
            // if(usuario.eliminado){
            //     BotonEliminar= 'table-danger';
            //     botones = '<button type="button" onclick="EliminarUsuario(' + usuario.usuarioId + ', 1)" class="button-87" role="button">Activar</button>';
            // }
            $("#tbody-ranking").append('<tr class="' + BotonEliminar +'">'
            + '<td class="text-center lt>' +ranking.nombre +'</td>'
            + '<td class="text-center lt>' +ranking.localidad +'</td>'
            + '<td class="text-center lt>' +ranking.club +'</td>'
            +'<td class="text-center lt">'+ ranking.puntos+'</td>'
            + '<td class="text-center>' +botones +'</td>' +'</tr>');
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
}
function BuscarRanking(rankingId){
$.ajax({
    url: '../../Ranking/BuscarRanking',
    data:{RankingId:rankingId},
    type: 'GET',
    dataType :"json",
    success : function(ranking){
        console.log("entra");
        if(ranking.length==1){
            let ranking = ranking[0];
            $('#Nombre').val(ranking.nombre);
            $('#RankingId').val(ranking.rankingId);
            $('#Localidad').val(ranking.localidad);
            $('#Club').val(ranking.club);
            $('#Puntos').val(ranking.puntos);

            $('#ModalRanking').modal('show')
        }
    },
    error: function (xhr, status){
        alert('Error al editar')
    }
});
}
//GUARDAR RANKING
function GuardarRanking(){
    let RankingId = $("#RankingId").val();
    let Nombre = $("#Nombre").val();
    let Localidad= $("#Localidad").val();
    let Club=$("#Club").val();
    let Puntos =$ ("#Puntos").val();
    $.ajax({
        url: '../../Ranking/GuardarRanking',
        data:{RankingId:RankingId , Nombre:Nombre  , Localidad:Localidad   , Club:Club    , Puntos: Puntos},
        type:'POST',
        dataType: 'json',
        success: function (resultado){
            if(resultado){
                $("#ModalRanking").modal("hide");
                BuscarRanking();
            }
            else{
                alert("Error");
            }
        },
            error: function (xhr, status)
            {
                alert("ERROR");
            }
    });
}
//ELIMINAR RANKING
function EliminarRanking(RankingId, Eliminado){
$.ajax({
    url:'../../Ranking/EliminarRanking',
    data:{RankingId:RankingId,Eliminado:Eliminado},
    type: 'POST',
    dataType :'json',
    success: function(resultado)
    {
        if(!resultado)
        {
            BuscarRanking();
            console.log("Eliminado")
        }
    },
    error: function(xhr, status){
        alert('Error al eliminar')
    }
});
} 