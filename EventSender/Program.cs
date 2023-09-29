using Azure.Messaging.EventHubs.Producer;
using System.Text;

namespace EventSender
{
    internal class Program
    {
        private static readonly string conn = "[Your-Event-Hub-Connection-String]";

        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>() 
            {
                new Order() { OrderId = "JIL12",OrderName="Iphone 15",Price=200000},
                new Order() { OrderId = "KUI89",OrderName="Iphone 14",Price=120000},
                new Order() { OrderId = "GFD56",OrderName="Iphone 13",Price=130000},
                new Order() { OrderId = "DSF78",OrderName="Iphone 12",Price=110000},
                new Order() { OrderId = "JHD45",OrderName="Iphone 11",Price=70000},
            };

            EventHubProducerClient eventHubProducerClient = new EventHubProducerClient(conn);

            EventDataBatch eventDataBatch = eventHubProducerClient.CreateBatchAsync().GetAwaiter().GetResult();

            foreach(Order order in orders) 
            {
                eventDataBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(order.ToString())));
            }

            eventHubProducerClient.SendAsync(eventDataBatch).GetAwaiter().GetResult();

            Console.WriteLine("Batch send successfully");

            Console.ReadKey();
        }
    }
}