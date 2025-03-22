namespace ApiSolcaClase.Helpers.Models
{
    public class SessionModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public SessionModel(string id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
