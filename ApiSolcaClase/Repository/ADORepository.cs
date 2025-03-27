using System.Data.Common;

namespace ApiSolcaClase.Repository
{
    public class ADORepository
    {
        public void UtilADO(ref DbCommand cmd)
        {
            try
            {

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
