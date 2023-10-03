using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BarbasBigodes.Core
{
    class Criptografia
    {
        public static string ObterHash(String senha)
        {
            var md5Hasker = MD5.Create();
            var senhaCriptografia = md5Hasker.ComputeHash(Encoding.Default.GetBytes(senha));
            var sb = new StringBuilder();
            for (int i = 0; i < senhaCriptografia.Length; i++)
            {
                sb.Append(senhaCriptografia[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
