using AutoMapper;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace SelectionCommittee.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private EnrolleeViewModel? _selectedEnrollee;

    private string _enrolleeExceptionValue = string.Empty;

    private DateTimeOffset _enrolleeBirthDate;

    public DateTimeOffset EnrolleeBirthDate
    {
        get => _enrolleeBirthDate;
        set => this.RaiseAndSetIfChanged(ref _enrolleeBirthDate, value);
    }

    public string EnrolleeExceptionValue
    {
        get => _enrolleeExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _enrolleeExceptionValue, value);
    }

    private string _examResultExceptionValue = string.Empty;

    public string ExamResultExceptionValue
    {
        get => _examResultExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _examResultExceptionValue, value);
    }

    private string _facultyExceptionValue = string.Empty;

    public string FacultyExceptionValue
    {
        get => _facultyExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _facultyExceptionValue, value);
    }

    private string _specializationExceptionValue = string.Empty;

    public string SpecializationExceptionValue
    {
        get => _specializationExceptionValue;
        set => this.RaiseAndSetIfChanged(ref _specializationExceptionValue, value);
    }

    public EnrolleeViewModel? SelectedEnrollee
    {
        get => _selectedEnrollee;
        set => this.RaiseAndSetIfChanged(ref _selectedEnrollee, value);
    }

    private ExamResultViewModel? _selectedExamResult;

    public ExamResultViewModel? SelectedExamResult
    {
        get => _selectedExamResult;
        set => this.RaiseAndSetIfChanged(ref _selectedExamResult, value);
    }

    private FacultyViewModel? _selectedFaculty;

    public FacultyViewModel? SelectedFaculty
    {
        get => _selectedFaculty;
        set => this.RaiseAndSetIfChanged(ref _selectedFaculty, value);
    }

    private SpecializationViewModel? _selectedSpecialization;

    public SpecializationViewModel? SelectedSpecialization
    {
        get => _selectedSpecialization;
        set => this.RaiseAndSetIfChanged(ref _selectedSpecialization, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<EnrolleeViewModel> Enrollees { get; } = new();

    public ObservableCollection<ExamResultViewModel> ExamResults { get; } = new();

    public ObservableCollection<FacultyViewModel> Faculties { get; } = new();

    public ObservableCollection<SpecializationViewModel> Specializations { get; } = new();

    public ReactiveCommand<Unit, Unit> OnAddEnrolleeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeEnrolleeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteEnrolleeCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddExamResultCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeExamResultCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteExamResultCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddFacultyCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeFacultyCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteFacultyCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddSpecializationCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnChangeSpecializationCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteSpecializationCommand { get; set; }

    public Interaction<EnrolleeViewModel, EnrolleeViewModel?> ShowEnrolleeDialog { get; set; }

    public Interaction<ExamResultViewModel, ExamResultViewModel?> ShowExamResultDialog { get; set; }

    public Interaction<FacultyViewModel, FacultyViewModel?> ShowFacultyDialog { get; set; }

    public Interaction<SpecializationViewModel, SpecializationViewModel?> ShowSpecializationDialog { get; set; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowEnrolleeDialog = new Interaction<EnrolleeViewModel, EnrolleeViewModel?>();
        ShowExamResultDialog = new Interaction<ExamResultViewModel, ExamResultViewModel?>();
        ShowFacultyDialog = new Interaction<FacultyViewModel, FacultyViewModel?>();
        ShowSpecializationDialog = new Interaction<SpecializationViewModel, SpecializationViewModel?>();

        RxApp.MainThreadScheduler.Schedule(LoadEnrolleesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadExamResultsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadFacultiesAsync);
        RxApp.MainThreadScheduler.Schedule(LoadSpecializationsAsync);

        OnAddEnrolleeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enrolleeViewModel = await ShowEnrolleeDialog.Handle(new EnrolleeViewModel());

            if (enrolleeViewModel != null)
            {
                try
                {
                    enrolleeViewModel.Id = await _apiClient
                        .AddEnrolleeAsync(_mapper.Map<EnrolleeDtoPostOrPut>(enrolleeViewModel));
                    Enrollees.Add(enrolleeViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    EnrolleeExceptionValue = ex.Message;
                }
            }
        });

        OnChangeEnrolleeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var enrolleeViewModel = await ShowEnrolleeDialog.Handle(SelectedEnrollee!);

            if (enrolleeViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateEnrolleeAsync(SelectedEnrollee!.Id,
                        _mapper.Map<EnrolleeDtoPostOrPut>(enrolleeViewModel));
                    _mapper.Map(enrolleeViewModel, SelectedEnrollee);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    EnrolleeExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedEnrollee)
            .Select(selectEnrollee => selectEnrollee != null));

        OnDeleteEnrolleeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteEnrolleeAsync(SelectedEnrollee!.Id);

                foreach (var note in ExamResults.Where(examResult => examResult.EnrolleeId == SelectedEnrollee!.Id).ToList())
                {
                    ExamResults.Remove(note);
                }

                Enrollees.Remove(SelectedEnrollee!);
                ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                EnrolleeExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedEnrollee)
            .Select(selectEnrollee => selectEnrollee != null));

        OnAddExamResultCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var examResultViewModel = await ShowExamResultDialog.Handle(new ExamResultViewModel());

            if (examResultViewModel != null)
            {
                try
                {
                    examResultViewModel.Id = await _apiClient
                        .AddExamResultAsync(_mapper.Map<ExamResultDtoPostOrPut>(examResultViewModel));
                    ExamResults.Add(examResultViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    ExamResultExceptionValue = ex.Message;
                }
            }
        });

        OnChangeExamResultCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var examResultViewModel = await ShowExamResultDialog.Handle(SelectedExamResult!);

            if (examResultViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateExamResultAsync(SelectedExamResult!.Id,
                        _mapper.Map<ExamResultDtoPostOrPut>(examResultViewModel));
                    _mapper.Map(examResultViewModel, SelectedExamResult);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    ExamResultExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedExamResult)
            .Select(selectExamResult => selectExamResult != null));

        OnDeleteExamResultCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteExamResultAsync(SelectedExamResult!.Id);

                ExamResults.Remove(SelectedExamResult!);
                ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                ExamResultExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedExamResult)
            .Select(selectExamResult => selectExamResult != null));

        OnAddFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultyDialog.Handle(new FacultyViewModel());

            if (facultyViewModel != null)
            {
                try
                {
                    facultyViewModel.Id = await _apiClient
                        .AddFacultyAsync(_mapper.Map<FacultyDtoPostOrPut>(facultyViewModel));
                    Faculties.Add(facultyViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    FacultyExceptionValue = ex.Message;
                }
            }
        });

        OnChangeFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var facultyViewModel = await ShowFacultyDialog.Handle(SelectedFaculty!);

            if (facultyViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateFacultyAsync(SelectedFaculty!.Id,
                        _mapper.Map<FacultyDtoPostOrPut>(facultyViewModel));
                    _mapper.Map(facultyViewModel, SelectedFaculty);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    FacultyExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedFaculty)
            .Select(selectFaculty => selectFaculty != null));

        OnDeleteFacultyCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteFacultyAsync(SelectedFaculty!.Id);

                foreach (var specialization in Specializations
                    .Where(specialization => specialization.FacultyId == SelectedFaculty!.Id).ToList())
                {
                    Specializations.Remove(specialization);
                }

                Faculties.Remove(SelectedFaculty!);
                ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                FacultyExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedFaculty)
            .Select(selectFaculty => selectFaculty != null));

        OnAddSpecializationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specializationViewModel = await ShowSpecializationDialog.Handle(new SpecializationViewModel());

            if (specializationViewModel != null)
            {
                try
                {
                    specializationViewModel.Id = await _apiClient
                        .AddSpecializationAsync(_mapper.Map<SpecializationDtoPostOrPut>(specializationViewModel));
                    Specializations.Add(specializationViewModel);

                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    SpecializationExceptionValue = ex.Message;
                }
            }
        });

        OnChangeSpecializationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var specializationViewModel = await ShowSpecializationDialog.Handle(SelectedSpecialization!);

            if (specializationViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateSpecializationAsync(SelectedSpecialization!.Id,
                        _mapper.Map<SpecializationDtoPostOrPut>(specializationViewModel));
                    _mapper.Map(specializationViewModel, SelectedSpecialization);
                    ClearExceptionsValues();
                }
                catch (Exception ex)
                {
                    SpecializationExceptionValue = ex.Message;
                }

            }
        }, this.WhenAnyValue(viewModel => viewModel.SelectedSpecialization)
            .Select(selectSpecialization => selectSpecialization != null));

        OnDeleteSpecializationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                await _apiClient.DeleteSpecializationAsync(SelectedSpecialization!.Id);

                Specializations.Remove(SelectedSpecialization!);
                ClearExceptionsValues();
            }
            catch (Exception ex)
            {
                SpecializationExceptionValue = ex.Message;
            }

        }, this.WhenAnyValue(viewModel => viewModel.SelectedSpecialization)
            .Select(selectSpecialization => selectSpecialization != null));
    }

    public async void LoadEnrolleesAsync()
    {
        var enrollees = await _apiClient.GetEnrolleesAsync();

        foreach (var enrollee in enrollees)
        {
            Enrollees.Add(_mapper.Map<EnrolleeViewModel>(enrollee));
        }
    }

    public async void LoadExamResultsAsync()
    {
        var examResults = await _apiClient.GetExamResultsAsync();

        foreach (var examResult in examResults)
        {
            ExamResults.Add(_mapper.Map<ExamResultViewModel>(examResult));
        }
    }

    public async void LoadFacultiesAsync()
    {
        var faculties = await _apiClient.GetFacultiesAsync();

        foreach (var faculty in faculties)
        {
            Faculties.Add(_mapper.Map<FacultyViewModel>(faculty));
        }
    }

    public async void LoadSpecializationsAsync()
    {
        var specializations = await _apiClient.GetSpecializationsAsync();

        foreach (var specialization in specializations)
        {
            Specializations.Add(_mapper.Map<SpecializationViewModel>(specialization));
        }
    }

    private void ClearExceptionsValues()
    {
        EnrolleeExceptionValue = string.Empty;
        ExamResultExceptionValue = string.Empty;
        FacultyExceptionValue = string.Empty;
        SpecializationExceptionValue = string.Empty;
    }
}
