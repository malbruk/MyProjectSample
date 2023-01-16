using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyProject.API.Middlewares;
using MyProject.Context;
using MyProject.Mock;
using MyProject.Repositories;
using MyProject.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
        
// Add services to the container.

builder.Services.AddCors(opt => opt.AddPolicy("PolicyName", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddServices();
//builder.Services.AddSingleton<IContext, MockContext>();
builder.Services.AddDbContext<IContext, DataContext>(options => options.UseSqlServer("name=ConnectionStrings:MyProjectDB"));
//Console.WriteLine(builder.Configuration["ConnectionStrings:AWS_DB"]);
//builder.Services.AddDbContext<IContext, DataContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:AWS_DB"]));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("PolicyName");

app.UseAuthentication();

app.UseAuthorization();

//app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/auth"), appBuilder => HandleAuth(appBuilder));

//app.Use(async (context, next) =>
//{
//    var requestSeq = Guid.NewGuid().ToString();
//    app.Logger.LogInformation($"Request Starts {requestSeq}");
//    context.Items.Add("RequestSeqence", requestSeq);
//    await next(context);
//    //await next.Invoke();
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