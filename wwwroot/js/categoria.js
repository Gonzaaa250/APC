window.onload = BuscarCategoria();
function BuscarCategoria(){
    $("#tbody-categoria").empty();
    $.ajax({
        url:'../../Categoria/BuscarCategoria',
        type: 'GET',
        dataType: 'json',
        success: function(categorias){
            $("#tbody-categoria").empty();
            $.each(categorias, function(index, categoria){
                var BotonEliminar ="";
                var botones= '<button type="button" onclick="EditarCategoria(' + categoria.categoriaId + ')" class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                '<button type="button" onclick="EliminarCategoria(' + categoria.categoriaId  + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';                
            $("#tbody-categoria").append('<tr class="' + BotonEliminar + '">'
            + '<td class="text-center lt">' + usuario.nombre + '</td>'
            + '<td class="text-center">' + botones + '</td>' + '</tr>');
            })
        },
        error : function (xhr, status){
            alert('Error al cargar');
        }, 
    });
}
function VaciarFormulario(){
    $("#CategoriaId").val(0);
    $("#Tipo").val('');
}
//EDITAR
function EditarCategoria(CategoriaId)
{
    $.ajax({
        url:'../../Categoria/BuscarCategoria',
        data: {CategoriaId: CategoriaId},
        type: 'GET',
        dataType: 'json',
        success: function(categorias){
            if(categorias.length ==1){
                let categoria = categorias[0];
                $("#Tipo").val(categoria.tipo);

                $("#ModalCategoria").modal("show");
            }
        },
        error: function(xhr, status){alert('Error al editar')}
    });
}
//GUARDAR
function GuardarCategoria(){
    let Tipo=$("#Tipo").val();
    let CategoriaId =$("#CategoriaId").val();
    $.ajax({
        url:'../../Categoria/Guardar',
        data:{CategoriaId: CategoriaId, Tipo: Tipo},
        type:"POST",
        dataType: 'json',
        success: function(resultado){
            if(resultado){
                $("#ModalCategoria").modal("hide");
                BuscarCategoria();
                alert('guardado exitosamente');
            }
            else{
                alert('ya existe la categoria')
            }
        },
        error: function(xhr, status){
            alert('Ocurrio un error')
        }
    });
} 
function EliminarCategoria(CategoriaId, Eliminado)
{
    $.ajax({
        url: '../../Categoria/EliminarCategoria',
        data : {'CategoriaId': CategoriaId,'Eliminado' : Eliminado},
        type:'POST',
        dataType: 'json',
        success: function (resultado) {
            if(resultado = -1){
                alert("No se puede eliminar esta categoria porque hay un jugador asociado a este")
            }
            if (resultado) {
                BuscarClub();
                alert("Categoria eliminado");
            }
        },
        error: function (xhr, status) {
            alert('No se pudo eliminar la categoria');
        }
    });
}