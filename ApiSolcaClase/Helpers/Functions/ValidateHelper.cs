using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using System.Text.RegularExpressions;

namespace ApiSolcaClase.Helpers.Functions
{
    public class ValidateHelper<T>
    {
        public ResponseModelGeneral<T> ValidResp(string Value, string Name, int? Max = null, int? Min = null, List<string>? ListRegExp = null, string? MsjMinV = null, string? MsjMaxV = null, List<string>? ListMsjRegExp = null)
        {
            if(Max != null)
            {
                if (!MaxLength(Value, Max ?? 0)) return new ResponseModelGeneral<T>(
                    400,
                    MessageHelper.ErrorParamsGeneral,
                    MsjMaxV ?? "El parametro " + Name + " excede el límite de " + Max + " caracteres"
                );
            }
            if (Min != null)
            {
                if (!MinLength(Value, Min ?? 0)) return new ResponseModelGeneral<T>(
                    400,
                    MessageHelper.ErrorParamsGeneral,
                    MsjMinV ?? "El parametro " + Name + " debe tener un mínimo de " + Min + " caracteres"
                );
            }

            if (ListRegExp != null)
            {
                for (int i = 0; i < ListRegExp.Count; i++)
                {
                    if (!RegExpVald(Value, ListRegExp[i]))
                    {
                        bool isMsjPers = ListMsjRegExp != null ? ListMsjRegExp.Count >= (i - 1) : false;
                        return new ResponseModelGeneral<T>(
                            400,
                            MessageHelper.ErrorParamsGeneral,
                            isMsjPers ? ListMsjRegExp[i] : "El parametro " + Name + " no cumple con la expresión regular " + ListRegExp[i]
                        );
                    }
                }
            }


            return new ResponseModelGeneral<T>(200, "");
        }

        bool MaxLength(string Value, int Max)
        {
            return (Value.Length <= Max);
        }

        bool MinLength(string Value, int Min)
        {
            return (Value.Length >= Min);
        }

        bool RegExpVald(string Value, string RegExp)
        {
            Regex RegE = new Regex(RegExp);
            return RegE.IsMatch(Value);
        }


        bool EmailValid(string Value)
        {
            string RegExpEmail = VarHelper.RegExpEmail;
            return RegExpVald(Value, RegExpEmail);
        }
    }
}
