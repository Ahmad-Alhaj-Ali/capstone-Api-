namespace capstone.Helpers.Validation
{
    public static class ValidationHelper
    {
        public static bool IsValidUserName(string user) 
        {
            if(string.IsNullOrEmpty(user) && user.Length < 8)
            {
                throw new Exception("username invalid");
            }
            return true;
        }
        public static bool IsValidEmail(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email Is  Required");

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex >= email.Length - 2)
                throw new Exception("Email Is  Required");

            string domain = email.Substring(atIndex + 1, dotIndex - atIndex - 1);
            string extension = email.Substring(dotIndex + 1);

            if (domain.Length < 2 || extension.Length < 2)
                throw new Exception("Email Is  Required");

            foreach (char c in email.Substring(0, atIndex))
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '%' && c != '+' && c != '-')
                    throw new Exception("Email Is  Required");
            }
            return true;
        }
         public static bool IsValidPassword(string pass) 
         {
            if (string.IsNullOrEmpty(pass) && pass.Length >= 6)
                throw new Exception("Password Is Required");
            return true;
        
         }
        public static bool IsValidFirstName(string fname)
        {
            if (string.IsNullOrEmpty(fname) && fname.Length < 8)
            {
                throw new Exception("first name invalid");
            }
            return true;
        }
        public static bool IsValidLastName(string lname)
        {
            if (string.IsNullOrEmpty(lname) && lname.Length < 8)
            {
                throw new Exception("last name invalid");
            }
            return true;
        }


    }
}
