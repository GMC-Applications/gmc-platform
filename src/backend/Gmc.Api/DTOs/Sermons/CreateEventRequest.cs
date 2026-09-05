namespace Gmc.Api.DTOs.Sermons
{
    public record CreateEventRequest(
        string Title, 
        string? Description, 
        string? Location, 
        DateTime StartsAt, 
        DateTime? EndsAt, 
        int? Capacity, 
        bool RegistrationRequired
        );
}
