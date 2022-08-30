using AspNetCoreRateLimit;
using AspNetCoreRateLimit.Redis;
using LimitRequests.RateLimiting;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiting(builder.Configuration);

//builder.Services.AddOptions();
//builder.Services.AddMemoryCache();
//builder.Services.AddDistributedMemoryCache();

//builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting")); // Client id or API Key
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); // Ip address
//builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect("localhost:6379"));
//builder.Services.AddRedisRateLimiting();
//builder.Services.AddInMemoryRateLimiting();

// builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>(); // deafult rate limiting
//builder.Services.AddSingleton<IRateLimitConfiguration, CustomRateLimiting>(); // custom rate limiting

var app = builder.Build();
app.UseRateLimiting();
//app.UseClientRateLimiting();
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
