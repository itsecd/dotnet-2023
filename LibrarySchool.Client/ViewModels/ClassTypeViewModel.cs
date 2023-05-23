using ReactiveUI;
using System;
using System.Reactive;

namespace LibrarySchool.Desktop.ViewModels;

/// <summary>
/// ViewModel of class type
/// </summary>
public class ClassTypeViewModel : ViewModelBase
{
    private int _classId;

    /// <summary>
    /// Id of class
    /// </summary>
    public int ClassId
    {
        get => _classId;
        set => this.RaiseAndSetIfChanged(ref _classId, value);
    }
    private int _number;

    /// <summary>
    /// Number of class
    /// </summary>
    public int Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }
    private string _letter = String.Empty;

    /// <summary>
    /// Letter of class
    /// </summary>
    public string Letter
    {
        get => _letter;
        set => this.RaiseAndSetIfChanged(ref _letter, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Binding command for button Submit
    /// </summary>
    public ReactiveCommand<Unit, ClassTypeViewModel> OnSubmitCommand { get; }

    /// <summary>
    /// Constructor class 
    /// </summary>
    public ClassTypeViewModel()
    {
        CanSubmit = this.WhenAnyValue(
            vm => vm.Letter,
            (letter) => !String.IsNullOrEmpty(letter));

        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}
