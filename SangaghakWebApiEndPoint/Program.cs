using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Config;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using App.Infra.Data.Repos.Ef.Sangaghak;
using Connection.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SangaghakAppService.Sangaghak.BaseEntities;
using SangaghakAppService.Sangaghak.Categories;
using SangaghakAppService.Sangaghak.Comments;
using SangaghakAppService.Sangaghak.Pages;
using SangaghakAppService.Sangaghak.Requests;
using SangaghakAppService.Sangaghak.ServicePackages;
using SangaghakAppService.Sangaghak.Users;
using SangaghakAppService.Sangaghak.WebApi;
using SangaghakService.Sangaghak.BaseEntities;
using SangaghakService.Sangaghak.Categories;
using SangaghakService.Sangaghak.Comments;
using SangaghakService.Sangaghak.Requests;
using SangaghakService.Sangaghak.ServicePackages;
using SangaghakService.Sangaghak.Users;
using SangaghakService.Sangaghak.WebApi;
using SangaghakWebApiEndPoint.WebFramework.WebApi.Filters;
using Serilog;
using App.Domain.Core.Sangaghak.Config;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var siteSettings = configuration.GetSection(nameof(Sitesettings)).Get<Sitesettings>();
builder.Services.AddSingleton(siteSettings);

builder.Host.ConfigureLogging(o =>
{
    o.ClearProviders();
    o.AddSerilog();
}).UseSerilog((Context, Config) =>
{
    Config.WriteTo.Console();
    Config.WriteTo.Seq(siteSettings.SeqConfigurations.UrlAddress, apiKey:siteSettings.SeqConfigurations.ApiToken);
});


builder.Services.AddMemoryCache();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSettings!.SqlConfigurations.ConnectionString));


builder.Services.AddMemoryCache();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSettings.SqlConfigurations.ConnectionString));

//Add Sql Connection String
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(siteSettings.SqlConfigurations.ConnectionString)
    );



builder.Services.AddIdentity<UserBase, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddRoles<IdentityRole<int>>()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUserBaseRepository, UserBaseRepository>();
builder.Services.AddScoped<IUserBaseService, UserBaseService>();
builder.Services.AddScoped<IUserBaseAppService, UserBaseAppService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddScoped<IServicePackageRepository, ServicePackageRepository>();
builder.Services.AddScoped<IServicePackageService, ServicePackageService>();
builder.Services.AddScoped<IServicePackageAppService, ServicePackageAppService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityAppService, CityAppService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<IExpertAppService, ExpertAppService>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IOfferAppService, OfferAppService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();



builder.Services.AddScoped<IApiRepository, ApiRepository>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IApiAppService, ApiAppService>();



builder.Services.AddScoped<IDashboardAppService, DashboardAppService>();
builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<ICustomerProfileAppService, CustomerProfileAppService>();
builder.Services.AddScoped<IPostRequestAppService, PostRequestAppService>();
builder.Services.AddScoped<IExpertProfileAppService, ExpertProfileAppService>();
builder.Services.AddScoped<IDapperRepository, DapperRepository>();


builder.Services.AddSingleton<RequestActionFilter>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Sangaghak API", Version = "v1" });
    c.SchemaFilter<RoleEnumFilter>();
    //c.SchemaFilter<IFormFileFilter>();//فیلتر مخصوص IFormFile
    c.MapType<RoleEnum>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(RoleEnum))
            .Where(name => name != RoleEnum.Admin.ToString())
            .Select(name => new OpenApiString(name))
            .Cast<IOpenApiAny>()
            .ToList()
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sangaghak API v1");
        c.RoutePrefix = string.Empty;
    });

    app.Lifetime.ApplicationStarted.Register(() =>
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://localhost:7209/index.html",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to open browser for Swagger UI");
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "An error occurred while starting the application");
}
finally
{
    Log.CloseAndFlush();
}