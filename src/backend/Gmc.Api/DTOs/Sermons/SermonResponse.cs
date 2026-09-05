namespace Gmc.Api.DTOs.Sermons
{
    public record SermonResponse(
        long Id, 
        string Title, 
        string? Description, 
        string? Speaker, 
        DateOnly SermonDate, 
        string? VideoUrl, 
        string? AudioUrl, 
        string Status
        );
}
