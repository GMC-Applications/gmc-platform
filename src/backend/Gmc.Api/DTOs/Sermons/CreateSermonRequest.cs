namespace Gmc.Api.DTOs.Sermons
{
    public record CreateSermonRequest(
        string Title, 
        string? Description, 
        string? Speaker, 
        DateOnly SermonDate, 
        string? VideoUrl, 
        string? AudioUrl, 
        string? ThumbnailUrl
        );
}
