using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //appsetting.json içerisinde vermiş olduğumuz secret key değerini çekiyoruz.
        //bu değeri asp.net'ın jwt servislerinin anlayacağı hale yani byte haline döndürüyoruz.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

        }

    }
}
