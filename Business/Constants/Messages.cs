using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages//newlemeye gerek yok
    {

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError = "kategoryde 10 dan fazla ürün olamaz";
        public static string ProductNameAlreadyExists = "bu üründe zaten başka bir ürün var  ";

        public static string CategoryLimitExceded = "kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "yetkiniz yok ";
        public static string UserRegistered = "kayıt oldu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı mevcut";
        public static string AccessTokenCreated = "token oluşturuldu ";
    }
}
