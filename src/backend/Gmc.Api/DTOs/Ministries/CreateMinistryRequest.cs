namespace Gmc.Api.DTOs.Ministries
{
    public record CreateMinistryRequest(
        string Name, 
        string? Description, 
        string? ImageUrl
        );
}
