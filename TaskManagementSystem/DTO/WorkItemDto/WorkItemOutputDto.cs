namespace TaskManagementSystem.DTO
{
    public class WorkItemOutputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string status {get; set;}
        public string AssignedUser {get; set;}  
        public string comments {get; set;}
    }
}