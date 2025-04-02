using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Models.AppModels.WeatherForecast;

namespace ApiSolcaClase.Validator.Security
{
    public class UserValidate
    {

        public UserValidate()
        {
        }

        public ResponseModelGeneral<LoginResponseModel> Login(LoginRequestModel ReqModel)
        {
            ValidateHelper<LoginResponseModel> ValidH = new ValidateHelper<LoginResponseModel>();

            ResponseModelGeneral<LoginResponseModel> ValUser = ValidH.ValidResp(ReqModel.User, "User", 12, 4);
            if (ValUser.code != 200) return ValUser;
            ResponseModelGeneral<LoginResponseModel> ValPass = ValidH.ValidResp(ReqModel.Pass, "Pass", 12, 4);
            if (ValPass.code != 200) return ValPass;

            return new ResponseModelGeneral<LoginResponseModel>(200, "");
        }

        public ResponseModelGeneral<object> UpdateNameUSer(UpdateNameFromUserModelRequest ReqModel)
        {
            ValidateHelper<object> ValidH = new ValidateHelper<object>();

            ResponseModelGeneral<object> ValName = ValidH.ValidResp(ReqModel.Name, "Name", 25, 4);
            if (ValName.code != 200) return ValName;

            return new ResponseModelGeneral<object>(200, "");
        }

        public ResponseModelGeneral<object> Register(RegisterRequestModel ReqModel)
        {
            ValidateHelper<object> ValidH = new ValidateHelper<object>();

            ResponseModelGeneral<object> ValUser = ValidH.ValidResp(ReqModel.User, "User", 12, 4);
            if (ValUser.code != 200) return ValUser;
            ResponseModelGeneral<object> ValPass = ValidH.ValidResp(ReqModel.Pass, "Pass", 12, 4);
            if (ValPass.code != 200) return ValPass;
            bool ValPassStrong = (new HelperGeneral()).PasswordIsStrong(ReqModel.Pass);
            if (!ValPassStrong) return new ResponseModelGeneral<object>(400, MessageHelper.CredentialsNotStrong);
            ResponseModelGeneral<object> ValPassR = ValidH.ValidResp(ReqModel.PassR, "PassR", 12, 4);
            if (ValPassR.code != 200) return ValPassR;

            if (ReqModel.Pass != ReqModel.PassR) return new ResponseModelGeneral<object>(400, MessageHelper.CredentialsNotMach);

            ResponseModelGeneral<object> ValName = ValidH.ValidResp(ReqModel.Name, "Name", 25, 4);
            if (ValName.code != 200) return ValName;
            ResponseModelGeneral<object> ValEmail = ValidH.ValidResp(ReqModel.Email, "Email", 50, 8, ListRegExp: new List<string> { VarHelper.RegExpEmail }, ListMsjRegExp: new List<string>() { "El parametro de Email no coincide con un correo válido" });
            if (ValEmail.code != 200) return ValEmail;

            return new ResponseModelGeneral<object>(200, "");
        }
    }
}
