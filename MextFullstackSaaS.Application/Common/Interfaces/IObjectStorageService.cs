namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken);
        Task<List<string>> UploadImagesAsync(List<string> imagesData, CancellationToken cancellationToken);
        Task<List<bool>> RemoveAsync(string key, CancellationToken cancellationToken);
        Task<List<bool>> RemoveAsync(List<string> keys, CancellationToken cancellationToken);
      
    }
}
