using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TaskWebApi.Context;
using TaskWebApi.Repository;
using TaskWebApi.Repository.IRepository;
using TaskWebApi.Services;
using TaskWebApi.Services.Maps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//crear variable para la cadena de conexion
var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Registrar servicio para la conexion
builder.Services.AddDbContext<TaskDbContext>(options =>options.UseSqlServer(conectionString));

//Definir politicas de cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin() //para permitir cualquier origen
            .AllowAnyMethod() // para permitir cualquier metodo
            .AllowAnyHeader(); // para permitir cualquier cabecera
        });
});

//registrar mapper
builder.Services.AddAutoMapper(typeof(UserMap));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<IAccessloginRepository, LoginRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TodosService>();
builder.Services.AddScoped<ITodosRepository, TodosRepository>();

// 🔐 Configurar JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidIssuer = jwtSettings["Issuer"],
//        ValidateAudience = true,
//        ValidAudience = jwtSettings["Audience"],
//        ValidateLifetime = true
//    };
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configurar autenticación JWT
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

builder.Services.AddSwaggerGen(options=>
{
    options.EnableAnnotations(); //habilitar las anotaciones en el swagger

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskWebApi", Version = "v1" });

    // Agrega la seguridad para JWT en Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT en el formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    // Aplicar seguridad a todas las rutas protegidas
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
