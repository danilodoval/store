using FluentValidator;
using Store.Shared.Entities;
using System.Text;

namespace Store.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {

        }

        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = EncryptPassword(password);

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(confirmPassword), "Password does not match");
        }

        public string Username { get; private set; }
        public string Password { get; private set; }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
