using Microsoft.EntityFrameworkCore;
using StudentFrom.Models;
using StudentFrom.Controllers;
using StudentFrom.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("variable")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var _policyName = "APolicy";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: _policyName,
    policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapCourseEndpoints();
//Cors policy


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(_policyName);

//var _policyName = "GeeksPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: _policyName,
//    policy =>
//    {
//        policy.WithOrigins("https://localhost:44398")
//            .WithMethods("PUT", "DELETE", "GET");
//    });
//});
app.Run();



