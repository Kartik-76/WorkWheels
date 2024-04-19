using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Models;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Classes;
using RideSharingPlatform.UserVerification.Business_Logic_Layer__BLL_.Services.Interfaces;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Classes;
using RideSharingPlatform.UserVerification.Data_Access_Layer__DAL_.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();
builder.Services.AddScoped<IUserApplicationRepo, UserApplicationRepo>();

builder.Services.AddDbContext<RideSharingPlatformContext>
    (item => item.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
