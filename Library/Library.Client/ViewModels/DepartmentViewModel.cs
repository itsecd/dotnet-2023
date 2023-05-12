using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Library.Client.ViewModels;
public class DepartmentViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private int _count;
    [Required]
    public int Count
    {
        set => this.RaiseAndSetIfChanged(ref _count, value);
        get => _count;
    }

    private int _bookId;
    [Required]
    public int BookId
    {
        set => this.RaiseAndSetIfChanged(ref _bookId, value);
        get => _bookId;
    }

    private int _typeDepartmentId;
    [Required]
    public int TypeDepartmentId
    {
        set => this.RaiseAndSetIfChanged(ref _typeDepartmentId, value);
        get => _typeDepartmentId;
    }

    public ReactiveCommand<Unit, DepartmentViewModel> OnSubmitCommand { get; }

    public DepartmentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
