namespace ApiSolcaClase.Helpers.Data
{
    public class MessageHelper
    {
        public static string ErrorGeneral = "Ocurrio un error interno";
        public static string ErrorPasswordEncrypt = "Ocurrio un error al encriptar los datos";
        public static string ErrorPasswordDesencrypt = "Ocurrio un error al desencriptar los datos";

        public static string CredentialsNotMach = "Las contraseñas no coinciden entre sí";
        public static string CredentialsNotStrong = "La contraseña no es segura debe tener letras, numeros y caracteres especiales";
        public static string AuthenticationFailed = "El usuario y/o contraseña no son correctos";

        public static string ErrorParamsGeneral = "Uno de los parametros es incorrecto";
    }
}
