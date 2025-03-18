using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace TaskManagementSystem.Models
{
    public class UserModel
    {
        public int Id {get; set;}
        public string FullName {get; set; }
        public string Email {get; set;}
        public DateTime Created {get; set;} = DateTime.Now;
        public List<WorkItem> WorkItems {get; set;}
        //public bool Completed {get; set;} = false;
    }        
}