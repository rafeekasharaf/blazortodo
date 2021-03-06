using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Net;
using ToDo.Server.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ToDo.Server
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;
   
        }
                public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddAuthentication(options =>{
            //     options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            // }).AddCookie()
            services.AddAuthentication("Cookies")
                .AddCookie(opt => {
                    opt.Cookie.Name = "GoogleAuthCokkie";
                    opt.LoginPath ="/auth/google-login";
                })

            .AddGoogle(options =>
            {
                options.ClientId = Configuration["Google:ClientId"];
                options.ClientSecret = Configuration["Google:ClientSecret"]; 
                options.CorrelationCookie.SameSite = SameSiteMode.Lax;
            });
            
            
            services.AddControllersWithViews();            
            services.AddRazorPages();
            services.AddScoped<CategoryService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                                await context.Response.WriteAsync(err).ConfigureAwait(false);
                            }
                        });
                }
            );

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

         //   app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseCookiePolicy();
            app.UseStaticFiles();            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
