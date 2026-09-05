namespace Gmc.Api.DTOs.Visitor
{
    public record CreateVisitorRequest(
        string FirstName, 
        string LastName, 
        string? Email, 
        string? Phone, 
        DateOnly? VisitDate, 
        string? Notes
        );
}
