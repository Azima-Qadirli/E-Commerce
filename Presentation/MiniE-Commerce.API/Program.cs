using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using MiniE_Commerce.Application;
using MiniE_Commerce.Application.Validators.Products;
using MiniE_Commerce.Infrastructure;
using MiniE_Commerce.Infrastructure.Filters;
using MiniE_Commerce.Infrastructure.Services.Storage.Local;
using MiniE_Commerce.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

//Adding Services
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

//Adding Storage
builder.Services.AddStorage<LocalStorage>();

//Adding FluentValidation
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<CreateProductValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Admin")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,//The value of the token to be generated is determined by who/what origin/sites the users are.
            ValidateIssuer = true,//This is the field where we specify who will distribute the token value that will be created.
            ValidateLifetime = true,//It is the verification that will control the duration of the created token value.
            ValidateIssuerSigningKey = true, //It is the verification of the security key data, which indicates that the token value to be generated is a value belonging to our application.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))

        };
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();