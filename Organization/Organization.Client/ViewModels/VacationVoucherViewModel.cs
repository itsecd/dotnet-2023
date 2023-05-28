using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class VacationVoucherViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _voucherTypeId;
    [Required]
    public int VoucherTypeId
    {
        get => _voucherTypeId;
        set => this.RaiseAndSetIfChanged(ref _voucherTypeId, value);
    }

    public DateTimeOffset? _issueDate;
    [Required]
    public DateTimeOffset? IssueDate
    {
        get => _issueDate;
        set => this.RaiseAndSetIfChanged(ref _issueDate, value);
    }

    public ReactiveCommand<Unit, VacationVoucherViewModel> OnSubmitCommand { get; }

    public VacationVoucherViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
