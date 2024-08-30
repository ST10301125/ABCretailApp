﻿using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;

namespace ABCretailApp.Services
{

    public class BlobService
    {
        private readonly BlobServiceClient blobServiceClient;
        public BlobService(IConfiguration configuration)
        {
            blobServiceClient = new BlobServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(content, true);
        }
    }
}