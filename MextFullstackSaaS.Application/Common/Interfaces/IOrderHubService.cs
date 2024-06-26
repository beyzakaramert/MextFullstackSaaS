namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IOrderHubService
    {
        Task NewOrderAddedAsync(string url,CancellationToken cancellationToken);
    }
}
