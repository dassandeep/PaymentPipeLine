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
            ///


            KafkaUtil.PushMessage(_paymentKafkaSettings.ConnectionString, "TestMessage", _paymentKafkaSettings.TopicName);

        }
    }
}
/// https://nielsberglund.com/2019/06/18/confluent-platform--kafka-for-a-.net-developer-on-windows/
/// https://medium.com/@shesh.soft/confluent-kafka-integration-with-net-core-2a489fa2512
