using Database;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LabelDbContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"))
    );

builder.Services.AddScoped<ILabelTypeService, LabelTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRolesService, RoleService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
