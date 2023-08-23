$(document).ready(function () {
  $(".info-item .btn").click(function () {
    $(".container").toggleClass("log-in");
  });

  $(".container-form .btn").click(function () {
    $(".container").addClass("active");
  });

  // Registrar
  $("#btn-register").click(function (e) {
    e.preventDefault();
    console.log('entré en la función de registro');
    var email = $("#regemail").val();
    var password = $("#regpass").val();
    var retrypassword = $("#regrtpass").val();
    console.log('valores:', email, password, retrypassword);
    
    if (password === retrypassword) {
      console.log('dentro del if de registro');
      var formData = {
        email: email,
        password: password
      };
      
      console.log("data", formData);
      $.ajax({
        url: '../../Account/Register',
        method: 'POST',
        data: formData,
        success: function (data) {
          if (data) {
            alert('Registrado correctamente');
          } else {
            alert('Error al registrarse: ' + data.errors.join(','));
          }
        },
        error: function (error) {
          console.log(error);
        }
      });
    }
  });

  // Iniciar Sesión
  $("#btn-login").click(function (e) {
    e.preventDefault();
    console.log('entré en la función de inicio de sesión');
    var email = $("#loginF input[name='email']").val();
    var password = $("#loginF input[name='password']").val();
    var formData = {
      email: email,
      password: password
    };
    console.log('data', formData);

    $.ajax({
      url: '../../Account/Login',
      method: 'POST',
      contentType: 'application/x-www-form-urlencoded',
      data: formData,
      success: function (data) {
        if (data) {
          alert('Inicio de sesión exitoso');
        } else {
          alert('Error al iniciar sesión');
        }
      },
      error: function (error) {
        console.log(error);
      }
    });
  });
});
