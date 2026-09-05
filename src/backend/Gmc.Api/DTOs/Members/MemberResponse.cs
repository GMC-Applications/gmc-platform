namespace Gmc.Api.DTOs.Members
{
    public record MemberResponse(
        long Id, 
        long? UserId, 
        string FirstName, 
        string LastName, 
        string? Email, 
        string? Phone, 
        DateOnly? DateOfBirth, 
        string MembershipStatus
        );
}
