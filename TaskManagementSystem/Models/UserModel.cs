using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace TaskManagementSystem.Models
{
    public class UserModel : IdentityUser
    {
        public string? FullName {get; set; }
        public DateTime Created {get; set;} = DateTime.Now;
        public List<WorkItem> WorkItems {get; set;}
        //public bool Completed {get; set;} = false;
    }        
}