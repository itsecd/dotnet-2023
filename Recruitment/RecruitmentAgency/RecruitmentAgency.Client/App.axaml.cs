using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RecruitmentAgency.Client.ViewModels;
using RecruitmentAgency.Client.Views;
using Splat;

namespace RecruitmentAgency.Client;
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
                    cfg.CreateMap<CompanyGetDto, CompanyViewModel>();
                    cfg.CreateMap<CompanyViewModel, CompanyGetDto>();
                    cfg.CreateMap<CompanyPostDto, CompanyViewModel>();
                    cfg.CreateMap<CompanyViewModel, CompanyPostDto>();

                    cfg.CreateMap<CompanyApplicationGetDto, CompanyViewModel>();
                    cfg.CreateMap<CompanyViewModel, CompanyApplicationGetDto>();
                    cfg.CreateMap<CompanyApplicationPostDto, CompanyApplicationViewModel>();
                    cfg.CreateMap<CompanyApplicationViewModel, CompanyApplicationPostDto>();

                    cfg.CreateMap<EmployeeGetDto, EmployeeViewModel>();
                    cfg.CreateMap<EmployeeViewModel, EmployeeGetDto>();
                    cfg.CreateMap<EmployeePostDto, EmployeeViewModel>();
                    cfg.CreateMap<EmployeeViewModel, EmployeePostDto>();

                    cfg.CreateMap<JobApplicationGetDto,JobApplicationViewModel>();
                    cfg.CreateMap<JobApplicationViewModel, JobApplicationGetDto>();
                    cfg.CreateMap<JobApplicationPostDto, JobApplicationViewModel>();
                    cfg.CreateMap<JobApplicationViewModel, JobApplicationPostDto>();

                    cfg.CreateMap<TitleGetDto, TitleViewModel>();
                    cfg.CreateMap<TitleViewModel, TitleGetDto>();
                    cfg.CreateMap<TitlePostDto, TitleViewModel>();
                    cfg.CreateMap<TitleViewModel, TitlePostDto>();

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