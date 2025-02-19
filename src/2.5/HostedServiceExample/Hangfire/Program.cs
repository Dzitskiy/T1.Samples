using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Настройка Hangfire для использования SQL Server
builder.Services.AddHangfire(config =>

    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddHangfireServer();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Использование Hangfire Dashboard
app.UseHangfireDashboard("/dashboard");

//app.UseHangfireDashboard("/dashboard");
//app.UseHangfireServer();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
