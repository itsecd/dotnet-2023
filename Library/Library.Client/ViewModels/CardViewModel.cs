using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Library.Client.ViewModels;
public class CardViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private DateTime _dateOfIssue;
    [Required]
    public DateTime DateOfIssue
    {
        set => this.RaiseAndSetIfChanged(ref _dateOfIssue, value);
        get => _dateOfIssue;
    }

    private DateTime _dateOfReturn;
    [Required]
    public DateTime DateOfReturn
    {
        set => this.RaiseAndSetIfChanged(ref _dateOfReturn, value);
        get => _dateOfReturn;
    }

    private int _dayCount;
    [Required]
    public int DayCount
    {
        set => this.RaiseAndSetIfChanged(ref _dayCount, value);
        get => _dayCount;
    }

    private int _bookId;
    [Required]
    public int BookId
    {
        set => this.RaiseAndSetIfChanged(ref _bookId, value);
        get => _bookId;
    }

    private int _readerId;
    [Required]
    public int ReaderId
    {
        set => this.RaiseAndSetIfChanged(ref _readerId, value);
        get => _readerId;
    }

    public ReactiveCommand<Unit, CardViewModel> OnSubmitCommand { get; }

    public CardViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
