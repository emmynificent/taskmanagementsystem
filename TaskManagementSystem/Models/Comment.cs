namespace TaskManagementSystem.Models{
    public class Comment
    {
        public int Id {get; set;}
        public string Text {get; set;}
        public DateTime Created {get; set;}
        public int? WorkItemId {get; set;} = null;
        public string ?UserId {get; set;} = null;
        public WorkItem? WorkItem {get; set;} =null;
        public UserModel? User {get; set;} = null;

    }
}