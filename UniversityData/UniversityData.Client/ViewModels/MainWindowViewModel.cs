using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using Splat;

namespace UniversityData.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<ConstructionPropertyViewModel> ConstructionProperties { get; } = new();

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?> ShowProductDialog { get; }


    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowProductDialog = new Interaction<ConstructionPropertyViewModel, ConstructionPropertyViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
        var constructionPropertyViewModel = await ShowProductDialog.Handle(new ConstructionPropertyViewModel());
        if (constructionPropertyViewModel != null)
            {
                var newConstructionProperty = await _apiClient.AddConstructionPropertyAsync(_mapper.Map<ConstructionPropertyPostDto>(constructionPropertyViewModel));
                ConstructionProperties.Add(_mapper.Map<ConstructionPropertyViewModel>(newConstructionProperty));
            }
        });

        RxApp.MainThreadScheduler.Schedule(LoadConsturctionPropertiesAsync);
    }

    private async void LoadConsturctionPropertiesAsync()
    {
        var constructionProperties = await _apiClient.GetConstructionPropertyAsync();
        foreach (var constructionProperty in constructionProperties)
        {
            ConstructionProperties.Add(_mapper.Map<ConstructionPropertyViewModel>(constructionProperty));
        }
    }
}
