using System.Text;

namespace Logic.Shared.Helpers
{
    public static class PasswordHelper
    {
        public static string GetEncodedPassword(string password, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password).ToList();

            bytes.AddRange(Encoding.ASCII.GetBytes(salt));

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
