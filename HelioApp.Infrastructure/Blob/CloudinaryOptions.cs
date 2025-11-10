namespace HelioApp.Infrastructure.Blob;

public sealed class CloudinaryOptions
{
    public string ApiSecret { get; set; } = default!;
    public string ApiKey { get; set; } = default!;
    public string Cloud { get; set; } = default!;
}