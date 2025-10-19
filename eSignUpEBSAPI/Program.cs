using eSignUpEBSAPI.Data;
using eSignUpEBSAPI.Interfaces;
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

//Add Services Here
builder.Services.AddScoped<ICandidateService, CandidateService>();

//Get connection string elements to asemble
var databaseSettings = builder.Configuration.GetSection("DatabaseConnection");
var server = databaseSettings["Server"];
var database = databaseSettings["Database"];
var useWindowsAuth = databaseSettings.GetValue<bool>("UseWindowsAuth");
var username = databaseSettings["Username"];
var password = databaseSettings["Password"];

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));

//Comment out for EF Core updates
var connectionStringExtra = "";
connectionStringExtra += "Server=" + server + ";";
connectionStringExtra += "Database=" + database + ";";
connectionStringExtra += "User ID=" + username + ";";
connectionStringExtra += "Password=" + password + ";";

//conStrBuilder.DataSource = server;
//conStrBuilder.InitialCatalog = database;

if (useWindowsAuth == true)
{
    conStrBuilder.IntegratedSecurity = useWindowsAuth;
}
else
{
    conStrBuilder.UserID = username;
    conStrBuilder.Password = password;
}
//End Comment out for EF Core updates

var connectionString = connectionStringExtra + conStrBuilder.ConnectionString;

Console.WriteLine(connectionString);
//Console.ReadKey();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


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
