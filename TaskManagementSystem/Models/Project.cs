namespace TaskManagementSystem.Models
{

    public class Project
    {
        public int Id {get; set;}
        public string ProjectName {get; set;}
        public List<WorkItem>? WorkItems {get; set;} = new List<WorkItem>();     
    }
}
