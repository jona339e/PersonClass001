using System.Net.Mail;
namespace PersonClass001
{
    internal class Person
    {
        private string _name;
        private string _email;
        private string _pass;

        // If name is null or empty it throws an exception with a custom message. Still results in a crash.
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Name can't be null or empty!");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public DateTime DoB { get; set; }

        // Calculates the age and returns it. There is no setter so it is impossible to change this on it's own.
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - DoB.Year;
                if (DateTime.Today < new DateTime(DateTime.Today.Year, DoB.Month, DoB.Day)) age--;
                return age;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = MailValidation(value);
            }
        }
        public string Psw
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = ValidatePassword(value);
            }
        }

        //Using this method as a setter results in an overflow exception. Not sure why!
        public string MailValidation(string Email)
        {
            string result2 = "";
            MailAddress? temp;
            do
            {
                if (!MailAddress.TryCreate(Email, out temp))
                {
                    Console.WriteLine("Email ikke godkendt. Email skal indeholde @ og .");
                    Console.Write("Indtast Email: ");
                    Email = Console.ReadLine();
                }
                else
                {
                    MailAddress.TryCreate(Email, out temp);
                    result2 = temp.ToString();
                }
            } while (string.IsNullOrEmpty(result2));

            return result2;
        }
        public string ValidatePassword(string psw)
        {
            string errorMessageÍfLength = PasswordLength(psw);
            string errorMessegeÍfSpace = ContainsSpace(psw);
            string errorMessageÍfUpper = UpperCaseLetter(psw);
            string errorMessageÍfLower = LowerCaseLetter(psw);
            string errorMessageÍfSpecial = SpecialLetter(psw);

            if (!string.IsNullOrEmpty(PasswordLength(psw)))
            {
                return errorMessageÍfLength;
            }
            else if (!string.IsNullOrEmpty(ContainsSpace(psw)))
            {
                return errorMessegeÍfSpace;
            }
            else if (!string.IsNullOrEmpty(UpperCaseLetter(psw)))
            {
                return errorMessageÍfUpper;
            }
            else if (!string.IsNullOrEmpty(LowerCaseLetter(psw)))
            {
                return errorMessageÍfLower;
            }
            else if (!string.IsNullOrEmpty(SpecialLetter(psw)))
            {
                return errorMessageÍfSpecial;
            }
            return psw;
        }
        private string PasswordLength(string psw) // Checker om der er min 6 tegn i mit password, fejl hvis der ikke er.
        {
            if (psw.Length >= 6)
            {
                return "";
            }
            else
            {
                return "Dit password skal være på mindst 6 tegn";
            }
        }
        private string ContainsSpace(string psw) // Checker om der er mellemrum i mit password, fejl hvis der er.
        {
            if (psw.Contains(" ") == false)
            {
                return "";
            }
            else
            {
                return "Der må ikke være mellemrum i dit password";
            }
        }
        private string UpperCaseLetter(string psw) // Checker om der findes et uppercase character i mit password, fejl hvis der ikke er.
        {
            foreach (char upper in psw)
            {
                if (Char.IsUpper(upper))
                {
                    return "";
                }
            }
            return "Password skal indeholde et stort bogstav";
        }
        private string LowerCaseLetter(string psw) // Checker om der findes et lowercase character i mit password, fejl hvis der ikke er.
        {
            {
                foreach (char lower in psw)
                {
                    if (Char.IsUpper(lower))
                    {
                        return "";
                    }
                }
                return "Dit password skal indeholde et lille bogstav";
            }
        }
        private string SpecialLetter(string psw) // Checker om der findes et specialtegn i mit password, fejl hvis der ikke er.
        {
            foreach (char special in psw)
            {
                if (!Char.IsLetterOrDigit(special))
                {
                    return "";
                }
            }
            return "Dit password skal indeholde et special-tegn";
        }

    }
}
