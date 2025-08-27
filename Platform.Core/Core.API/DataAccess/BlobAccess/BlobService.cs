using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Core.API.DataAccess.BlobAccess
{
    public class BlobService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobService(IConfiguration config)
        {
            var connectionString = config["AzureStorage:ConnectionString"];
            var containerName = config["AzureStorage:ContainerName"];
            _containerClient = new BlobContainerClient(connectionString, containerName);
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
        }

        public string UploadFile(IFormFile file)
        {
            var blobName = $"{Guid.NewGuid()}-{file.FileName}";
            var blobClient = _containerClient.GetBlobClient(blobName);

            using (var stream = file.OpenReadStream())
            {
                blobClient.Upload(stream, overwrite: true);
            }

            return blobClient.Uri.ToString();
        }
    }
}