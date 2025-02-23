var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<WireMockService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

_ = Task.Run(async () =>
{
    var wireMockService = app.Services.GetRequiredService<WireMockService>();
    await wireMockService.ConfigureWireMockAsync();
});

app.Run();
