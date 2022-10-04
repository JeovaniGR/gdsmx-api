using gdsmx_back_netcoreAPI.BL.FileUpload.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

namespace gdsmx_back_netcoreAPI.BL.FileUpload
{
    public class AzureBlobFileUploader : IFileUploader
    {
        private BlobServiceClient _blobServiceClient;
        private string _containerName;
        private BlobContainerClient _containerClient;
        private BlobClient _blobClient;

        public AzureBlobFileUploader()
        {
            _blobServiceClient = new BlobServiceClient(
                new Uri("https://gdsmxdemostrgacnt.blob.core.windows.net"),
                new DefaultAzureCredential());
            _containerName = "TestBlobs";
        }   
        public async void UploadFile(IFormFile file)
        {
            CreateContainerClient();
            CreateBlobClient(file.FileName);
            //Upload the file
            await _blobClient.UploadAsync(file.OpenReadStream());
        }

        private void CreateContainerClient()
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        }

        private void CreateBlobClient(string fileName)
        {
            _blobClient = _containerClient.GetBlobClient(fileName);
        }
    }
}
