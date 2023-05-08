using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Library.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BookViewModel> Books { get; } = new();

    private BookViewModel? _selectedBook;
    public BookViewModel? SelectedBook
    {
        get => _selectedBook;
        set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnEditCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public Interaction<BookViewModel, BookViewModel?> ShowBookDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBookDialog = new Interaction<BookViewModel, BookViewModel?>();

        OnAddCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bookViewModel = await ShowBookDialog.Handle(new BookViewModel());
            if (bookViewModel != null)
            {
                var newBook = await _apiClient.AddBookAsync(_mapper.Map<BookPostDto>(bookViewModel));
                Books.Add(_mapper.Map<BookViewModel>(newBook));
            }
        });

        OnEditCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bookViewModel = await ShowBookDialog.Handle(SelectedBook!);
            if (bookViewModel != null)
            {
                await _apiClient.UpdateBookAsync(SelectedBook!.Id, _mapper.Map<BookPostDto>(bookViewModel));
                _mapper.Map(bookViewModel, SelectedBook);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBook).Select(selectBook => selectBook != null));

        OnDeleteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBookAsync(SelectedBook!.Id);
            Books.Remove(SelectedBook);
        }, this.WhenAnyValue(vm => vm.SelectedBook).Select(selectBook => selectBook != null));

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