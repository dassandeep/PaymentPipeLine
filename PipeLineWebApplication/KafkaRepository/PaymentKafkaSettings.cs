using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeLineWebApplication.KafkaRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentKafkaSettings:IPaymentKafkaSettings
    {
        ///public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
    }
}
