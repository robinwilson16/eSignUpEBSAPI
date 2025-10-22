using eSignUpEBSAPI.Data;
using eSignUpEBSAPI.Helpers;
using eSignUpEBSAPI.Interfaces;
using eSignUpEBSAPI.Models;
using eSignUpEBSAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Add Graph API
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Services Here
builder.Services.AddScoped<ICandidateService, CandidateService>();

// Database Connections
string? connectionStringMIS = DatabaseHelper.GetConnectionString("DatabaseConnectionMIS", builder.Configuration);
string? connectionStringESignUp = DatabaseHelper.GetConnectionString("DatabaseConnectionESignUp", builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionStringMIS));

builder.Services.AddDbContext<ExportCandidatesDbContext>(options =>
    options.UseSqlServer(connectionStringESignUp));

//Allow access from another URL
var origins = builder.Configuration.GetSection("APIEndpoints").Get<string[]>();

builder.Services.AddCors(options =>
    options.AddPolicy("origins",
        policy =>
        {
            policy.WithOrigins(origins ?? Array.Empty<string>())
            .AllowAnyHeader()
            .AllowAnyMethod();
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("eSignUp EBS API")
        .WithTheme(ScalarTheme.Mars)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    //.WithPreferredScheme("ApiKey")
    //.WithApiKeyAuthentication(keyOptions => keyOptions.Token = "apikey");
});

//}

// Ensure exception middleware is registered early so it can catch controller exceptions
// Use DeveloperExceptionPage in Development, custom JSON middleware in non-Dev
if (app.Environment.IsDevelopment())
{
    //Better for displaying error messages when API called from browser
    //app.UseDeveloperExceptionPage();

    //Better for displaying error messages when API called from Scalar
    app.UseMiddleware<eSignUpEBSAPI.Middlewares.ExceptionMiddleware>();
}
else
{
    app.UseMiddleware<eSignUpEBSAPI.Middlewares.ExceptionMiddleware>();
}

app.UseHttpsRedirection();

app.UseCors("origins"); //Enable cors access using URLs above

//Add Graph API
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
