using  Microsoft.Extensions.Options;

namespace Quartz
{
    public class MyJobSetup : IConfigureOptions<QuartzOptions>

    {
        public void Configure(QuartzOptions options)
        {

            // Создание задания
            var jobKey = new JobKey("myJob");
            options.AddJob<MyBackgroundJob>(opts => opts.WithIdentity(jobKey));

            // Создание триггера
            options.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("myJob-trigger")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithInterval(TimeSpan.FromSeconds(10)) // Интервал выполнения
                    .RepeatForever())); // Повторять бесконечно

        }
    }
}
