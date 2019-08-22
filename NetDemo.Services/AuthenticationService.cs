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

        public string CreateToken(string email, string password, int id)
        {
            try
            {
                var encryptString = Encrypt(email, password);

                SendMail(email, encryptString);
                InsertHash(encryptString, id);
                return encryptString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetToken(string email)
        {
            var token = _personRepository.GetAll().Where(x => x.EmailAddress.Equals(email)).Select(s => s.SecurityToken).FirstOrDefault();

            return token;
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
                mail.Body = "<a href ='http://localhost:44394/Demo/Verification/" + encryptstr + "?email=" + sender + "> login </a>";

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
        private void InsertHash(string text, int id)
        {
            try
            {
                Person pInfo = new Person();

                pInfo = _personRepository.GetById(id);
                pInfo.SecurityToken = text;
                _personRepository.Update(pInfo);
            }
            catch (Exception ex)
            {
            }
        }

        private string Encrypt(string email, string password)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(email);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(password);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}