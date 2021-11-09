using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OtpProject
{
    class Program
    {
        


        static void Main(string[] args)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("twiliosid");
            string authToken = Environment.GetEnvironmentVariable("twilioauth");

            TwilioClient.Init(accountSid, authToken);

            Random r = new Random();
            int sifre;
          

            sifre = r.Next(1000, 9999);

            var message = MessageResource.Create(
                body: sifre.ToString(),
                from: new Twilio.Types.PhoneNumber("Twilio'dan telefon numarası yazılacak"),
                to: new Twilio.Types.PhoneNumber("şifre göndermek istediğiniz mesaj buraya yazılacak")
            );

            
            Console.Write("SMS OLARAK GÖNDERİLEN ŞİFREYİ GİRİNİZ = ");
            int sifrekontrol; sifrekontrol = Convert.ToInt16(Console.ReadLine());
            if (sifre == sifrekontrol) { Console.WriteLine("GİRDİĞİNİZ ŞİFRE DOĞRU"); }
            else { Console.WriteLine("GİRDİĞİNİZ ŞİFRE YANLIŞ"); }
            Console.WriteLine(message.Sid);
            Console.Read();



        }
    }
}
