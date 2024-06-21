using MarketAPI.Extensions;
using MarketAPI.Data;
using Microsoft.EntityFrameworkCore;
using MarketAPI.Middleware;
using Microsoft.AspNetCore.Identity;
using MarketAPI.Entities;
using api.Extensions;

var builder = WebApplication.CreateBuilder(args);


var connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(connString);
});
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddIdentityServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();



var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var role = new List<AppRole>
    {
        new AppRole { Name = "User" },
        new AppRole { Name = "Client" },
    };
    foreach (var item in role)
    {
        var roleExists = await roleManager.RoleExistsAsync(item.Name);
        if (!roleExists)
        {
            await roleManager.CreateAsync(item);
        }
    }

}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Problem");
}

app.Run();
