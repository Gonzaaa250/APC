
  $(".info-item .btn").click(function () {
    $(".container").toggleClass("log-in");
  });

  $(".container-form .btn").click(function () {
    $(".container").addClass("active");
  });

  // Registrar
  $("#btn-register").click(function (e) {
    e.preventDefault();

    // Mostrar el loader
    $(".loader").show();

    var email = $("#regemail").val();
    var password = $("#regpass").val();
    var retrypassword = $("#regrtpass").val();

    if (password === retrypassword) {
      var formData = {
        email: email,
        password: password,
      };

      $.ajax({
        url: '../../Account/Register',
        method: 'POST',
        data: formData,
        success: function (data) {
          if (data) {
            window.location.href = "/Usuario";
          } else {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Error al registrarse',
            });
          }
        },
        error: function (error) {
          alert('Ocurrió un error');
          console.log(error);
        },
        complete: function () {
          // Ocultar el loader una vez que se complete la solicitud (ya sea éxito o error)
          $(".loader").hide();
        }
      });
    } else {
      // Ocultar el loader si la contraseña no coincide
      $(".loader").hide();
    }
});
  // Iniciar Sesión
  function IniciarSesion() {
    // Ocultar el botón de iniciar sesión
    $(".btn").css("display", "none");
    
    // Mostrar el loader
    $(".loader").css("display", "block");
  
    var email = $("#logemail").val();
    var password = $("#logpass").val();
    var formData = {
      email: email,
      password: password
    };
    $.ajax({
      url: '../../Account/Login',
      method: 'POST',
      data: formData,
      success: function (data) {
        if (data.success) {
          // Redirigir a la página de inicio de sesión exitoso
          window.location.href = "/";
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error al iniciar sesión',
          });
        }
      },
      error: function (error) {
        console.log(error);
      }
    });
  }
  