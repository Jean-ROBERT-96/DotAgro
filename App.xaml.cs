using DotAgro.Data;
using DotAgro.Interfaces;
using DotAgro.Models;
using DotAgro.Services.Management;
using DotAgro.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DotAgro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IDataConnect, DataConnect>();
            services.AddTransient<IDataManage<Salary>, SalaryManage>();
            services.AddTransient<IDataManage<Models.Services>, ServiceManage>();
            services.AddTransient<IDataManage<Headquarters>, HeadquarterManage>();
            services.AddTransient<IDataAdmin, AdminManage>();

            services.AddSingleton<MainWindow>();

            services.AddSingleton<SalaryViewModel>();
            services.AddSingleton<ServiceViewModel>();
            services.AddSingleton<HeadquarterViewModel>();
            services.AddSingleton<AdminViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow main = serviceProvider.GetService<MainWindow>();
            main.SalaryContext = serviceProvider.GetService<SalaryViewModel>();
            main.ServiceContext = serviceProvider.GetService<ServiceViewModel>();
            main.HeadquarterContext = serviceProvider.GetService<HeadquarterViewModel>();
            main.AdminContext = serviceProvider.GetService<AdminViewModel>();

            /*main.SalaryContext.InitValue();
            main.ServiceContext.InitValue();
            main.HeadquarterContext.InitValue();*/

            main.ContextLoaded();

            main.Show();
        }
    }
}
