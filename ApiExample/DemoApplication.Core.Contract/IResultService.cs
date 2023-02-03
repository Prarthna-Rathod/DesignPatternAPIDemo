using DemoApplication.Core.Domain.RequestModel;
using DemoApplication.Core.Domain.ResponseModel;
using DemoApplication.Shared;

namespace DemoApplication.Core.Contract
{
    public interface IResultService
    {
        Task AddResultAsync(ResultRequestModel resultModel);

        Task<PagedList<ResultResponseModel>> GetResultsAsync(string searchTerm = null, int page = 1, int pageSize = 25);
        Task DeleteResultAsync(int resultId);

        Task<string> DownloadFile(int resultId);
    }
}