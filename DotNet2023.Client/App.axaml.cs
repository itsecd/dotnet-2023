using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DotNet2023.Client.ViewModels;
using DotNet2023.Client.Views;
using Splat;

namespace DotNet2023.Client;
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
            var config = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<HigherEducationInstitutionDto, HigherEducationInstitutionViewModel>();
                configuration.CreateMap<HigherEducationInstitutionViewModel, HigherEducationInstitutionDto>();
                configuration.CreateMap<DepartmentDto, DepartmentViewModel>();
                configuration.CreateMap<DepartmentViewModel, DepartmentDto>();
                configuration.CreateMap<EducationWorkerDto, EducationWorkerViewModel>();
                configuration.CreateMap<EducationWorkerViewModel, EducationWorkerDto>();
                configuration.CreateMap<FacultyDto, FacultyViewModel>();
                configuration.CreateMap<FacultyViewModel, FacultyDto>();
                configuration.CreateMap<GroupOfStudentsDto, GroupOfStudentsViewModel>();
                configuration.CreateMap<GroupOfStudentsViewModel, GroupOfStudentsDto>();
                configuration.CreateMap<InstituteSpecialityDto, InstituteSpecialityViewModel>();
                configuration.CreateMap<InstituteSpecialityViewModel, InstituteSpecialityDto>();
                configuration.CreateMap<SpecialityDto, SpecialityViewModel>();
                configuration.CreateMap<SpecialityViewModel, SpecialityDto>();
                configuration.CreateMap<StudentDto, StudentViewModel>();
                configuration.CreateMap<StudentViewModel, StudentDto>();
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