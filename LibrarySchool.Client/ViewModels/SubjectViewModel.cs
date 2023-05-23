using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace LibrarySchool.Desktop.ViewModels;

/// <summary>
/// ViewModel of class subject
/// </summary>
public class SubjectViewModel : ViewModelBase
{
    private int _subjectId;
    /// <summary>
    /// Id of subject
    /// </summary>
    public int SubjectId
    {
        get => _subjectId;
        set => this.RaiseAndSetIfChanged(ref _subjectId, value);    
    }

    private string _subjectName = String.Empty;
    /// <summary>
    /// Name of subject
    /// </summary>
    [Required]
    public string SubjectName
    {
        get => _subjectName;
        set => this.RaiseAndSetIfChanged(ref _subjectName, value);
    }

    private int _yearStudy;
    /// <summary>
    /// Year study this subject
    /// </summary>
    public int YearStudy
    {
        get => _yearStudy;
        set => this.RaiseAndSetIfChanged(ref _yearStudy, value);    
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, SubjectViewModel> OnSubmitCommand { get; }

    /// <summary>
    /// Constructor for class SubjectViewModel
    /// </summary>
    public SubjectViewModel()
    {
        CanSubmit = this.WhenAnyValue(vm => vm.SubjectName).Select(subject => !String.IsNullOrEmpty(subject));
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}
