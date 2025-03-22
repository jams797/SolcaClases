namespace ApiSolcaClase.Helpers.Models
{
    public class GetDataUserResponseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public GetDataUserResponseModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
