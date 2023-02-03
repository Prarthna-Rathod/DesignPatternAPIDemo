using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using Microsoft.AspNetCore.Http;

namespace DemoApplication.Core.Service.Helper
{
    public class FileUploadHelper
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
                Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
                cloudinary.Api.Secure = false;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = true
                };

                var x = cloudinary.Upload(uploadParams);
                //Console.WriteLine(x.JsonObj);

                var url = x.Url.ToString();

                return url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }
    }
}
