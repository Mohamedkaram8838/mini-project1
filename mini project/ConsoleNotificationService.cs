
namespace mini_project
{
    public class ConsoleNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}