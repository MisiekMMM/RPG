using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace RPG;

public static class Hasher
{
    public static string ComputeSha256(string Text)
    {
        string hashedString = "";
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Text);

            byte[] hashed = sha256.ComputeHash(bytes);

            hashedString = BitConverter.ToString(hashed).Replace("-", "");
        }
        return hashedString;
    }
}