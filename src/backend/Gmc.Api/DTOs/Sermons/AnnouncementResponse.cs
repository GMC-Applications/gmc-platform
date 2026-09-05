namespace Gmc.Api.DTOs.Sermons
{
    public record AnnouncementResponse(
        long Id, 
        string Title, 
        string Body, 
        string Status, 
        DateTime? ScheduledAt, 
        DateTime? PublishedAt
        );
}
