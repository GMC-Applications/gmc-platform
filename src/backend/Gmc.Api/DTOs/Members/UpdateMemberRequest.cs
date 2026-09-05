namespace Gmc.Api.DTOs.Members
{
    public record UpdateMemberRequest(
        string FirstName, 
        string LastName, 
        string? Email, 
        string? Phone, 
        DateOnly? DateOfBirth, 
        string? Address, 
        bool CommunicationConsent
        );
}
