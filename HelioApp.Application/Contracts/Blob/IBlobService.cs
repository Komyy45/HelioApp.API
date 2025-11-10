using Microsoft.AspNetCore.Http;

namespace HelioApp.Application.Contracts.Blob;

public interface IImageService
{
    public Task<string> UploadImage(IFormFile image);
    public Task<bool> DeleteImage(string publicId);
}