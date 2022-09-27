using Bcm.BcmAir.Booking.Api.Configuration;
using Bcm.BcmAir.Booking.Api.Infrastructure.Repositories;
using Bcm.BcmAir.Infrastructure.Common.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddControllers().AddDapr();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<SettingsRoot>(builder.Configuration);
builder.Services.AddScoped<IBookingsRepository, BookingsRepository>();
builder.Services.AddServiceBus();

var app = builder.Build();
app.UseCloudEvents();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapSubscribeHandler();

app.Run();
