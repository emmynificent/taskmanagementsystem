using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    public class WorkItem
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;} 
        public Status status {get; set;}
        public DateTime DueDate {get; set;}
        public int? AssignedUserId {get; set;} = null;
        public UserModel? AssignedUser {get; set;} = null;
        public List<Comment>? comments {get; set;} = null ;
        public int? projectId {get; set;}

        [JsonIgnore]
        public Project? Project {get;set;}
    }

    public enum Status{
        New,
        Open,
        InProgress,
        Completed
    }
}