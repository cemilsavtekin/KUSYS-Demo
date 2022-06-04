using KUSYS.Business.Abstracts;
using KUSYS.Business.Concretes;
using KUSYS.DataAccess.Abstracts;
using KUSYS.DataAccess.Concretes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KUSYS.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DbContext, KUSYS.DataAccess.KUSYSContext>();

            services.AddScoped<IRepository, KUSYSRepo>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddMvc();
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/Denied";
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnSigningIn = async context =>
                        {
                            //var principal = context.Principal;
                            //if (principal.HasClaim(c=>c.Type == ClaimTypes.NameIdentifier))
                            //{
                            //    if (principal.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier).Value == "kullanıcı adı gelecek")
                            //    {
                            //        var claimsIdentity = principal.Identity as ClaimsIdentity;
                            //        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                            //    }
                            //}

                            await Task.CompletedTask;
                        },
                        OnSignedIn = async context =>
                        {
                            await Task.CompletedTask;
                        },
                        OnValidatePrincipal = async context =>
                        {
                            await Task.CompletedTask;
                        }
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}"); 
            });

            
        } 
    }
}
