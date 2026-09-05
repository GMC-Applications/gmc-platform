namespace Gmc.Api.DTOs.Ministries
{
    public record MinistryResponse(
        long Id, 
        string Name, 
        string? Description, 
        string? ImageUrl, 
        bool Active, 
        int MemberCount
        );
}
