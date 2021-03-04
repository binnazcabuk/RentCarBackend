
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
      /*kullanıcı giriş yaptığında(doğru bilgileri girmiş) bu yapı çalışacak
        veritabanına gidecek orda kullanıcının claim yani yetkilerini bulacak
        bu bilgileri barındıran bir jwt oluşturacak
      */
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
       
    }

}
