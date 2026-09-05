namespace Gmc.Api.DTOs.Events
{
    public record PrayerResponse(
        long Id, 
        string? Name, 
        string Request, 
        bool Anonymous, 
        string Status, 
        DateTime CreatedAt
        );
}
