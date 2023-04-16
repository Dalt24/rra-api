using System;
using api_rra1.ClassModels;
using api_rra1.ClassModels.Database;
using api_rra1.ClassModels.Database.AppointmentFunctions;
using api_rra1.ClassModels.Database.TherapistFunctions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if we update the class models, drop the table & make a new one so data isn't stale

// DeleteUser.DropUserTable();
// SaveUser.CreateUserTable();

// SaveTherapist.CreateTherapistTable();


// SaveAppointment.CreateAppointmentTable();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("OpenPolicy");

app.MapControllers();

app.Run();
