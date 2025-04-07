using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<EmployeesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbConnection")));

// Configurar CORS
var allowedOrigins = "AllowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5174") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddControllers();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"],
        Version = builder.Configuration["Swagger:Version"],
        Description = builder.Configuration["Swagger:Description"]
    });
});

var app = builder.Build();


app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/swagger/index.html", permanent: false);
    return Task.CompletedTask;
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API v1");
    });
}


app.UseHttpsRedirection();

    
app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
