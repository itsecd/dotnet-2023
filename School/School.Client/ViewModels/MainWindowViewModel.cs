using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using DynamicData;

namespace School.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ClassViewModel> Classes { get; } = new();

    private ClassViewModel? _selectedClass;

    public ClassViewModel? SelectedClass
    {
        get => _selectedClass;
        set => this.RaiseAndSetIfChanged(ref _selectedClass,value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ClassViewModel,ClassViewModel?> ShowClassDialog { get; }


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowClassDialog = new Interaction<ClassViewModel, ClassViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var classViewModel = await ShowClassDialog.Handle(new ClassViewModel());

            if (classViewModel != null)
            {
                var newClass = await _apiClient.PostClassAsync(_mapper.Map<ClassPostDto>(classViewModel));
                Classes.Add(_mapper.Map<ClassViewModel>(newClass));
            }
        }
        );

        OnChangeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var classViewModel = await ShowClassDialog.Handle(SelectedClass!);
            if (classViewModel != null)
            {
                await _apiClient.UpdateClassAsync(SelectedClass!.Id, _mapper.Map<ClassPostDto>(classViewModel));
                _mapper.Map(classViewModel, SelectedClass);
            }
        }, this.WhenAnyValue(vm => vm.SelectedClass).Select(selectClass => selectClass != null)
        );


        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {            
            await _apiClient.DeleteClassAsync(SelectedClass!.Id);
            Classes.Remove(SelectedClass);
        }, this.WhenAnyValue(vm => vm.SelectedClass).Select(selectClass => selectClass != null)
        );


        RxApp.MainThreadScheduler.Schedule(LoadClassesAsync);
    }

    private async void LoadClassesAsync()
    {
        var classes= await _apiClient.GetClassesAsync();
        foreach(var @class in classes)
        {
            Classes.Add(_mapper.Map<ClassViewModel>(@class));
        }
    }

}
