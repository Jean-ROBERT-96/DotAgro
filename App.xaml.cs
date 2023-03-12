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
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IDataConnect, DataConnect>();
            services.AddTransient<IDataManage<Salary>, SalaryManage>();
            services.AddTransient<IDataManage<Models.Services>, ServiceManage>();
            services.AddTransient<IDataManage<Headquarters>, HeadquarterManage>();

            services.AddSingleton<MainWindow>();

            services.AddSingleton<SalaryViewModel>();
            services.AddSingleton<ServiceViewModel>();
            services.AddSingleton<HeadquarterViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.SalaryContext = serviceProvider.GetService<SalaryViewModel>();
            mainWindow.ServiceContext = serviceProvider.GetService<ServiceViewModel>();
            mainWindow.HeadquarterContext = serviceProvider.GetService<HeadquarterViewModel>();
            mainWindow.Show();
        }
    }
}
