using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;
using WebChat.Server.Mappers;
using WebChat.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChatContext>(x => x.UseSqlite("Data Source=app-data.db"));

builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(MappingUser), typeof(ChatroomMapper), typeof(MessageMapper), typeof(UserMapper));

builder.Services.AddMediatR(mediatr =>
{
    mediatr.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddScoped(typeof(ChatroomService));
builder.Services.AddScoped(typeof(UserService));
builder.Services.AddScoped(typeof(MessageService));

builder.Services.AddScoped(typeof(ChatroomRepository));
builder.Services.AddScoped(typeof(UserRepository));
builder.Services.AddScoped(typeof(MessageRepository));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();