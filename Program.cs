using IA_ToSave_Project.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200"
                                ).AllowAnyHeader()
                                //deja consumir todos los metodos
                                //.WithMethods("Get");
                                                  .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddDbContext<IaToSaveContext>(options => options.UseSqlServer("Server=BYTECSCRIPT\\SQLEXPRESS;Database=IA_ToSave;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddControllers();
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
//agg el app usecors
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
