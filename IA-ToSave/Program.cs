using IA_ToSave.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        Policy =>
        {
            Policy.WithOrigins("http://localhost:4200"
                ).AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<IaToSaveContext>(options => options.UseSqlServer("Server=PCGAMERNOVAXD\\SQLEXPRESS;Database=IA-ToSave;Trusted_Connection=True;MultipleActiveResultSets=true"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
