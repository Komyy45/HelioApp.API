using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HelioApp.Application.Contracts.Blob;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HelioApp.Infrastructure.Blob;

internal sealed class CloudinaryImageService : IImageService
{
    private readonly Cloudinary _cloudinary;
    
    public CloudinaryImageService(IOptions<CloudinaryOptions> cloudinaryOptions)
    {
        var options = cloudinaryOptions.Value;
        
        Account account = new Account()
        {
            ApiKey = options.ApiKey,
            ApiSecret = options.ApiSecret,
            Cloud = options.Cloud
        };
        
        _cloudinary = new Cloudinary(account)
        {
            Api =
            {
                Secure = true
            }
        };
    }
    
    public async Task<string> UploadImage(IFormFile image)
    {
        if (image is null || image.Length <= 0)
            throw new InvalidDataException("Image cannot be null or empty.");

        var imageUploadParams = new ImageUploadParams()
        {
            File = new FileDescription(image.FileName, image.OpenReadStream()),
            PublicId = Guid.NewGuid().ToString()
        };

        var uploadResult = await _cloudinary.UploadAsync(imageUploadParams);

        if (uploadResult.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Image upload failed: {uploadResult.Error?.Message}");

        return uploadResult.SecureUrl.ToString();
    }

    public Task<bool> DeleteImage(string publicId)
    {
        throw new NotImplementedException();
    }
}