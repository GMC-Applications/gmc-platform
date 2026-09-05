namespace Gmc.Api.Models
{
    public class ConnectionSubmission : Entity { 
        public string Name { get; set; } = ""; 
        public string Email { get; set; } = ""; 
        public string Interest { get; set; } = ""; 
        public string Message { get; set; } = ""; 
        public string Status { get; set; } = "New"; 
    }
}
