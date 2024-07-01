namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken);
        Task<List<string>> UploadImageAsync(List<string> imagesData, CancellationToken cancellationToken);

    }
}
