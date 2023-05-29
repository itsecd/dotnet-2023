using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PharmacyCityNetwork.Client.ViewModels;
using PharmacyCityNetwork.Client.Views;
using Splat;

namespace PharmacyCityNetwork.Client;
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
                cfg.CreateMap<ProductGetDto, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, ProductPostDto>();

                cfg.CreateMap<GroupGetDto, GroupViewModel>();
                cfg.CreateMap<GroupViewModel, GroupPostDto>();

                cfg.CreateMap<PharmacyGetDto, PharmacyViewModel>();
                cfg.CreateMap<PharmacyViewModel, PharmacyPostDto>();
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