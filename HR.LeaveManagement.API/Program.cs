

using HR.LeaveManagement.Application;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Services;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
//TODO:Extract this services registration in separate class
builder.Services.AddTransient<ILeaveAllocationService,LeaveAllocationService>();
builder.Services.AddTransient<ILeaveTypesService, LeaveTypesService>();
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
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
