using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
                                    //HASHLEDİK 
  public class HashingHelper
    {
        public static void CreatePasswordHash//verdiğim şifrenin salt ve has değerini vermeye yarıyor
            (string password,out byte[] passwordSalt,out byte[] passwordHash)//out dışarıya verilebielcek değer
            //bir tane  şifre vereceğiz dışarı iki değeri verecek
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //KEY =benim bildiğim bir yapı şifreler için .İlgili kulanıdığım algoritmanın o an 
                //oluşturduğu key değeri her kulanıcı için farklı  
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }//Encoding.UTF8.GetBytes(password) string in  byte değerini aldık 
        }
        //VerifyPasswordHash =PasswordHash i doğrulama 
        //haslediğinde böyle birşey çıkarmıydı veri tabanındaki hash 
        //tekrrar dan girmrye çalıstiğinda uyusması iiçin verilen haşh ler uyumlumu 

                                 //DOĞRULADIK 
        public static bool VerifyPasswordHash(string password,byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac =new System.Security.Cryptography.HMACSHA512(passwordSalt))//keyin ne
            {
                //computedHash =hesaplanan hash
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])//eşleşmesse false
                    {
                        return false;
                    }
                }
            }
            return true;//yoksa true.
        }
    }

}
