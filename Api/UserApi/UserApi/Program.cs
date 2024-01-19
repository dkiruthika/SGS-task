using Microsoft.EntityFrameworkCore;
using Serilog;
using UserApi.Data;
using UserApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<ILoginService, LoginService>();
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());  

app.UseAuthorization();

app.MapControllers();

app.Run();
