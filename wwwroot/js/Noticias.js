function GuardarNoticia() {
    let form = $("form#NoticiaDatos");
    var formData = new FormData(form[0]);
    console.log(formData)
    // $.ajax({
    //     url: '../../Noticia/GuardarNoticia',
    //     type: 'POST',
    //     data: formData,
    //     async: false,
    //     success: function (resultado) {
    //         if (resultado) {
    //             console.log(resultado);

    //         }
    //         else {
    //             console.log(resultado);
    //         }
    //     },
    //     cache: false,
    //     contentType: false,
    //     processData: false
    // });
}