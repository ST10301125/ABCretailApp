using ABCretailApp.Models;
using Azure.Data.Tables;
using Part1.Models;
using System.Threading.Tasks;

namespace Part1.Services
{
    public class TableService
    {
        private readonly TableClient tableClient;

        public TableService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureStorage:ConnectionString"];
            var serviceClient = new TableServiceClient(connectionString);
            tableClient = serviceClient.GetTableClient("CustomerProfiles");
            tableClient.CreateIfNotExists();
        }

        public async Task AddEntityAsync(CustomerProfile profile)
        {
            await tableClient.AddEntityAsync(profile);
        }

    }
}