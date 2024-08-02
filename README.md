La aplicación se desarrollo en .net 8 con base de datos sql 2022, la aplicación tiene el Docker file y Docker compose necesarios para trabajarse en contenedor.

Para poner en funcionamiento la aplicación se debe modificar la connectionString de la base de datos en el archivo appsetting

Para el envio de correo electrónico con la confirmación de la reserva se deben modificar los valores de "your-email-address@gmail.com", "your-email-password" por un correo electrónico y una contraseña con las que se deseen hacer las pruebas, preferiblemente de Microsoft ya que es el cliente smtp que se tiene configurado.

La aplicación permite la creación de usuarios para posterior autenticación, algunos de los métodos están restringidos por lo cual se debe crear un usuario y posteriormente autenticarse para obtener un token con el que se puedan probar los servicios.
