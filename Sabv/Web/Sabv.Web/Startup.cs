namespace Sabv.Web
{
    using System.Reflection;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Sabv.Data;
    using Sabv.Data.Common;
    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Data.Seeding;
    using Sabv.Services.Data;
    using Sabv.Services.Mapping;
    using Sabv.Services.Messaging;
    using Sabv.Web.Hubs;
    using Sabv.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            // Antiforgery Token
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies().UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();

            // External
            services.AddSignalR();
            services.AddCloudscribePagination();

            Account cloudinaryCredentials = new Account(
              this.configuration["Cloudinary:CloudName"],
              this.configuration["Cloudinary:ApiKey"],
              this.configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);
            services.AddSingleton(cloudinary);

            services.AddSingleton(this.configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IMakesService, MakesService>();
            services.AddTransient<IModelsService, ModelsService>();
            services.AddTransient<IVehicleCategoriesService, VehicleCategoriesService>();
            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IMessagesService, MessagesService>();
            services.AddTransient<IFavouritesService, FavouritesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEmailSender>(x => new SendEmailClient(this.configuration["SendGrid:ApiKey"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.Migrate();

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Base/ProductionError/{0}");
                app.UseExceptionHandler("/Base/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapHub<ChatHub>("/chathub");
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("postsByCategories", "Categories/{name:minlength(3)}", new { controller = "Categories", action = "Display" });
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
