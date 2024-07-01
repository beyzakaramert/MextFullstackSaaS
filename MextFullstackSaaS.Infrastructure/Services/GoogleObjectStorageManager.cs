using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager : IObjectStorageService
    {
        public Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> UploadImageAsync(List<string> imagesData, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
