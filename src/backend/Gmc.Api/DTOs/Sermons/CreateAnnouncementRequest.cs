namespace Gmc.Api.DTOs.Sermons
{
    public record CreateAnnouncementRequest(
        string Title, 
        string Body, 
        string? ImageUrl, 
        string? TargetRole, 
        long? MinistryId, 
        DateTime? ScheduledAt
        );
}
