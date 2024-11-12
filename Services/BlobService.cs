using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ABCretailApp.Services
{
       
    public class BlobService
    {
        private readonly IConfiguration _configuration;
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task UploadBlobAsync(byte[] imageData, string v, string fileName)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // SQL query to insert the blob data
            var query = @"INSERT INTO BlobTable (BlobImage, FileName) VALUES (@BlobImage, @FileName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add the byte array as a parameter
                command.Parameters.AddWithValue("@BlobImage", imageData);
                command.Parameters.AddWithValue("@FileName", fileName); // Optionally store the file name as well

                // Open connection and execute query
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
