using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Repositorio.Entidades;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = ContextBoundObject => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

       builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


       builder.Services.AddDistributedMemoryCache();

       builder.Services.AddSession(options =>
       {
          options.IdleTimeout = TimeSpan.FromMinutes(30);
          options.Cookie.HttpOnly = true;
          options.Cookie.IsEssential = true;
       });
        

        var connectionString = builder.Configuration.GetConnectionString("MyStock");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


        // Add services to the container.
        builder.Services.AddControllersWithViews()
        .AddRazorRuntimeCompilation()
        .AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.PropertyNamingPolicy = null;
            o.JsonSerializerOptions.DictionaryKeyPolicy = null;
        });

        builder.Services.AddMvc();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseCookiePolicy();
        app.UseSession();
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}