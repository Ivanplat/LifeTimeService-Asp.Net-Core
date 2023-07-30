using LifeTimeService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGuidService, GuidService>();
builder.Services.AddScoped<UidService>();
var app = builder.Build();

app.MapGet("/", async context =>
{
    IGuidService guid = context.RequestServices.GetService<IGuidService>();
    UidService uid = context.RequestServices.GetService<UidService>();
    await context.Response.WriteAsync($"guid: {guid.Value}, uid: " +
        $"{uid.GUID.Value}");
});

app.Run();
