using DemoApplication.Core.Contract;
using DemoApplication.Core.Service;
using DemoApplication.Core.Service.Helper;
using DemoApplication.Infra.Contract;
using DemoApplication.Infra.Repository;


namespace APIDemo.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<IResultRepository, ResultRepository>();
            //services.AddTransient<IAmazonS3>(options => new AmazonS3Client(configuration["AWS:S3:AccessKey"], configuration["AWS:S3:SecretKey"], RegionEndpoint.APSouth1));
            services.AddAutoMapper(typeof(AutoMapperProfiler));
            services.AddTransient<FileUploadHelper>();
        }
    }
}
