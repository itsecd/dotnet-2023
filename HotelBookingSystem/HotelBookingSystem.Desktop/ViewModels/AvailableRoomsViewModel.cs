using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;

namespace HotelBookingSystem.Desktop.ViewModels;
public class AvailableRoomsViewModel : ViewModelBase
{
    public ObservableCollection<RoomViewModel> AvailableRoomsResult { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    private string _nameOfCity = string.Empty;
    public string NameOfCity
    {
        get => _nameOfCity;
        set => this.RaiseAndSetIfChanged(ref _nameOfCity, value);
    }

    public ReactiveCommand<Unit, Unit> SearchByCityCommand { get; }

    private async Task LoadDataAsync()
    {
        AvailableRoomsResult.Clear();
        var result = await _apiClient.AvailableRoomsAsync(NameOfCity);
        foreach (var room in result)
        {
            AvailableRoomsResult.Add(_mapper.Map<RoomViewModel>(room));
        }
    }

    public AvailableRoomsViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        SearchByCityCommand = ReactiveCommand.CreateFromTask(LoadDataAsync);
    }
}
