
$(".info-item .btn").click(function () {
  $(".container").toggleClass("log-in");
});
$(".container-form .btn").click(function () {
  $(".container").addClass("active");
});
//registrar
let btn_register = $("#btn-register");
btn_register.click(function (e) {
  e.preventDefault();
  console.log('entre en la funcion');
  var email = $("#registerF input[name='email']").val();
  var password = $("#registerF inpunt[name='password']").val();
  let retrypassword = $("#registerF input[name='retrypassword']").val();
  console.log('toma los valores', email, password, retrypassword);
  if (password == retrypassword) {
    console.log('dentro de if');
    var formData = {
      email: email,
      password: password
    }
  }
  console.log("data", formData)
  $.ajax({
    // la URL para la petición
    url: '/Account/Register',
    // la información a enviar
    // (también es posible utilizar una cadena de datos)
    contentType: 'application/x-www-form-urlencoded',
    // especifica si será una petición POST o GET
    method: 'Post',
    data: formData,
    // código a ejecutar si la petición es satisfactoria;
    // la respuesta es pasada como argumento a la función
    success: function (data) {
      if (data) {
        alert('Registrado correctamente');
      }
      else {
        alert('Error al registrarse:' + data.errors.join(','));
      }
    },
    //   error:function (xhr, status){}
    error: function (error) {
      // Manejar errores de la solicitud
      console.log(error);
    }
  })
//Iniciar Sesion
let btn_login=$("#btn-login");
btn_login.click(function(e){
  e.preventDefault();
  console.log('entre en la funcion');
  var email=$("#loginF input[name='email']").val();
  var password=$("#loginF input[name='password']").val();
  console.log('toma los valores', email, password)
  var formData={
    email: email,
    password: password
  }
console.log('data',formData)
$.ajax({
  url:'/Account/Login',
  method: 'Post',
  contentType: 'application/x-www-form-urlencoded',
  data:formData,
  success: function (data) {
    if (data) {
      alert('Registrado correctamente');
    }
    else {
      alert('Error al registrarse:' + data.errors.join(','));
    }
  },
  error: function(error){
    console.log(error)
  }
})
})
})