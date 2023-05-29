using AdmissionCommittee.Client.ViewModels;
using AdmissionCommittee.Client.Views;
using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Splat;

namespace AdmissionCommittee.Client;
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
                cfg.CreateMap<EntrantGetDto, EntrantViewModel>();
                cfg.CreateMap<EntrantViewModel, EntrantPostDto>();
                cfg.CreateMap<EntrantPostDto, EntrantViewModel>();

                cfg.CreateMap<EntrantResultGetDto, EntrantResultViewModel>();
                cfg.CreateMap<EntrantResultViewModel, EntrantResultPostDto>();
                cfg.CreateMap<EntrantResultPostDto, EntrantResultViewModel>();

                cfg.CreateMap<ResultGetDto, ResultViewModel>();
                cfg.CreateMap<ResultViewModel, ResultPostDto>();
                cfg.CreateMap<ResultPostDto, ResultViewModel>();

                cfg.CreateMap<StatementGetDto, StatementViewModel>();
                cfg.CreateMap<StatementViewModel, StatementPostDto>();
                cfg.CreateMap<StatementPostDto, StatementViewModel>();

                cfg.CreateMap<StatementSpecialtyGetDto, StatementSpecialtyViewModel>();
                cfg.CreateMap<StatementSpecialtyViewModel, StatementSpecialtyPostDto>();
                cfg.CreateMap<StatementSpecialtyPostDto, StatementSpecialtyViewModel>();

                cfg.CreateMap<SpecialtyGetDto, SpecialtyViewModel>();
                cfg.CreateMap<SpecialtyViewModel, SpecialtyPostDto>();
                cfg.CreateMap<SpecialtyPostDto, SpecialtyViewModel>();
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