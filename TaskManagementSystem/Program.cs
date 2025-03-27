using System.Text;
using TaskManagementSystem.Authentication.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskManagementSystem.Authentication;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddScoped<IWorkItem, WorkRepository>();
builder.Services.AddScoped<IProject, ProjectRepository>();
builder.Services.AddScoped<IUserModel, UserRepository>();
builder.Services.AddScoped<INotification, NotificationRepository>();



builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Add

//builder.Services.AddDbContext<TaskManagementSystemDbContext> (options =>)
builder.Services.AddDbContext<TaskManagementDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskConnectionString"));
    options.ConfigureWarnings(w =>
    w.Ignore(RelationalEventId.PendingModelChangesWarning));

});

builder.Services.AddIdentity<UserModel,  IdentityRole>()
.AddEntityFrameworkStores<TaskManagementDbContext>()
.AddDefaultTokenProviders();


builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var jwtConfig =  builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

    options.TokenValidationParameters = new TokenValidationParameters{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = jwtConfig.ValidIssuer,
    ValidAudience = jwtConfig.ValidAudience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jwtConfig.Secret"))
    };

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


//we would be focusing on the WorkItem and the Project and the User part. Notifications and the other models would be integrated as we go on.
