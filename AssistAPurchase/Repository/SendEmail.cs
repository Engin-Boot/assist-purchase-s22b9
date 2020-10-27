using AssistAPurchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AssistAPurchase.Repository
{
    public class SendEmail
    {
        public void SendEmailViaWebApi(Mailer mailData)
        {
            
                using var smtp = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("Sender Username", "Sender Password")
                };

                // send the email
                var mailBody = new StringBuilder();
                mailBody.Append("Please find the following customer email id and selected product(s).\n");
                mailBody.Append("Customer Name: " + mailData.CustomerName + "\n");
                mailBody.Append("Customer Email Id: " + mailData.CustomerEmailId + "\n");
                mailBody.Append("Mobile number:" + mailData.Mobile + "\n");
                mailBody.Append("Product interested in:" + mailData.ProductName);
                



                smtp.Send("gaganpunjabi316@gmail.com", "gaganpunjabi316@gmail.com", "Alert: Customer Requirement", mailBody.ToString());
                
            
            
        }
    }
}
