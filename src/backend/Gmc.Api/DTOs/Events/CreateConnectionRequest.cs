namespace Gmc.Api.DTOs.Events
{
    public record CreateConnectionRequest(
        string Name, 
        string? Email, 
        string? Interest, 
        string? Message
        );
}
