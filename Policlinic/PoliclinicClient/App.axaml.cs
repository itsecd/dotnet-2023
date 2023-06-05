using AutoMapper;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PoliclinicClient.ViewModels;
using PoliclinicClient.Views;
using Splat;

namespace PoliclinicClient;
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
                cfg.CreateMap<PatientGetDto, PatientViewModel>();
                cfg.CreateMap<PatientViewModel, PatientPostDto>();
                cfg.CreateMap<PatientViewModel, PatientGetDto>();
                cfg.CreateMap<PatientPostDto, PatientViewModel>();
                cfg.CreateMap<DoctorGetDto, DoctorViewModel>();
                cfg.CreateMap<DoctorViewModel, DoctorPostDto>();
                cfg.CreateMap<DoctorViewModel, DoctorGetDto>();
                cfg.CreateMap<DoctorPostDto, DoctorViewModel>();
                cfg.CreateMap<ReceptionViewModel, ReceptionDto>();
                cfg.CreateMap<ReceptionDto, ReceptionViewModel>();
                cfg.CreateMap<SpecializationViewModel, SpecializationDto>();
                cfg.CreateMap<SpecializationDto, SpecializationViewModel>();
                cfg.CreateMap<DoctorGetDto, ExperiencedDoctorsViewModel>();
                cfg.CreateMap<ExperiencedDoctorsViewModel, DoctorGetDto>();
                cfg.CreateMap<PatientGetDto, CurrentHealthPatientsViewModel>();
                cfg.CreateMap<CurrentHealthPatientsViewModel, PatientGetDto>();
                cfg.CreateMap<CountPatientDto, CountOfPatientsViewModel>();
                cfg.CreateMap<CountOfPatientsViewModel, CountPatientDto>();
                cfg.CreateMap<Top5DiseasesDto, Top5DiseasesViewModel>();
                cfg.CreateMap<Top5DiseasesViewModel, Top5DiseasesDto>();
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