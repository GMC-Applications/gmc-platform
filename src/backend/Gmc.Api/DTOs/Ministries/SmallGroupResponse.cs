namespace Gmc.Api.DTOs.Ministries
{
    public record SmallGroupResponse(
        long Id, 
        string Name, 
        string? Description, 
        string? MeetingDay, 
        TimeOnly? MeetingTime, 
        string? Location, 
        long? LeaderMemberId
        );
}
