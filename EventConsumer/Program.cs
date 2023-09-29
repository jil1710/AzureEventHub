
using Azure.Messaging.EventHubs.Consumer;
using System.Text;

namespace EventConsumer
{
    internal class Program
    {
        private static string conn = "You-Eventhub-Connection-String";
        private static string consumer_group = "Your-Consumer-Group";
        static async Task Main(string[] args)
        {
            EventHubConsumerClient eventHubConsumerClient = new EventHubConsumerClient(consumer_group,conn);
            
            await foreach(PartitionEvent _event in eventHubConsumerClient.ReadEventsAsync())
            {
                // Process the data
                Console.WriteLine($"Partition Key : {_event.Partition.PartitionId}");
                Console.WriteLine($"Data Offset : {_event.Data.Offset}");
                Console.WriteLine($"Sequence Number : {_event.Data.SequenceNumber}");
                Console.WriteLine($"Partition Key : {_event.Data.PartitionKey}");
                Console.WriteLine($"PayLoad Value : {Encoding.UTF8.GetString(_event.Data.EventBody)}");
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------------------\n");
            }
        }
    }
}