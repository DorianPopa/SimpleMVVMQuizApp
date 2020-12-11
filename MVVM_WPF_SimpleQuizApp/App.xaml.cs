using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MVVM_WPF_SimpleQuizApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSingleton<IQuizDataService, QuizDataService>();
            services.AddSingleton<IWindowService, WindowService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var windowService = _serviceProvider.GetService<IWindowService>();
            windowService.OpenStartWindow();
        }
    }
}
