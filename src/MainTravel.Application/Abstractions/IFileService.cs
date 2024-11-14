using Microsoft.AspNetCore.Http;

namespace MainTravel.Application.Abstractions
{
    public interface IFileService
    {
        public Task<string> UplaodImageAsync(IFormFile file);

        public Task<bool> DeleteImageAsync(string subpath);
    }
}