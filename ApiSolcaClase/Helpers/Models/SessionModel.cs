namespace ApiSolcaClase.Helpers.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public SessionModel(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }
    }
}
