using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NonResidentialFund.Client.ViewModels;
using NonResidentialFund.Client.Views;
using Splat;

namespace NonResidentialFund.Client;
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
                cfg.CreateMap<OrganizationGetDto, OrganizationViewModel>();
                cfg.CreateMap<OrganizationViewModel, OrganizationPostDto>();

                cfg.CreateMap<BuildingGetDto, BuildingViewModel>();
                cfg.CreateMap<BuildingViewModel, BuildingPostDto>();
                
                cfg.CreateMap<AuctionGetDto, AuctionViewModel>();
                cfg.CreateMap<AuctionViewModel, AuctionPostDto>();

                cfg.CreateMap<PrivatizedGetDto, PrivatizedViewModel>();
                cfg.CreateMap<PrivatizedViewModel, PrivatizedPostDto>();

                cfg.CreateMap<DistrictGetDto, DistrictViewModel>();
                cfg.CreateMap<DistrictViewModel, DistrictPostDto>();
            });
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}