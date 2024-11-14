using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MainTravel.Application.Services
{
    public class FileService : IFileService
    {
        private readonly string MEDIA = "media";
        private readonly string IMAGES = "images";
        private readonly string ROOTPATH;

        public FileService(IWebHostEnvironment env)
        {
            ROOTPATH = env.WebRootPath;
        }

        public async Task<bool> DeleteImageAsync(string subpath)
        {
            string path = Path.Combine(ROOTPATH, subpath);
            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });
                return true;
            }
            return false;
        }

        public async Task<string> UplaodImageAsync(IFormFile file)
        {
            string newImageName = MediaHelper.MakeImageName(file.FileName);
            string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
            string path = Path.Combine(ROOTPATH, subpath);

            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Close();

            return subpath;
        }
    }
}