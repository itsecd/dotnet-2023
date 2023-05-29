using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CarSharingClient.ViewModels;
using CarSharingClient.Views;
using Splat;
using AutoMapper;

namespace CarSharingClient;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarGetDto, CarViewModel>();
                cfg.CreateMap<CarViewModel, CarPostDto>();
                cfg.CreateMap<CarPostDto, CarViewModel>();
                cfg.CreateMap<CarViewModel, CarGetDto>();
                cfg.CreateMap<RentalPointViewModel, RentalPointPostDto>();
                cfg.CreateMap<RentalPointPostDto, RentalPointViewModel>();
            }
            );
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}