using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Threading.Tasks;

namespace ABCretailApp.Services
{
    public class QueueService
    {
        private readonly QueueServiceClient queueServiceClient;

        public QueueService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureStorage:ConnectionString"];
            queueServiceClient = new QueueServiceClient(connectionString);
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync(message);
        }
        public async Task<string?> ReceiveMessageAsync(string queueName)
        {
            var queueClient = queueServiceClient.GetQueueClient(queueName);
            var message = await queueClient.ReceiveMessageAsync();

            if (message.Value != null)
            {
                await queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
                return message.Value.MessageText;
            }

            return null;
        }
    }
}