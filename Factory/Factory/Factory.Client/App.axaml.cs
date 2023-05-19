using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Factory.Client.ViewModels;
using Factory.Client.Views;
using Splat;

namespace Factory.Client;
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
                cfg.CreateMap<EnterpriseGetDto, EnterpriseViewModel>();
                cfg.CreateMap<EnterpriseViewModel, EnterpriseGetDto>();
                cfg.CreateMap<EnterpriseViewModel, EnterprisePostDto>();
                cfg.CreateMap<EnterprisePostDto, EnterpriseViewModel>();

                cfg.CreateMap<SupplierGetDto, SupplierViewModel>();
                cfg.CreateMap<SupplierViewModel, SupplierGetDto>();
                cfg.CreateMap<SupplierViewModel, SupplierPostDto>();
                cfg.CreateMap<SupplierPostDto, SupplierViewModel>();

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