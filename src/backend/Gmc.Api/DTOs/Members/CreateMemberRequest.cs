namespace Gmc.Api.DTOs.Members
{
    public record CreateMemberRequest(
        string FirstName, 
        string LastName, 
        string? Email, 
        string? Phone,
        DateOnly? DateOfBirth, 
        string? Address
        );
}
