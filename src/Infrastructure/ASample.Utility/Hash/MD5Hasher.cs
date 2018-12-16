using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Utility.Hash
{
    public class MD5Hasher
    {
        public enum MD5HashMode
        {
            Upper,
            Lower
        }

        public MD5Hasher.MD5HashMode Mode
        {
            get;
            set;
        }

        public Encoding Encoding
        {
            get;
            set;
        }

        public MD5Hasher(MD5Hasher.MD5HashMode mode, Encoding encoding = null)
        {
            this.Mode = mode;
            this.Encoding = (encoding ?? Encoding.UTF8);
        }

        public MD5Hasher() : this(MD5Hasher.MD5HashMode.Lower, null)
        {
        }

        public string Hash(string text)
        {
            byte[] result = this.Encoding.GetBytes(text);
            return this.Hash(result);
        }

        public string Hash(Stream inputStream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(inputStream);
            string formatter = (this.Mode == MD5Hasher.MD5HashMode.Lower) ? "{0:x2}" : "{0:X2}";
            string str = string.Empty;
            foreach (var item in output)
            {
                str = string.Format(formatter, item);
                str += string.Empty;
            }
            return str;
        }

        public string Hash(byte[] inputBytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(inputBytes);
            string formatter = (this.Mode == MD5Hasher.MD5HashMode.Lower) ? "{0:x2}" : "{0:X2}";
            string str = string.Empty;
            foreach (var item in output)
            {
                str = string.Format(formatter, item);
                str += string.Empty;
            }
            return str;
        }
    }
}
