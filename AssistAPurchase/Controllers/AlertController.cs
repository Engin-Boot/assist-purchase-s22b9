using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;
using System.Net;
using System.Net.Mail;
using System;

namespace AssistAPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly SendEmail _sendEmail;
        private IAlertRepository Alerts { get;}
        public AlertController(IAlertRepository alerts)
        {
            Alerts = alerts;
            _sendEmail = new SendEmail();
        }
        
        
        [HttpPost("ConfirmationAlert")]
        public IActionResult SendAlert([FromBody] AlertModel body)
        {
            string message;
            if (body == null)
            {
                message = "Unable to send alert!!.";
                return BadRequest(message);
            }
            message = body.CustomerName + " has booked following monitoring devices " + "\n" + body.ItemPurchased;
            return Ok(message);
        }

        [HttpPost("Query")]
        public IActionResult QueryFromCustomer([FromBody] AlertModel body)
        {
            string message;
            if (body==null)
            {
                message = "Unable to send Message.";
                return BadRequest(message);
            }
            message = "Message Sent!!";
            Alerts.Add(body);
            return Ok(message);
        }

        [HttpPost("Query/{customerName}")]
        public IActionResult AnswerFromPhilipsPersonnel(string customerName, [FromBody] AlertModel answer)
        {
            AlertModel alert= Alerts.FindByCustomerName(customerName);
            if (alert == null)
                return NotFound("Query Not Registered.");
            string message = "Question : " + alert.Question + "\n" + "Answer : " + answer.Answer;
            return Ok(message);
        }

        [HttpPost("email")]
        public IActionResult Post([FromBody] Mailer mailData)
        {
            try
            {
                _sendEmail.SendEmailViaWebApi(mailData);
            }
            catch (SmtpException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
