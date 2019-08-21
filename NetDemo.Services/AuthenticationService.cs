using System;
using NetDemo.Interfaces.Contract;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NetDemo.Models;
using NetDemo.ViewModels;

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

        public string GetToken(string email, string password)
        {
            var token = _personRepository.GetAll().Where(x => x.LastName.Equals(email)).Select(s => s.LastName).FirstOrDefault();

            return token;
        }

        private void SendMail(string sender, string encryptstr)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("testmailmailer3@gmail.com");
                mail.To.Add("to_address");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

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
                pInfo.LastName = text;
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