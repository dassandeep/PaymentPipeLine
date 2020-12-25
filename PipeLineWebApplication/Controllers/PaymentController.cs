using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PipeLineWebApplication.KafkaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeLineWebApplication.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentKafkaSettings _paymentKafkaSettings = null;
        public PaymentController(IPaymentKafkaSettings paymentKafkaSettings)
        {
            _paymentKafkaSettings = paymentKafkaSettings;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void PaymentProducer()
        {
            ////////////////////////////////////////////////////
            // Request Log
            ///////////////////////////////////////////////////

            KafkaUtil.PushMessage(_paymentKafkaSettings.ConnectionString, "TestMessage", _paymentKafkaSettings.TopicName);

        }
    }
}
