using System;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using System.Collections.Generic;
using System.Linq;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistAPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        public IAlertRepository Alerts { get; set; }
        public AlertController(IAlertRepository alerts)
        {
            Alerts = alerts;
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
            message = body.CustomerName + " has booked following monitoring devices " + "\n" + body.ItemPurchased ;
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

            string message;
            AlertModel alert= Alerts.FindByCustomerName(customerName);
            if (alert == null)
                return NotFound("Query Not Registeded.");
            message = "Question : " + alert.Question + "\n" + "Answer : " + answer.Answer;
            return Ok(message);
        }
    }
}
