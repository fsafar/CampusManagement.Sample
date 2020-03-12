using CampusManagement.Data.Queries;
using CampusManagement.Payments;
using CampusManagement.Payments.Interfaces;
using CampusManagement.Payments.VendorImplementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CampusManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentChargesQuery, StudentChargesQuery>();
            services.AddScoped<IStudentChargeLookupQuery, StudentChargeLookupQuery>();
            services.AddScoped<IPaymentOptionsQuery, PaymentOptionsQuery>();
            services.AddSingleton<IPaymentStrategy>(new PaymentStrategy(new IPaymentService[]
            {
                new BankImplementation(),
                new CreditCardImplementation(),
                new PayPalImplementation(),
            }));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PaymentOptionSelectRoute",
                    pattern: "studentCharges/{chargeId}", new { controller = "PaymentOptions", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "PaymentOptionRoute",
                    pattern: "studentCharges/{chargeId}/{action?}", new {controller = "PaymentOptions"});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
