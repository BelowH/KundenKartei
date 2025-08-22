using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KundenKartei.Components;
using KundenKartei.Database;
using KundenKartei.Services;
using KundenKartei.State;
using KundenKartei.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KundenKartei;

public partial class App : Application
{
    public IServiceProvider? ServiceProvider { get; private set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (Design.IsDesignMode)
        {
            // Let the designer use the XAML Design.DataContext; do not resolve services here.
            base.OnFrameworkInitializationCompleted();
            return;
        }

        
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
        
        AppDbContext dbContext = ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }
        
        base.OnFrameworkInitializationCompleted();
    }


    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));

        services.AddSingleton<GlobalDisplayState>();
        
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IEventService, EventService>();

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<CustomerSearchControlViewModel>();
        services.AddTransient<EventSearchControlViewModel>();
        services.AddTransient<SalesSearchControlViewModel>();
        services.AddTransient<NewCustomerControlViewModel>();
        
        services.AddTransient<CustomerSearchControl>();
        services.AddTransient<EventSearchControl>();
        services.AddTransient<SalesSearchControl>();
        services.AddTransient<NewCustomerControl>();
        
        services.AddTransient<MainWindow>();

    }
    
    
}