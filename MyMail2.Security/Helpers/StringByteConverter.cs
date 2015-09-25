using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMail2.Security.Helpers
{
    public static class StringByteConverter
    {
        public static byte[] GetStringBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] strChars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, strChars, 0, bytes.Length);

            return new string(strChars);
        }
    }
}
