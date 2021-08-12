using System.Text.RegularExpressions;

namespace RaroLabs.Shared.Validations
{
    public static class ValidaCep
    {
        public static bool IsValid(int cep)
        {
            string validaCep = string.Empty;

            validaCep = cep.ToString().Replace(".", "");
            validaCep = cep.ToString().Replace("-", "");
            validaCep = cep.ToString().Replace(" ", "");

            var Rgx = new Regex(@"^\d{8}$");

            if (!Rgx.IsMatch(validaCep))
                return false;
            else
                return true;
        }
    }
}
