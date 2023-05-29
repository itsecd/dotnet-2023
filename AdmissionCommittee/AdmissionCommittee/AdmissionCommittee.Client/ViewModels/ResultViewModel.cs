using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace AdmissionCommittee.Client.ViewModels;
public class ResultViewModel : ViewModelBase
{
    private int _idResult;
    public int IdResult
    {
        get => _idResult;
        set => this.RaiseAndSetIfChanged(ref _idResult, value);
    }


    private string _nameSubject = string.Empty;

    [Required]
    public string NameSubject
    {
        get => _nameSubject;
        set => this.RaiseAndSetIfChanged(ref _nameSubject, value);
    }

    private IObservable<bool> CanSubmit { get; }

    public ReactiveCommand<Unit, ResultViewModel> OnSubmitCommand { get; set; }

    public ResultViewModel()
    {
        CanSubmit = this.WhenAnyValue(vm => vm.NameSubject).Select(nameSubject => !!string.IsNullOrEmpty(nameSubject));
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}