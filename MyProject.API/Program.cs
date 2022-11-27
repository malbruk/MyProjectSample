using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.API;
using MyProject.API.Middlewares;
using MyProject.Context;
using MyProject.Mock;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(opt => opt.AddPolicy("PolicyName", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
//builder.Services.AddSingleton<IContext, MockContext>();
//builder.Services.AddDbContext<IContext, DataContext>(options => options.UseSqlServer("name=ConnectionStrings:MyProjectDB"));
builder.Services.AddDbContext<IContext, DataContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyProjectDB;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PolicyName");

app.UseAuthorization();

//app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/auth"), appBuilder => HandleAuth(appBuilder));

//app.Use(async (context, next) =>
//{
//    var requestSeq = Guid.NewGuid().ToString();
//    app.Logger.LogInformation($"Request Starts {requestSeq}");
//    context.Items.Add("RequestSeqence", requestSeq);
//    await next.Invoke();
//    app.Logger.LogInformation($"Request ends {requestSeq}");
//});
app.UseTrack();
//app.UseAuth();

app.MapControllers();

app.Logger.LogInformation("Run App");
app.Run();


//static void HandleAuth(IApplicationBuilder app)
//{
//    app.Use(async (context, next) =>
//    {
//        await next(context);
//    });
//}