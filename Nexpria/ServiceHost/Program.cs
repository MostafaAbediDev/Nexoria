using _0_FrameWork.Application;
using PortFolioManagement.Configuration;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("NexoriaDb");

PortFolioManagementBoostrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();

builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

// Middleware for Admin authentication
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLowerInvariant().TrimEnd('/');

    // فقط وقتی مسیر با /administration شروع می‌کنه و خود صفحه لاگین نیست
    if (path != null && path.StartsWith("/administration") && path != "/administration/adminpage")
    {
        if (context.Session.GetString("AdminAuthenticated") != "true")
        {
            context.Response.Redirect("/Administration/AdminPage");
            return;
        }
    }

    await next();
});

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
