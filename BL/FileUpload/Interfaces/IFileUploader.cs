namespace gdsmx_back_netcoreAPI.BL.FileUpload.Interfaces
{
    public interface IFileUploader
    {
        public void UploadFile(IFormFile file);
    }
}
