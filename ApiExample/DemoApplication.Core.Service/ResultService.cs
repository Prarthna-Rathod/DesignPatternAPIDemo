using AutoMapper;
using DemoApplication.Core.builder;
using DemoApplication.Core.Contract;
using DemoApplication.Core.Domain.Exceptions;
using DemoApplication.Core.Domain.RequestModel;
using DemoApplication.Core.Domain.ResponseModel;
using DemoApplication.Core.Service.Helper;
using DemoApplication.Infra.Contract;
using DemoApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Core.Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;
        private readonly FileUploadHelper _fileuploadhelper;

        public ResultService(IResultRepository resultRepository, IMapper mapper, FileUploadHelper fileuploadhelper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
            _fileuploadhelper = fileuploadhelper;
        }

        public async Task AddResultAsync(ResultRequestModel resultModel)
        {
            try
            {
                var fileKey = await _fileuploadhelper.UploadFile(resultModel.uploadFile);
                var result = ResultBuilder.Build(resultModel, fileKey);
                var count = await _resultRepository.AddResult(result);

                if (count == 0)
                {
                    throw new BadRequestException("Result is not created successfully");
                }    
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedList<ResultResponseModel>> GetResultsAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var results = await _resultRepository.GetResults(searchTerm, page, pageSize);
                var result= _mapper.Map<PagedList<ResultResponseModel>>(results);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteResultAsync(int resultid)
        {
            try
            {
                var result = await _resultRepository.GetResult(resultid);

                if(result == null)
                {
                    throw new NotFoundException($"Result with {resultid} is not found");
                }

                result.Delete();
                var count = await _resultRepository.UpdateResult(result);

                if(count == 0)
                {
                    throw new BadRequestException("Result is not updated succssfully");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<string> DownloadFile(int resultId)
        {
            try
            {
                var result = await _resultRepository.DownloadResultFile(resultId);
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
