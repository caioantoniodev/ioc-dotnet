using DependencyInjectionLifetime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PrimaryService>();
builder.Services.AddScoped<SecondaryService>();
builder.Services.AddTransient<TertiaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", (
    PrimaryService primaryService,
    SecondaryService secondaryService,
    TertiaryService tertiaryService) => 
    new
    {
        Id = Guid.NewGuid(),
        PrimaryServiceId = primaryService.Id,
        SecondaryService = new 
        {
            Id = secondaryService.Id,
            PrimaryServiceId = secondaryService.PrimaryServiceId
        },
        TertiaryService = new
        {
            Id = tertiaryService.Id,
            PrimaryServiceId = tertiaryService.PrimaryServiceId,
            SecondaryServiceId = tertiaryService.SecondaryServiceId,
            SecondaryServiceNewInstanceId = tertiaryService.SecondaryServiceNewInstanceId
        }
    });

app.Run();