using System.Security;
using Policem.Core.Extensions;

namespace Policem.Core.Utility
{
    public static class CryptoManager
    {
        public static string Sifrele(string Sifresiz)
        {
            SecureString secureString = Sifresiz.ToSecureString();
            return secureString.Encrypt();
        }

        public static string SifreCoz(string Sifreli)
        {
            var secureString = Sifreli.DecryptSecure();
            return secureString.ToUnsecureString();
        }
    }
}
//var passString = txtMailSifre.EditValue.ToString().Trim();
//SecureString secureString = passString.ToSecureString();
//string secureCryptolu = secureString.Encrypt();

//var test = secureCryptolu.DecryptSecure();
//var test2 = test.ToUnsecureString();
//bool deneme = test2 == passString ? true : false;