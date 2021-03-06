using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BankAccountSimulation.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectRepository.Contracts;
using ProjectRepository;
using BusinessLogicLayer.Contracts;
using BusinessLogicLayer;

namespace BankAccountSimulation
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<ICountryManager, CountryManager>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityManager, CityManager>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IBranchManager, BranchManager>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminManager, AdminManager>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAccountTypeManager, AccountTypeManager>();
            services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
            services.AddTransient<IAccountStatusManager, AccountStatusManager>();
            services.AddTransient<IAccountStatusRepository, AccountStatusRepository>();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionsTypeManager, TransactionsTypeManager>();
            services.AddTransient<ITransactionsTypeRepository, TransactionTypeRepository>();
            services.AddTransient<ITransferMoneyManager, TransferMoneyManager>();
            services.AddTransient<ITransferMoneyRepository, TransferMoneyRepository>();
            services.AddTransient<IWithdrawMoneyManager, WithdrawMoneyManager>();
            services.AddTransient<IWithdrawMoneyRepository, WithdrawMoneyRepository>();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
