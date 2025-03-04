using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using App.Infra.Data.Repos.Ef.Sangaghak;
using Connection.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SangaghakAppService.Sangaghak.BaseEntities;
using SangaghakAppService.Sangaghak.Categories;
using SangaghakAppService.Sangaghak.Comments;
using SangaghakAppService.Sangaghak.Pages;
using SangaghakAppService.Sangaghak.Requests;
using SangaghakAppService.Sangaghak.Users;
using SangaghakService.Sangaghak.BaseEntities;
using SangaghakService.Sangaghak.Categories;
using SangaghakService.Sangaghak.Comments;
using SangaghakService.Sangaghak.Requests;
using SangaghakService.Sangaghak.Users;

namespace SangaghakRazorEndPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            //var configuration = builder.Configuration;


            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Data Source=DESKTOP-7D9S1GO;Initial Catalog=Sangaghak;Integrated Security=SSPI;TrustServerCertificate=True;"));

            builder.Services.AddIdentity<UserBase, IdentityRole<int>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).
            AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>();



            //    optionsBuilder.UseSqlServer();
            //    base.OnConfiguring(optionsBuilder);

            builder.Services.AddScoped<IUserBaseRepository, UserBaseRepository>();
            builder.Services.AddScoped<IUserBaseService, UserBaseService>();
            builder.Services.AddScoped<IUserBaseAppService, UserBaseAppService>();


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();


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

            builder.Services.AddScoped<IDashboardAppService, DashboardAppService>();
            builder.Services.AddScoped<IGeneralService, GeneralService>();

            builder.Services.AddRazorPages();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            //builder.Services
            //.AddRazorPages()
            //.AddRazorPagesOptions(opt => opt.RootDirectory = "/Admin/Index");
            //builder.Services
            //.AddRazorPages()
            //.AddRazorPagesOptions(opt => opt.RootDirectory = "/Admin/LoginUser");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();
            //app.MapControllerRoute(
            //name: "default",
            //pattern: "{}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
