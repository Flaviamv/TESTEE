using SistemVenda.Aplicacao.Servico;
using SistemVenda.Aplicacao.Servico.Interfaces;
using Microsoft.EntityFrameworkCore;
using SistemVenda.Repositorio;
using SistemVenda.Dominio.Servicos;
using SistemVenda.Dominio.Interfaces;
using SistemVenda.Dominio.Repositorio;
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



        // Aplicação
        builder.Services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
        builder.Services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
        builder.Services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
        builder.Services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
        builder.Services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();

        // Domínio
        builder.Services.AddScoped<IServicosCategoria, ServicoCategoria>();
        builder.Services.AddScoped<IServicosCliente, ServicoCliente>();
        builder.Services.AddScoped<IServicosProduto, ServicoProduto>();
        builder.Services.AddScoped<IServicosVenda, ServicoVenda>();
        builder.Services.AddScoped<IServicoUsuario, ServicoUsuario>();

        // Repositório
        builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
        builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
        builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
        builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
        builder.Services.AddScoped<IRepositorioVendaProdutos, RepositorioVendaProduto>();
        builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


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