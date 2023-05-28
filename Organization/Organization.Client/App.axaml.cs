using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Organization.Client.ViewModels;
using Organization.Client.Views;
using Splat;
using System;

namespace Organization.Client;
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

                cfg.CreateMap<GetDepartmentEmployeeDto, DepartmentEmployeeViewModel>();
                cfg.CreateMap<DepartmentEmployeeViewModel, PostDepartmentEmployeeDto>();

                cfg.CreateMap<GetWorkshopDto, WorkshopViewModel>();
                cfg.CreateMap<WorkshopViewModel, PostWorkshopDto>();

                cfg.CreateMap<GetEmployeeDto, EmployeeViewModel>();
                cfg.CreateMap<EmployeeViewModel, PostEmployeeDto>();
            }
            );
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