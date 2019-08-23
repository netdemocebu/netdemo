using System;
using NetDemo.Interfaces.Contract;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using NetDemo.Models;

namespace NetDemo.Services
{
    public class AuthenticationService
    {
        private readonly IPersonRepository _personRepository;

        public AuthenticationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public string CreateToken(string email)
        {
            try
            {
                var encryptString = Encrypt(email, tokenKey);

                SendMail(email, encryptString);

                return encryptString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetToken(string token)
        {
            var securityToken = _personRepository.GetAll().Where(x => x.SecurityToken.Equals(token)).Select(s => s.SecurityToken).FirstOrDefault();
            
            return securityToken;
        }

        private void SendMail(string sender, string encryptstr)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("testmailmailer3@gmail.com");
                mail.To.Add(sender);
                mail.Subject = "Verification Mail";
                mail.Body = "<a href ='http://localhost:44394/api/person/verify/?token=" + encryptstr + "> login </a>";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testmailmailer3@gmail.com", "@password123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                
            }
        }

        private string Encrypt(string email, string key)
        {
            byte[] key2 = Encoding.ASCII.GetBytes(key);
            byte[] inputArray = Encoding.UTF8.GetBytes(email);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = key2;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        const string tokenKey = "012345678901234567890123";
    }
}