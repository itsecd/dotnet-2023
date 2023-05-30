using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using AutoMapper;
using ReactiveUI;
using Splat;
using Poluclinic.Client;

namespace Polyclinic.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PatientViewModel> Patients { get; } = new();
    public ObservableCollection<DoctorViewModel> Doctors { get; } = new();
    //public ObservableCollection<SpecializationsViewModel> Specializations { get; } = new();

    private PatientViewModel? _selectedPatient;
    public PatientViewModel? SelectedPatient
    {
        get => _selectedPatient;
        set => this.RaiseAndSetIfChanged(ref _selectedPatient, value);
    }

    private DoctorViewModel? _selectedDoctor;
    public DoctorViewModel? SelectedDoctor
    {
        get => _selectedDoctor;
        set => this.RaiseAndSetIfChanged(ref _selectedDoctor, value);
    }


    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddPatientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangePatientCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeletePatientCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddDoctorCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeDoctorCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDoctorCommand { get; set; }

    public Interaction<PatientViewModel, PatientViewModel?> ShowPatientDialog { get; }
    public Interaction<DoctorViewModel, DoctorViewModel?> ShowDoctorDialog { get; }
    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowPatientDialog = new Interaction<PatientViewModel, PatientViewModel?>();
        ShowDoctorDialog = new Interaction<DoctorViewModel, DoctorViewModel?>();

        OnAddPatientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var patientViewModel = await ShowPatientDialog.Handle(new PatientViewModel());
            if (patientViewModel != null)
            {
                var newPatient = _mapper.Map<PatientPostDto>(patientViewModel);
                await _apiClient.AddPatientAsync(newPatient);
                Patients.Add(patientViewModel);
            }
        });

        OnChangePatientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var patientViewModel = await ShowPatientDialog.Handle(SelectedPatient!);
            if (patientViewModel != null)
            {
                var newPatient = _mapper.Map<PatientPostDto>(patientViewModel);
                await _apiClient.UpdatePatientAsync(SelectedPatient!.Id, newPatient);
                _mapper.Map(patientViewModel, SelectedPatient);
            }
        }, this.WhenAnyValue(vm => vm.SelectedPatient).Select(selectedPatient => selectedPatient != null));

        OnDeletePatientCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePatientAsync(SelectedPatient!.Id);
            Patients.Remove(SelectedPatient);
        }, this.WhenAnyValue(vm => vm.SelectedPatient).Select(selectedPatient => selectedPatient != null));

        OnAddDoctorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var doctorViewModel = await ShowDoctorDialog.Handle(new DoctorViewModel());
            if (doctorViewModel != null)
            {
                var newDoctor = _mapper.Map<DoctorPostDto>(doctorViewModel);
                await _apiClient.AddDoctorAsync(newDoctor);
                Doctors.Add(doctorViewModel);
            }
        });

        OnChangeDoctorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var doctorViewModel = await ShowDoctorDialog.Handle(SelectedDoctor!);
            if (doctorViewModel != null)
            {
                var newDoctor = _mapper.Map<DoctorPostDto>(doctorViewModel);
                await _apiClient.UpdateDoctorAsync(SelectedDoctor!.Id, newDoctor);
                _mapper.Map(doctorViewModel, SelectedDoctor);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDoctor).Select(SelectedDoctor => SelectedDoctor != null));

        OnDeleteDoctorCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDoctorAsync(SelectedDoctor!.Id);
            Doctors.Remove(SelectedDoctor);
        }, this.WhenAnyValue(vm => vm.SelectedPatient).Select(selectedDoctor => SelectedDoctor != null));

        RxApp.MainThreadScheduler.Schedule(LoadAllAsync);

    }

    private async void LoadAllAsync()
    {
        var patients = await _apiClient.GetPatientsAsync();
        foreach(var pat in patients) 
        { 
            Patients.Add(_mapper.Map<PatientViewModel>(pat));
        }

        var doctors = await _apiClient.GetDoctorAsync();
        foreach (var doc in doctors)
        {
            Doctors.Add(_mapper.Map<DoctorViewModel>(doc));
        }
    }
}
