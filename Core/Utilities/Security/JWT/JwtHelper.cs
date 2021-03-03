using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
  
    public class JwtHelper:ITokenHelper
    {
        public IConfiguration Configuration { get; }//apideki  appsettings i okumaya yarıyor dosyadaki değerleri
        private TokenOptions _tokenOptions;//okunan değerleri nesneye atar 
        private DateTime _accessTokenExpiration;//ne zaman geçersizleşecek
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //birbirlerine eşitledi 
        }
        //
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)//bu kullanıcı için bie tane token (jeton)üretiyoruz
                                                                                       
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//10 dk sonra token ol

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //benim bir tane securityKeye (güvenlik anahtarı) ihtiyacım var=SecurityKeyHelper (bennim oluşturduğum var)
            //Onunda CreateSecurityKey i var _tokenOptions.SecurityKey bunu kullanarak onu oluşturabilirisn
            
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //hangi algoritmayı kulllanayım ve anahtar ne = SigningCredentialsHelper 

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            //kullanıcı için  olustrur 
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(//token olusturmaya yarıyor= JwtSecurityToken
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials:signingCredentials
                //yukaıdakilerler
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());//kullanıcının kullanıcı Id si
            claims.AddEmail(user.Email);//emaili
            claims.AddName($"{user.FirstName} {user.LastName}");//ad soyad
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());//roller
            
            return claims;
        }
    }
}
