using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PoliclinicClient.ViewModels;
public class ShowPatientTableViewModel : ViewModelBase
{
    public ObservableCollection<PatientViewModel> Patients { get; } = new();

    private PatientViewModel? _selectedPatient;
    public PatientViewModel? SelectedPatient
    {
        get => _selectedPatient;
        set => this.RaiseAndSetIfChanged(ref _selectedPatient, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<PatientViewModel, PatientViewModel?> ShowPatientDialog { get; }

    public ShowPatientTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowPatientDialog = new Interaction<PatientViewModel, PatientViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var patientViewModel = await ShowPatientDialog.Handle(new PatientViewModel());
            if (patientViewModel != null)
            {
                var newPatient = _mapper.Map<PatientPostDto>(patientViewModel);
                await _apiClient.AddPatientAsync(newPatient);
                Patients.Add(_mapper.Map<PatientViewModel>(newPatient));
                Patients.Clear();
                LoadPatientsAsync();
            }

        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var patientViewModel = await ShowPatientDialog.Handle(SelectedPatient!);
            if (patientViewModel != null)
            {
                await _apiClient.UpdatePatientAsync(SelectedPatient!.Id, _mapper.Map<PatientPostDto>(patientViewModel));
                _mapper.Map(patientViewModel, SelectedPatient);
            }

        }, this.WhenAnyValue(vm => vm.SelectedPatient).Select(selectPatient => selectPatient != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeletePatientAsync(SelectedPatient!.Id);
            Patients.Remove(SelectedPatient);

        }, this.WhenAnyValue(vm => vm.SelectedPatient).Select(selectPatient => selectPatient != null));

        RxApp.MainThreadScheduler.Schedule(LoadPatientsAsync);
    }

    private async void LoadPatientsAsync()
    {
        var patients = await _apiClient.GetPatientsAsync();

        foreach (var patient in patients)
        {
            Patients.Add(_mapper.Map<PatientViewModel>(patient));
        }
    }
}
