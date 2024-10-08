﻿using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ABCretailApp.Services
{
    public class FileService
    {

        private readonly ShareServiceClient shareServiceClient;

        public FileService(IConfiguration configuration)
        {
            shareServiceClient = new ShareServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        public async Task UploadFileAsync(string shareName, string fileName, Stream content)
        {
            var shareClient = shareServiceClient.GetShareClient(shareName);
            await shareClient.CreateIfNotExistsAsync();
            var directoryClient = shareClient.GetRootDirectoryClient();
            var fileClient = directoryClient.GetFileClient(fileName);
            await fileClient.CreateAsync(content.Length);
            await fileClient.UploadAsync(content);
        }
        public async Task<Stream> DownloadFileAsync(string shareName, string directoryName, string fileName)
        {
            var shareClient = shareServiceClient.GetShareClient(shareName);
            var directoryClient = shareClient.GetDirectoryClient(directoryName);
            var fileClient = directoryClient.GetFileClient(fileName);
            ShareFileDownloadInfo download = await fileClient.DownloadAsync();
            return download.Content;
        }
    }
}