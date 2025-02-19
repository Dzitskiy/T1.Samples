using Quartz;
using Quartz.Impl;
using Quartzmin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� Quartz
builder.Services.AddQuartz(q =>
{

    //// �������� �������
    //var jobKey = new JobKey("myJob");
    //q.AddJob<MyBackgroundJob>(opts => opts.WithIdentity(jobKey));

    //// �������� ��������
    //q.AddTrigger(opts => opts
    //    .ForJob(jobKey)
    //    .WithIdentity("myJob-trigger")
    //    .StartNow()
    //    .WithSimpleSchedule(x => x
    //        .WithInterval(TimeSpan.FromSeconds(10)) // �������� ����������
    //        .RepeatForever())); // ��������� ����������

});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);



builder.Services.ConfigureOptions<MyJobSetup>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
