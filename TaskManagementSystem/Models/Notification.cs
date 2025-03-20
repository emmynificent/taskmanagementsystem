namespace TaskManagementSystem.Models
{
    public class Notification
    {
        public int Id {get; set;}
        public string NoticeMessage {get; set;}
        public DateTime NoticeCreated {get; set;}
        public bool IsRead {get; set;} = false;
        public int UserId {get; set;}
        public UserModel? User {get; set;}
    }
}