namespace ApiSolcaClase.Helpers.Models
{
    public class GeneratorJWTReponseModel
    {
        public bool isOk { get; set; }
        public string data { get; set; }
        public string error { get; set; }

        public GeneratorJWTReponseModel(bool isOk, string data, string error)
        {
            this.isOk = isOk;
            this.data = data;
            this.error = error;
        }
    }
}
