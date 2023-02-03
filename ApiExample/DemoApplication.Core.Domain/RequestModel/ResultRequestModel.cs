using Microsoft.AspNetCore.Http;

namespace DemoApplication.Core.Domain.RequestModel
{
    public record ResultRequestModel
    {
        public int m1 { get; set; }
        public int m2 { get; set; }
        public int m3 { get; set; }
        public int StudentId { get; set; }

        public IFormFile uploadFile { get; set; }

    }
}
