namespace Gmc.Api.DTOs.Ministries
{
    public record CreateSmallGroupRequest(
        long? MinistryId, 
        string Name, 
        string? Description, 
        string? MeetingDay, 
        TimeOnly? MeetingTime, 
        string? Location, 
        long? LeaderMemberId
        );
}
