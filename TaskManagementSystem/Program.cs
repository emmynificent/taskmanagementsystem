using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddScoped<IWorkItem, WorkRepository>();
builder.Services.AddScoped<IProject, ProjectRepository>();
builder.Services.AddScoped<IUserModel, UserRepository>();
builder.Services.AddScoped<INotification, NotificationRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Add

//builder.Services.AddDbContext<TaskManagementSystemDbContext> (options =>)
builder.Services.AddDbContext<TaskManagementDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskConnectionString"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseSwagger();
{
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.UseHttpsRedirection();


app.Run();


