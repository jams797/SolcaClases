namespace ApiSolcaClase.Models.AppModels.Security
{
    public class UserModelDB
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserModelDB(int id, string userName, string passWord, string name, string email)
        {
            Id = id;
            UserName = userName;
            PassWord = passWord;
            Name = name;
            Email = email;
        }
    }
}
