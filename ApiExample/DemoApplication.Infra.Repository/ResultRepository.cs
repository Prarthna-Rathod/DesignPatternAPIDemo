using DemoApplication.Infra.Contract;
using DemoApplication.Infra.Domain;
using DemoApplication.Infra.Domain.Entities;
using DemoApplication.Shared;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Infra.Repository
{
    public class ResultRepository: IResultRepository
    {
        private readonly StudResultDBContext _context;

        public ResultRepository(StudResultDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddResult(Result result)
        {
            _context.results.AddAsync(result);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedList<Result>> GetResults(string searchTerm = null, int page = 1,int pageSize = 25)
        {
            try
            {
                var results = _context.results.Include(x => x.student).Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).AsQueryable();
                var results1 = _context.results.Include(x => x.student).Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();
            
                if(!string.IsNullOrEmpty(searchTerm))
                {
                    results = results.Where(x =>
                    EF.Functions.Like(x.student.Name, $"%{searchTerm}%")
                    );
                }

                var count = await results.LongCountAsync();
                var pagedList = results.ToPagedList(page, pageSize, count);

                return pagedList;
            
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Result?> GetResult(int resultId)
        {
            var result = await _context.results.FirstOrDefaultAsync(x => x.Id == resultId);
            return result;
        }

        public async Task<int> UpdateResult(Result res)
        {
            _context.results.Update(res);
            return await _context.SaveChangesAsync();
        }

        public async Task<string> DownloadResultFile(int resultId)
        {
            var data = await _context.results.FindAsync(resultId);
            var file = data.uploadFile;
            return file.ToString();
        }
    }
}