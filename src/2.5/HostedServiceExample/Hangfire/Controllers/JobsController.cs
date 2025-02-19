using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Controllers
{
	using Hangfire;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("[controller]")]
	public class JobsController : ControllerBase
	{
		private readonly IBackgroundJobClient _backgroundJobClient;

		public JobsController(IBackgroundJobClient backgroundJobClient)
		{
			_backgroundJobClient = backgroundJobClient;
		}

		[HttpPost("send-email")]
		public IActionResult SendEmail()
		{
			// «апланировать выполнение фоновой задачи
			_backgroundJobClient.Enqueue<BackgroundJobs>(job => job.SendEmail());
			return Ok("Email job has been enqueued.");
		}

		[HttpPost("process-data")]
		public IActionResult ProcessData()
		{
			// «апланировать выполнение фоновой задачи
			_backgroundJobClient.Enqueue<BackgroundJobs>(job => job.ProcessData());
			return Ok("Data processing job has been enqueued.");

		}



		[HttpPost("fire-and-forget")]
		public IActionResult FireAndForget()
		{
			string jobId = BackgroundJob.Enqueue(() => Console.WriteLine("!!!"));

			return Ok(jobId);
		}

		[HttpPost("delayed")]
		public IActionResult Delayed()
		{
			string jobId = BackgroundJob.Schedule(
				() => Console.WriteLine("!!!"),
			TimeSpan.FromSeconds(60));

			return Ok(jobId);
		}

		[HttpPost("recurring")]
		public IActionResult Recurring()
		{
			RecurringJob.AddOrUpdate("job-id", () => Console.WriteLine("!!!"), Cron.Daily);

			return Ok();
		}

		[HttpPost("continuations")]
		public IActionResult Continuations()
		{
			string jobId = BackgroundJob.Enqueue(() => Console.WriteLine("!!!"));
				
			BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("!!!"));

			return Ok();
		}
	}
}
		
