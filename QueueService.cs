using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Threading.Tasks;
namespace SemesterTwo.Services
{
    public class QueueService
    {
        private readonly QueueServiceClient queueServiceClient;

        public QueueService(IConfiguration configuration)
        {
            queueServiceClient = new QueueServiceClient(configuration["AzureStorage:ConnectionStringBuilder"]);
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync(message);
        }
    }
}