
namespace Quartz
{
    public class MyBackgroundJob : IJob
        
    {

        public Task Execute(IJobExecutionContext context)
        {

            Console.WriteLine($"Job executed at: {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
