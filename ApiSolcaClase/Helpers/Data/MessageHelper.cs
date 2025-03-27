namespace ApiSolcaClase.Helpers.Data
{
    public class MessageHelper
    {
        public static string ErrorGeneral = "Ocurrio un error interno";
        public static string ErrorPasswordEncrypt = "Ocurrio un error al encriptar los datos";
        public static string ErrorPasswordDesencrypt = "Ocurrio un error al desencriptar los datos";

        public static string ProductNotFound = "El producto seleccionado no existe";

        public static string CredentialsNotMach = "Las contraseñas no coinciden entre sí";
        public static string CredentialsNotStrong = "La contraseña no es segura debe tener letras, numeros y caracteres especiales";
        public static string AuthenticationFailed = "El usuario y/o contraseña no son correctos";
        public static string UserExistAndNotCreated = "Los datos del usuario ya existen, no se puede crear con la misma información";
        public static string UserCreated = "El usuario ha sido creado correctamente";
        public static string UserErrorCreated = "Ocurrio un error al crear el usuario";
        public static string UserUpdateName = "El nombre del usuario se ha cambiado correctamente";

        public static string NotAuthorized = "Session no authorizada";

        public static string ErrorParamsGeneral = "Uno de los parametros es incorrecto";
    }
}
