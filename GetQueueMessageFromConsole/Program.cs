using System;
using CloudeStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount;
using Microsoft.WindowsAzure.Storage.Queue;

namespace GetQueueMessageFromConsole
{
    class Program
    {
        public static string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=akstaccount;AccountKey=gkGSx+sQsRaUtEU9YAl5cxogSchyKpV7qHl8pkJ+rhuA+yiwllI+0C249yF7cRTu6JrAGX5Dr3Uo8i7rGjQqbA==;EndpointSuffix=core.windows.net";
        public static string QueueName = "task-1";
        static void Main(string[] args)
        {
            GetMessage();
            Console.ReadKey();
        }

        public static void GetMessage()
        {
            CloudeStorageAccount cls = CloudeStorageAccount.Parse(ConnectionString);
            CloudQueueClient queueClient = cls.CreateCloudQueueClient();
            CloudQueue cloudQueue = queueClient.GetQueueReference(QueueName);
            CloudQueueMessage queueMessage = cloudQueue.GetMessage();
            if (queueMessage != null)
            {
                Console.WriteLine(queueMessage.AsString);
            }
            else
            {
                Console.WriteLine("Queue is Empty");
            }
        }
    }
}
