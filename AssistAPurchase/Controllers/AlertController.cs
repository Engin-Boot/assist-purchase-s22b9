using System;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistAPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        //Dictionary<int, AlertModel> querys = new Dictionary<int, AlertModel>();
        private static List<AlertModel> querys;
        //static int queryNumber;
        // POST api/Mailing

        public AlertController()
        { 
            querys =new List<AlertModel>();
            //queryNumber = 0;
        }
        [HttpPost("ConfirmationAlert")]
        public IActionResult SendAlert([FromBody] AlertModel body)
        {
            string message = "";
            if (body == null)
            {
                message = "Unable to send alert!!.";
                return NotFound(message);
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
                return NotFound(message);
            }
            message = "Message Sent!!";
            querys.Add(body);
            querys.Append(body);
            //++queryNumber;
            return Ok(querys);
        }

        [HttpPost("Query/{customerName}")]
        public IActionResult AnswerFromPhilipsPersonnel(string customerName, [FromBody] AlertModel answer)
        {

            string message;
            for (int i = 0; i < querys.Count; i++)
            {
                if (querys[i].CustomerName == customerName)
                {
                    message = "Question : " + querys[i].Question + "\n" + "Answer : " + answer.Answer;
                    return Ok(message);
                }
            }
            message = "Invalid Query Number";
            return NotFound(querys);
        }
    }
}
