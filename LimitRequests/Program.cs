using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions();
builder.Services.AddMemoryCache();

builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting")); // Client id or API Key
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); // Ip address

builder.Services.AddInMemoryRateLimiting();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
var app = builder.Build();

app.UseClientRateLimiting();
//app.UseIpRateLimiting();

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
