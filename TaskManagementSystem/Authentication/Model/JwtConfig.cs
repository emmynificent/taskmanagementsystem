namespace TaskManagementSystem.Authentication.Model
{
    public class JwtConfig
    {
        public string? Secret {get; set;}
        public string? ValidAudience{get; set;}
        public string? ValidIssuer {get; set;}
    }
}