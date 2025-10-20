namespace TaskManagementSystem.Interface
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string ReceiverEmail, string subject, string body);
    }
}