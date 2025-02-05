using FluentValidation;
using FluentValidation.AspNetCore;
using MiniE_Commerce.Application;
using MiniE_Commerce.Application.Validators.Products;
using MiniE_Commerce.Infrastructure;
using MiniE_Commerce.Infrastructure.Filters;
using MiniE_Commerce.Infrastructure.Services.Storage.Local;
using MiniE_Commerce.Persistence;

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