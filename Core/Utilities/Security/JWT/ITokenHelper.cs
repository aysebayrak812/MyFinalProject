using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public  interface ITokenHelper
    {
        //claim =yetki

        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

        //token üreten yer kim için =user 
        //user in nasıl yetkileri  olsun  onlarda OperationClaim den gelsin 
        //kullanıcı adı ve şifre girdi api ye geldi bunlar ve doğru ise  CreateToken çalışacak ilgili kullanıcuı için =User user
        // veri tabanına gidecek bu kullanıcının claim lerini (yetkilerini)= List<OperationClaim> bulacak  ve onlar kullanıcıya verecek
        


    }

}
