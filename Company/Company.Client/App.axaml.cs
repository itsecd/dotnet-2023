using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Company.Client.ViewModels;
using Company.Client.Views;
using Splat;

namespace Company.Client;

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
                cfg.CreateMap<DepartmentGetDto, DepartmentViewModel>();
                cfg.CreateMap<DepartmentViewModel, DepartmentPostDto>();

                cfg.CreateMap<JobGetDto, JobViewModel>();
                cfg.CreateMap<JobViewModel, JobPostDto>();

                cfg.CreateMap<VacationGetDto, VacationViewModel>();
                cfg.CreateMap<VacationViewModel, VacationPostDto>();

                cfg.CreateMap<VacationSpotGetDto, VacationSpotViewModel>();
                cfg.CreateMap<VacationSpotViewModel, VacationSpotPostDto>();

                cfg.CreateMap<WorkerGetDto, WorkerViewModel>();
                cfg.CreateMap<WorkerViewModel, WorkerPostDto>();

                cfg.CreateMap<WorkersAndDepartmentsGetDto, WorkersAndDepartmentsViewModel>();
                cfg.CreateMap<WorkersAndDepartmentsViewModel, WorkersAndDepartmentsPostDto>();

                cfg.CreateMap<WorkersAndJobsGetDto, WorkersAndJobsViewModel>();
                cfg.CreateMap<WorkersAndJobsViewModel, WorkersAndJobsPostDto>();

                cfg.CreateMap<WorkersAndVacationsGetDto, WorkersAndVacationsViewModel>();
                cfg.CreateMap<WorkersAndVacationsViewModel, WorkersAndVacationsPostDto>();

                cfg.CreateMap<WorkshopGetDto, WorkshopViewModel>();
                cfg.CreateMap<WorkshopViewModel, WorkshopPostDto>();
            });

            Locator.CurrentMutable.RegisterConstant(config.CreateMapper(), typeof(IMapper));
            Locator.CurrentMutable.RegisterConstant(new ApiWrapper());

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
