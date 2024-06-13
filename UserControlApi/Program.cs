using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using UserControlApi.Data;
using UserControlApi.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserControlDbContext>(options =>
                    options.UseMySQL(builder.Configuration["ConnectionStrings:UserControlDbContextConnection"]));

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<UserControlDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICadastraUsuarioService, CadastraUsuarioService>();
builder.Services.AddScoped<ILoginUsuarioService, LoginUsuarioService>();
builder.Services.AddScoped<TokenService, TokenService>();

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
