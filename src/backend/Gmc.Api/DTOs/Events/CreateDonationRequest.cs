namespace Gmc.Api.DTOs.Events
{
    public record CreateDonationRequest(
        decimal Amount, 
        string Currency, 
        string Category, 
        string? DonorName, 
        string? DonorEmail
        );
}
