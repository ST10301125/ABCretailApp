using Azure.Data.Tables;
using SemesterTwo.Models;
using System.Threading.Tasks;

namespace ABCretailApp.Services
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