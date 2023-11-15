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
                var botones= '<button type="button" onclick="BuscarCategorias(' + categoria.categoriaId + ')" class="button-81" role="button" title="Editar"><img src="../css/img/lapiz.png" alt=""></button>' +
                '<button type="button" onclick="EliminarCategoria(' + categoria.categoriaId  + ', 1)" class="button-82" role="button" title="Eliminar"><img src="../css/img/tachito.png" alt=""></button>';                
            $("#tbody-categoria").append('<tr class="' + BotonEliminar + '">'
            + '<td class="text-center lt">' + categoria.tipo + '</td>'
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
function BuscarCategorias(CategoriaId)
{
    $.ajax({
        url:'../../Categoria/BuscarCategoria',
        data: {CategoriaId: CategoriaId},
        type: 'GET',
        dataType: 'json',
        success: function(categorias){
            if(categorias.length ==1){
                let categoria = categorias[0];
                $("#CategoriaId").val(categoria.categoriaId);
                $("#Tipo").val(categoria.tipo);

                $("#ModalCategoria").modal("show");
            }
        },
        error: function(xhr, status){
            alert('Error al editar')
        }
    });
}
//GUARDAR
function GuardarCategoria(){
    let Tipo=$("#Tipo").val();
    let CategoriaId =$("#CategoriaId").val();
    $.ajax({
        url:'../../Categoria/GuardarCategoria',
        data:{CategoriaId: CategoriaId, Tipo: Tipo},
        type:"POST",
        dataType: 'json',
        success: function(resultado){
            // console.log('LLEGUE');
            if(resultado){
                $("#ModalCategoria").modal("hide");
                BuscarCategoria();
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
    Swal.fire({
        title: '¿Seguro de eliminar esta categoria?',
        text: 'No podrás revertir esto!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, Eliminar',
        cancelButtonText: 'No, Cancelar' // Agregamos el botón "Cancelar"
    })
    .then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '../../Categoria/EliminarCategoria',
                data: { CategoriaId: CategoriaId, Eliminado: Eliminado },
                type: 'POST',
                dataType: 'json',
                success: function (resultado) {
                    if (resultado === -1) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'No se puede eliminar esta categoria porque hay un jugador asociado a este',
                        });
                    } else {
                        BuscarCategoria();
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
                'La eliminación de la categoria ha sido cancelada',
                'error'
            );
        }
     });

}
