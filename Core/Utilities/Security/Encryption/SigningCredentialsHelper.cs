using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //imza oluşturma
        //imza oluştururken security key'i vermemiz gerekir.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //anahtar olarak securitykey, hashleme içinde verdiğim algoritmayı kullan
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        }
    }
}
