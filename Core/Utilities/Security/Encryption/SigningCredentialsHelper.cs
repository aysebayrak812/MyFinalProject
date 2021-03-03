using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //imzalama= Signing
                            //WEP API için doğrulama yaptırdık : hangi anahtar hangi doğrulama algoritması 
                            //api ile bağlantı 
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            //Asp.net e anahtar olarak securityKey, şifreleme olarakda SecurityAlgorithms lardan (güvenlik algoritmalarından 
            //HmacSha512Signature yi kullan  


        }
    }
}
