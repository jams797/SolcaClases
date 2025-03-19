namespace ApiSolcaClase.Helpers.Models
{
    public class DataEncryptModel
    {
        public DataEncryptModel(string key, string iv)
        {
            this.key = key;
            this.iv = iv;
        }

        public string key { get; set; }
        public string iv { get; set; }
    }
}
