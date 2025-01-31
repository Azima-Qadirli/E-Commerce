using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MiniE_Commerce.Application.Services;

namespace MiniE_Commerce.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Read, FileShare.None, 1024 * 1024, useAsync: false);
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Task<string> FileRenameAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> data = new();
            List<bool> results = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(file.FileName);

                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                data.Add((fileNewName, $"{uploadPath}\\{fileNewName}");
                results.Add(result);
            }
            if (results.TrueForAll(r => r.Equals(true)))
                return data;
            return null;
        }
    }
}
