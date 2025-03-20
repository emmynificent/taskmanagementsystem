namespace TaskManagementSystem.Models
{
    public class AuditLogModel
    {
        public int Id {get; set;}
        public string Action {get; set;}
        public DateTime TimeStamp {get; set;}
        public int? UserId {get; set;}
        public UserModel User {get; set;} = null;
        public int? WorkItemId{get; set;} 
        public WorkItem WorkItem {get; set;} = null;
    }
}