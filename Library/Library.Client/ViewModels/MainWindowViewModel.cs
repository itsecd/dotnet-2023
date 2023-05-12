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

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ObservableCollection<BookViewModel> Books { get; } = new();
    public ObservableCollection<CardViewModel> Cards { get; } = new();
    public ObservableCollection<DepartmentViewModel> Departments { get; } = new();
    public ObservableCollection<ReaderViewModel> Readers { get; } = new();
    public ObservableCollection<TypeEditionViewModel> TypesEditions { get; } = new();
    public ObservableCollection<TypeDepartmentViewModel> TypesDepartments { get; } = new();
    public ObservableCollection<BookViewModel> BooksByCipher { get; } = new();
    public ObservableCollection<BookViewModel> AllBooks { get; } = new();
    public ObservableCollection<DepartmentViewModel> AvailabilityBooks { get; } = new();
    public ObservableCollection<DepartmentViewModel> BooksEachDepartment { get; } = new();
    public ObservableCollection<ReaderViewModel> TopReaders { get; } = new();
    public ObservableCollection<ReaderViewModel> DelayReaders { get; } = new();

    private BookViewModel? _selectedBook;
    public BookViewModel? SelectedBook
    {
        get => _selectedBook;
        set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
    }

    private CardViewModel? _selectedCard;
    public CardViewModel? SelectedCard
    {
        get => _selectedCard;
        set => this.RaiseAndSetIfChanged(ref _selectedCard, value);
    }

    private DepartmentViewModel? _selectedDepartment;
    public DepartmentViewModel? SelectedDepartment
    {
        get => _selectedDepartment;
        set => this.RaiseAndSetIfChanged(ref _selectedDepartment, value);
    }

    private ReaderViewModel? _selectedReader;
    public ReaderViewModel? SelectedReader
    {
        get => _selectedReader;
        set => this.RaiseAndSetIfChanged(ref _selectedReader, value);
    }

    public ReactiveCommand<Unit, Unit> OnAddBookCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditBookCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteBookCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddCardCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditCardCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCardCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditDepartmentCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteDepartmentCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnAddReaderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnEditReaderCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteReaderCommand { get; set; }

    public Interaction<BookViewModel, BookViewModel?> ShowBookDialog { get; }
    public Interaction<CardViewModel, CardViewModel?> ShowCardDialog { get; }
    public Interaction<DepartmentViewModel, DepartmentViewModel?> ShowDepartmentDialog { get; }
    public Interaction<ReaderViewModel, ReaderViewModel?> ShowReaderDialog { get; }

    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowBookDialog = new Interaction<BookViewModel, BookViewModel?>();
        ShowCardDialog = new Interaction<CardViewModel, CardViewModel?>();
        ShowDepartmentDialog = new Interaction<DepartmentViewModel, DepartmentViewModel?>();
        ShowReaderDialog = new Interaction<ReaderViewModel, ReaderViewModel?>();

        OnAddBookCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bookViewModel = await ShowBookDialog.Handle(new BookViewModel());
            if (bookViewModel != null)
            {
                var newBook = await _apiClient.AddBookAsync(_mapper.Map<BookPostDto>(bookViewModel));
                Books.Add(_mapper.Map<BookViewModel>(newBook));
            }
        });

        OnEditBookCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var bookViewModel = await ShowBookDialog.Handle(SelectedBook!);
            if (bookViewModel != null)
            {
                await _apiClient.UpdateBookAsync(SelectedBook!.Id, _mapper.Map<BookPostDto>(bookViewModel));
                _mapper.Map(bookViewModel, SelectedBook);
            }
        }, this.WhenAnyValue(vm => vm.SelectedBook).Select(selectBook => selectBook != null));

        OnDeleteBookCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteBookAsync(SelectedBook!.Id);
            Books.Remove(SelectedBook);
        }, this.WhenAnyValue(vm => vm.SelectedBook).Select(selectBook => selectBook != null));

        OnAddCardCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var cardViewModel = await ShowCardDialog.Handle(new CardViewModel());
            if (cardViewModel != null)
            {
                var newCard = await _apiClient.AddCardAsync(_mapper.Map<CardPostDto>(cardViewModel));
                Cards.Add(_mapper.Map<CardViewModel>(newCard));
            }
        });

        OnEditCardCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var cardViewModel = await ShowCardDialog.Handle(SelectedCard!);
            if (cardViewModel != null)
            {
                await _apiClient.UpdateCardAsync(SelectedCard!.Id, _mapper.Map<CardPostDto>(cardViewModel));
                _mapper.Map(cardViewModel, SelectedCard);
            }
        }, this.WhenAnyValue(vm => vm.SelectedCard).Select(selectCard => selectCard != null));

        OnDeleteCardCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteCardAsync(SelectedCard!.Id);
            Cards.Remove(SelectedCard);
        }, this.WhenAnyValue(vm => vm.SelectedCard).Select(selectCard => selectCard != null));

        OnAddDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(new DepartmentViewModel());
            if (departmentViewModel != null)
            {
                var newDepartment = await _apiClient.AddDepartmentAsync(_mapper.Map<DepartmentPostDto>(departmentViewModel));
                Departments.Add(_mapper.Map<DepartmentViewModel>(newDepartment));
            }
        });

        OnEditDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var departmentViewModel = await ShowDepartmentDialog.Handle(SelectedDepartment!);
            if (departmentViewModel != null)
            {
                await _apiClient.UpdateDepartmentAsync(SelectedDepartment!.Id, _mapper.Map<DepartmentPostDto>(departmentViewModel));
                _mapper.Map(departmentViewModel, SelectedDepartment);
            }
        }, this.WhenAnyValue(vm => vm.SelectedDepartment).Select(selectDepartment => selectDepartment != null));

        OnDeleteDepartmentCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteDepartmentAsync(SelectedDepartment!.Id);
            Departments.Remove(SelectedDepartment);
        }, this.WhenAnyValue(vm => vm.SelectedDepartment).Select(selectDepartment => selectDepartment != null));

        OnAddReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var readerViewModel = await ShowReaderDialog.Handle(new ReaderViewModel());
            if (readerViewModel != null)
            {
                var newReader = await _apiClient.AddReaderAsync(_mapper.Map<ReaderPostDto>(readerViewModel));
                Readers.Add(_mapper.Map<ReaderViewModel>(newReader));
            }
        });

        OnEditReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var readerViewModel = await ShowReaderDialog.Handle(SelectedReader!);
            if (readerViewModel != null)
            {
                await _apiClient.UpdateReaderAsync(SelectedReader!.Id, _mapper.Map<ReaderPostDto>(readerViewModel));
                _mapper.Map(readerViewModel, SelectedReader);
            }
        }, this.WhenAnyValue(vm => vm.SelectedReader).Select(selectReader => selectReader != null));

        OnDeleteReaderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteReaderAsync(SelectedReader!.Id);
            Readers.Remove(SelectedReader);
        }, this.WhenAnyValue(vm => vm.SelectedReader).Select(selectReader => selectReader != null));

        RxApp.MainThreadScheduler.Schedule(LoadBooksAsync);
        //RxApp.MainThreadScheduler.Schedule(LoadCardsAsync);
        //RxApp.MainThreadScheduler.Schedule(LoadDepartmentsAsync);
        //RxApp.MainThreadScheduler.Schedule(LoadReadersAsync);
        //RxApp.MainThreadScheduler.Schedule(LoadTypesEditionsAsync);
        //RxApp.MainThreadScheduler.Schedule(LoadTypesDepartmentsAsync);
    }

    private async void LoadBooksAsync()
    {
        var books = await _apiClient.GetBooksAsync();
        foreach (var book in books)
        {
            Books.Add(_mapper.Map<BookViewModel>(book));
        }
    }

    private async void LoadCardsAsync()
    {
        var cards = await _apiClient.GetCardsAsync();
        foreach (var card in cards)
        {
            Cards.Add(_mapper.Map<CardViewModel>(card));
        }
    }

    private async void LoadDepartmentsAsync()
    {
        var departments = await _apiClient.GetDepartmentsAsync();
        foreach (var department in departments)
        {
            Departments.Add(_mapper.Map<DepartmentViewModel>(department));
        }
    }

    private async void LoadReadersAsync()
    {
        var readers = await _apiClient.GetReadersAsync();
        foreach (var reader in readers)
        {
            Readers.Add(_mapper.Map<ReaderViewModel>(reader));
        }
    }

    private async void LoadTypesEditionsAsync()
    {
        var types = await _apiClient.GetTypeEditionsAsync();
        foreach (var type in types)
        {
            TypesEditions.Add(_mapper.Map<TypeEditionViewModel>(type));
        }
    }

    private async void LoadTypesDepartmentsAsync()
    {
        var types = await _apiClient.GetTypeDepartmentsAsync();
        foreach (var type in types)
        {
            TypesDepartments.Add(_mapper.Map<TypeDepartmentViewModel>(type));
        }
    }
}