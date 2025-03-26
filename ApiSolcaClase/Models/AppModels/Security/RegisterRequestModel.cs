namespace ApiSolcaClase.Models.AppModels.Security
{
    public class RegisterRequestModel
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public string PassR { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
    }
}
