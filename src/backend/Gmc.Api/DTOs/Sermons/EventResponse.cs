namespace Gmc.Api.DTOs.Sermons
{
    public record EventResponse(
        long Id, 
        string Title, 
        string? Description, 
        string? Location, 
        DateTime StartsAt, 
        DateTime? EndsAt, 
        int? Capacity, 
        string Status
        );
}
