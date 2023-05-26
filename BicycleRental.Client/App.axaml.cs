using AutoMapper;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BicycleRental.Client.ViewModels;
using BicycleRental.Client.Views;
using Splat;

namespace BicycleRental.Client;
public partial class App : Application
{
    public override void Initialize()
    {
        var dataGridType = typeof(DataGrid); // HACK
        AvaloniaXamlLoader.Load(this);
    }    

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BicycleGetDto, BicycleViewModel>();
                cfg.CreateMap<BicycleViewModel, BicyclePostDto>();
                cfg.CreateMap<CustomerGetDto, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, CustomerPostDto>();
                cfg.CreateMap<RentalGetDto, BicycleRentalViewModel>();
                cfg.CreateMap<BicycleRentalViewModel, RentalPostDto>();
                cfg.CreateMap<BicycleTypeGetDto, BicycleTypeViewModel>();
            });
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