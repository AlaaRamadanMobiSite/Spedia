using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
namespace Spedia.UploadFiles
{
    public class UploadImage : IUploadImage
    {
        private readonly IWebHostEnvironment _environment;
        public UploadImage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string post_file(IFormFile file)
        {
            if (!Directory.Exists(_environment.WebRootPath + "//Images_Server//"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "//Images_Server//");
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string newFilePath = "/Images_Server/" + fileName;

            using (FileStream filestrem = System.IO.File.Create(_environment.WebRootPath + newFilePath))
            {
                file.CopyTo(filestrem);
                filestrem.Flush();
                return newFilePath;
            }

        }
    }
}
