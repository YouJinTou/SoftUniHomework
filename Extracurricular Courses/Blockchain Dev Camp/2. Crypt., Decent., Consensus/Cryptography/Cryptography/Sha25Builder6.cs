using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Sha256Hasher
    {
        public string GetSha256Hash(string toHash)
        {
            var bytes = Encoding.Unicode.GetBytes(toHash);
            var hasher = new SHA256Managed();
            var hashBytes = hasher.ComputeHash(bytes);
            var hashBuilder = new StringBuilder();

            foreach (var hashByte in hashBytes)
            {
                hashBuilder.Append(string.Format("{0:x2}", hashByte));
            }

            return hashBuilder.ToString();
        }
    }
}
