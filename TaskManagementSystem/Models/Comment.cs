namespace TaskManagementSystem.Models{
    public class Comment
    {
        public int Id {get; set;}
        public string Text {get; set;}
        public DateTime Created {get; set;}
        public int WorkItemId {get; set;}
        public int UserId {get; set;}
        public WorkItem WorkItem {get; set;}
        public UserModel User {get; set;}

    }
}