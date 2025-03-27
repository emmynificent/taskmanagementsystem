namespace TaskManagementSystem.DTO
{
    public class WorkItemInputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string status {get; set;}
        public int projectId {get; set;}
       // public string AssignedUser {get; set;}  
        //public string comments {get; set;}
    }
}