using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    public class WorkItem
    {
        public int Id {get; set;}
        public required string Title {get; set;}
        public string? Description {get; set;} = "Task description";
        public Status status {get; set;} = Status.New;
        public DateTime DueDate {get; set;}
        public string? AssignedUserId {get; set;} = null;
        public UserModel? AssignedUser {get; set;} = null;
        public List<Comment>? comments {get; set;} = null ;
        public int? projectId {get; set;}
        
        //would come bac to this below
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