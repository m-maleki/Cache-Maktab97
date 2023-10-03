using Cache_Maktab97.Infrastructure.Cache.InMemoryCache;
using Cache_Maktab97.Infrastructure.Cache.RedisCache;
using Cache_Maktab97.Infrastructure.EfCore;
using Cache_Maktab97.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBaseDataRepository, BaseDataRepository>();
builder.Services.AddScoped<IInMemoryCacheService, InMemoryCacheService>();
builder.Services.AddScoped<IRedisCacheServices, RedisCacheServices>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(""));


builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.ConfigurationOptions = new ConfigurationOptions
    {
        Password = string.Empty,
        DefaultDatabase = 5,
        ConnectTimeout = 5000,
    };
    options.ConfigurationOptions.EndPoints.Add("localhost:6379");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
