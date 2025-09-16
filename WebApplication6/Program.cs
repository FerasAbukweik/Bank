using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes("mdkfa#&$(*1u8fhq(Q@(hfngoaoa892#*(@hufiai"); // Define the secret key
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // The Source Where The Token Is Issued
            ValidateAudience = false, // The Users Whome Can Use This Token
            ValidateIssuerSigningKey = true, // Make Sure That The Token Is Using My Secret Key
            IssuerSigningKey = new SymmetricSecurityKey(key), // Generate The Token Using Our Key
  ������};
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<DBcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Bank")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
