using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PoliclinicClient.ViewModels;
public class ShowDoctorTableViewModel : ViewModelBase
{
    public ObservableCollection<DoctorViewModel> Doctors { get; } = new();

    private DoctorViewModel? _selectedDoctor;
    public DoctorViewModel? SelectedDoctor
    {
        get => _selectedDoctor;
        set => this.RaiseAndSetIfChanged(ref _selectedDoctor, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<DoctorViewModel, DoctorViewModel?> ShowDoctorDialog { get; }

    public ShowDoctorTableViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowDoctorDialog = new Interaction<DoctorViewModel, DoctorViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var doctorViewModel = await ShowDoctorDialog.Handle(new DoctorViewModel());
            if (doctorViewModel != null)
            {
                var newDoctor = _mapper.Map<DoctorPostDto>(doctorViewModel);
                await _apiClient.AddDoctorAsync(newDoctor);
                Doctors.Add(_mapper.Map<DoctorViewModel>(newDoctor));
                Doctors.Clear();
                LoadDoctorsAsync();
            }

        });

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var doctorViewModel = await ShowDoctorDialog.Handle(SelectedDoctor!);
            if (doctorViewModel != null)
            {
                await _apiClient.UpdateDoctorAsync(SelectedDoctor!.Id, _mapper.Map<DoctorPostDto>(doctorViewModel));
                _mapper.Map(doctorViewModel, SelectedDoctor);
            }

        }, this.WhenAnyValue(vm => vm.SelectedDoctor).Select(selectDoctor => selectDoctor != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDoctorAsync(SelectedDoctor!.Id);
            Doctors.Remove(SelectedDoctor);

        }, this.WhenAnyValue(vm => vm.SelectedDoctor).Select(selectDoctor => selectDoctor != null));

        RxApp.MainThreadScheduler.Schedule(LoadDoctorsAsync);
    }

    private async void LoadDoctorsAsync()
    {
        var doctors = await _apiClient.GetDoctorsAsync();

        foreach (var doctor in doctors)
        {
            Doctors.Add(_mapper.Map<DoctorViewModel>(doctor));
        }
    }
}
