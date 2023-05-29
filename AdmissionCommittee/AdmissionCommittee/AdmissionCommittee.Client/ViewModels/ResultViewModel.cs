using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of Result
/// </summary>
public class ResultViewModel : ViewModelBase
{
    private int _idResult;

    /// <summary>
    /// Id of Result
    /// </summary>
    public int IdResult
    {
        get => _idResult;
        set => this.RaiseAndSetIfChanged(ref _idResult, value);
    }


    private string _nameSubject = string.Empty;

    /// <summary>
    /// Name subject of Entrant
    /// </summary>
    [Required]
    public string NameSubject
    {
        get => _nameSubject;
        set => this.RaiseAndSetIfChanged(ref _nameSubject, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, ResultViewModel> OnSubmitCommand { get; set; }

    public ResultViewModel()
    {
        CanSubmit = this.WhenAnyValue(vm => vm.NameSubject).Select(nameSubject => !!string.IsNullOrEmpty(nameSubject));
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}