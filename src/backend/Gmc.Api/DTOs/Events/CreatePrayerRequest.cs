namespace Gmc.Api.DTOs.Events
{
    public record CreatePrayerRequest(
        string? Name, 
        string Request, 
        bool Anonymous
        );
}
