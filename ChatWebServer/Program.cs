using ChatWebServer.DAL;
using ChatWebServer.Hubs;
using ChatWebServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MessageStoreDBSettings>(
    builder.Configuration.GetSection("MessageStoreDatabase")); 
builder.Services.AddSingleton<MessagesService>();
builder.Services.AddSingleton<ChatManager>();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(o =>
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CommunicationHub>("/hubLink");
});
app.Run();
