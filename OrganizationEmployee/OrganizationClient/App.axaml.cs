using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OrganizationClient.ViewModels;
using OrganizationClient.Views;
using Splat;

namespace OrganizationClient;
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
                cfg.CreateMap<GetDepartmentDto, DepartmentViewModel>();
                cfg.CreateMap<DepartmentViewModel, PostDepartmentDto>();
            });
            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}