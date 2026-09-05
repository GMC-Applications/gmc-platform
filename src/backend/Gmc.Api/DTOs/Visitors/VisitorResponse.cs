namespace Gmc.Api.DTOs.Visitors
{
    public record VisitorResponse(
        long Id, 
        string FirstName, 
        string LastName, 
        string? Email, 
        string? Phone, 
        DateOnly VisitDate, 
        string Status
        );
}
