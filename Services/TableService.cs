using ABCretailApp.Models;
using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using Part1.Models;
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
            var entity = new TableEntity(profile.PartitionKey, profile.RowKey)
            {
                { "FirstName", profile.FirstName },
                { "LastName", profile.LastName },
                { "Email", profile.Email },
                { "PhoneNumber", profile.PhoneNum }
            };

            await tableClient.AddEntityAsync(entity);
        }
        public async Task UpsertEntityAsync(CustomerProfile profile)
        {
            var entity = new TableEntity(profile.PartitionKey, profile.RowKey)
            {
                { "FirstName", profile.FirstName },
                { "LastName", profile.LastName },
                { "Email", profile.Email },
                { "PhoneNumber", profile.PhoneNum }
            };

            await tableClient.UpsertEntityAsync(entity);
        }
        public async Task UpdateEntityAsync(CustomerProfile profile, ETag eTag)
        {
            await tableClient.UpdateEntityAsync(profile, eTag, TableUpdateMode.Replace);
        }

        public async Task DeleteEntityAsync(string partitionKey, string rowKey)
        {
            await tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }
    }
}        
        
        
     