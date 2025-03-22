using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Models.AppModels.WeatherForecast;

namespace ApiSolcaClase.Validator.Security
{
    public class UserValidate
    {

        ValidateHelper ValidH;

        public UserValidate()
        {
            ValidH = new ValidateHelper();
        }

        public ResponseModelGeneral Login(LoginRequestModel ReqModel)
        {

            ResponseModelGeneral ValUser = ValidH.ValidResp(ReqModel.User, "User", 12, 4);
            if (ValUser.code != 200) return ValUser;
            ResponseModelGeneral ValPass = ValidH.ValidResp(ReqModel.Pass, "Pass", 12, 4);
            if (ValPass.code != 200) return ValPass;

            return new ResponseModelGeneral(200, "");
        }

        public ResponseModelGeneral UpdateNameUSer(UpdateNameFromUserModelRequest ReqModel)
        {

            ResponseModelGeneral ValName = ValidH.ValidResp(ReqModel.Name, "Name", 25, 4);
            if (ValName.code != 200) return ValName;

            return new ResponseModelGeneral(200, "");
        }

        public ResponseModelGeneral Register(RegisterRequestModel ReqModel)
        {

            ResponseModelGeneral ValUser = ValidH.ValidResp(ReqModel.User, "User", 12, 4);
            if (ValUser.code != 200) return ValUser;
            ResponseModelGeneral ValPass = ValidH.ValidResp(ReqModel.Pass, "Pass", 12, 4);
            if (ValPass.code != 200) return ValPass;
            bool ValPassStrong = (new HelperGeneral()).PasswordIsStrong(ReqModel.Pass);
            if (!ValPassStrong) return new ResponseModelGeneral(400, MessageHelper.CredentialsNotStrong);
            ResponseModelGeneral ValPassR = ValidH.ValidResp(ReqModel.PassR, "PassR", 12, 4);
            if (ValPassR.code != 200) return ValPassR;

            if (ReqModel.Pass != ReqModel.PassR) return new ResponseModelGeneral(400, MessageHelper.CredentialsNotMach);

            ResponseModelGeneral ValName = ValidH.ValidResp(ReqModel.Name, "Name", 25, 4);
            if (ValName.code != 200) return ValName;
            ResponseModelGeneral ValEmail = ValidH.ValidResp(ReqModel.Email, "Email", 50, 8, ListRegExp: new List<string> { VarHelper.RegExpEmail }, ListMsjRegExp: new List<string>() { "El parametro de Email no coincide con un correo válido" });
            if (ValEmail.code != 200) return ValEmail;

            return new ResponseModelGeneral(200, "");
        }
    }
}
