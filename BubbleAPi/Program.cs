using BubbleAPi;
using BubbleAPi.Domain;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Interfaces;
using BubbleAPi.Services;
using CreateInterfaceWithConnections.Injections;
using Doopinger;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(x => x.AddFile("Logs/mylog-{Date}.txt", LogLevel.Error));

builder.Services.AddScoped<ICourse,CourseService>();
builder.Services.AddScoped<ICourseReport,CourseReportService>();
builder.Services.AddScoped<IUser,UserService>();

builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddDbContext<CourseDbContext>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<Response>();



builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audince"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };

});

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

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id="Bearer"},
                //Scheme = "oauth2",
                //Name = "Bearer",
                //In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseUML();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();