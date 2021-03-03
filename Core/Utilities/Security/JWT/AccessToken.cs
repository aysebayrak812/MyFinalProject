using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken
    {

        public string Token { get; set; }//jeton 
        public DateTime Expiration { get; set; }//süresi ne zaman bitecek  
    }
}
