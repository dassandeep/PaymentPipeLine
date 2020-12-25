using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipeLineWebApplication.KafkaRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPaymentKafkaSettings
    {
        //string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string TopicName { get; set; }
    }
}
