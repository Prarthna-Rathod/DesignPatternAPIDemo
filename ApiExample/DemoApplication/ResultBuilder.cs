using DemoApplication.Core.Domain.RequestModel;
using DemoApplication.Infra.Domain.Entities;
using DemoApplication.Core.Domain.RequestModel;

namespace DemoApplication.Core.builder
{
    public class ResultBuilder
    {
        public static Result Build(ResultRequestModel model,string fileKey ,string createdByUserId = "")
        {
            return new Result(model.m1, model.m2, model.m3, model.StudentId, fileKey);
        }
    }
}
