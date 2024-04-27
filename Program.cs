using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AprilBookStore.Models;
using AprilBookStore.DataAccess;
using NuGet.Packaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using AprilBookStore.Security;
using System.Security.Principal;
namespace AprilBookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc(options =>
            {
                options.EnableEndpointRouting=false;
               /* var Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(Policy));*/
            });

            var connectionString = builder.Configuration.GetConnectionString("AprilBookStoreContextConnection") ?? throw new InvalidOperationException("Connection string 'AprilBookStoreContextConnection' not found.");

            builder.Services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric=false;
                
             }).AddDefaultUI()
                .AddEntityFrameworkStores<BookStoreContext>()
                .AddDefaultTokenProviders();
            

            builder.Services.AddTransient<IData, DataContext>();
            builder.Services.AddTransient<IAuthorizationHandler, CanEditOnlyOthersRolesHandler>();
            builder.Services.AddTransient<IAuthorizationHandler, SuperAdminHandler>();

            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId="435389422678-rr32mr9ghe5f72rfgmp5eako1uql2chv.apps.googleusercontent.com";
                    options.ClientSecret="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";
                });
            builder.Services.AddAuthorization(options=> {
                options.AddPolicy("DeleteRolePolicy", p => p.RequireRole("SuperAdmin"));
                options.AddPolicy("EditUserRolePolicy", p => p.AddRequirements(new RoleEditingRequirement()));
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.Run();
        }
    }
}
