using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;

namespace Library.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BookViewModel> Books { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        RxApp.MainThreadScheduler.Schedule(LoadBooksAsync);
    }

    private async void LoadBooksAsync()
    {
        var books = await _apiClient.GetBooksAsync();
        foreach (var book in books)
        {
            Books.Add(_mapper.Map<BookViewModel>(book));
        }
    }
}