using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //salting: şifreye ekleme yapmak
        //verilen bir şifrenin hash ve salt'ını oluşturur
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)

        {
            // kriptografi için kullanılacağımız algoritmayı belirtiyoruz.
           
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //salt olarak algoritma içerisindeki key değerini kullanıyoruz.
                //her kullanıcı için farklı bir key oluşturur.
                passwordSalt = hmac.Key;

                // byte değer ile çalıştığı için string olan şifremizin byte değerini verdik
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  

            }


        }

        /*kayıt olunmuş bir sisteme yeniden giriş yaparken kullanıcın girdiği şifre  hashlenir
        sonra o hash veritabanındaki hash ile uyuşup uyuşmadığı kontrolu yapılır. 
         */
        //burada password kullanıcının girdiği şifre, passwordHash ilk kayıt olduğunda oluşturulan, veritabanında tutulan şifre hash'i
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // unutma  salt değerini kullarak hash yapıyor
         
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }


        }
    }
}
