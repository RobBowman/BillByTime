using System.Text.RegularExpressions;

namespace BillByTime.Common
{

    public class EmailAddress
    {
        private string address = "";

        public string Address
        {
            get { return address; }
            set {
                if (IsValidEmail(value))
                    address = value;
                else
                    throw new ApplicationException($"{value} is not a valid email address");
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

    }
}