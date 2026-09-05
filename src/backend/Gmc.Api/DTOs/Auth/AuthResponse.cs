namespace Gmc.Api.DTOs.Auth
{
    public record AuthResponse(
        string AccessToken, 
        string RefreshToken, 
        UserResponse User
        );
}
