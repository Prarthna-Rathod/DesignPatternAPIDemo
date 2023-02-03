using DemoApplication.Infra.Domain.Entities;
using DemoApplication.Shared;

namespace DemoApplication.Infra.Contract
{
    public interface IResultRepository
    {
        Task<int> AddResult(Result result);
        Task<PagedList<Result>> GetResults(string searchTerm = null, int page = 1,int pageSize = 25);
        Task<Result?> GetResult(int resultId);
        Task<int> UpdateResult(Result result);

        Task<string> DownloadResultFile(int resultId);
    }
}