using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PipeLineWebApplication.KafkaRepository
{
    public static class KafkaUtil
    {
        static readonly AutoResetEvent _closing = new AutoResetEvent(false);
        static IProducer<string, string> producer = null;
        static ProducerConfig producerConfig = null;
        static void CreateConfig(string connectionString)
        {
            producerConfig = new ProducerConfig
            {
                BootstrapServers = connectionString
            };
        }
        static void CreateProducer()
        {
            var pb = new ProducerBuilder<string, string>(producerConfig);
            producer = pb.Build();
        }
        static async void SendMessage(string topic, string message)
        {
            var msg = new Message<string, string>
            {
                Key = null,
                Value = message
            };

            var delRep = await producer.ProduceAsync(topic, msg);
            var topicOffset = delRep.TopicPartitionOffset;

            //Console.WriteLine($"Delivered '{delRep.Value}' to: {topicOffset}");
        }
        static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            _closing.Set();
        }

        public static void PushMessage(string connectionString,string message,string topicName)
        {
            CreateConfig(connectionString);
            CreateProducer();
            SendMessage(topicName, message);
        }
    }
}
