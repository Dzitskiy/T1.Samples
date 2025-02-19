namespace Hangfire
{
public class BackgroundJobs
   {
       public void SendEmail()
       {
           // Логика отправки email
           Console.WriteLine($"Email sent at {DateTime.Now}");
       }

       public void ProcessData()
       {
           // Логика обработки данных
           Console.WriteLine($"Data processed at {DateTime.Now}");
       }
   }
    }
