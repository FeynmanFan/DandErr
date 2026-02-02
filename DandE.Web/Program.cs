using DandE.Logging;
using DanE.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddExceptionHandler<ChatTimeoutExceptionHandler>();
builder.Services.AddExceptionHandler<UnexpectedExceptionHandler>();

builder.Logging.AddProvider(new SimpleFileLoggerProvider(builder.Configuration));

var app = builder.Build();

app.MapGet("/crash", (HttpContext context) => throw new InvalidOperationException("Testing global exception handler"));

app.UseExceptionHandler("/Error");

app.MapControllerRoute(name: "chat", pattern: "chat/{action=Index}", defaults: new { controller = "Chat" });
app.MapControllerRoute(name: "error", pattern: "error/{action=Index}", defaults: new { controller = "Error" });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

