namespace Gmc.Api.DTOs.Auth
{
    public record UserResponse(
        long Id, 
        string FullName, 
        string Email, 
        string Role, 
        string Status
        );
}
