using ReactiveUI;
using System.Reactive;

namespace LibrarySchool.Client.ViewModels;

/// <summary>
/// ViewMode of QueryClass in query window
/// </summary>
public class QueryClassTypeViewModel : ViewModelBase
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

    /// <summary>
    /// Command binding for button Submit 
    /// </summary>
    public ReactiveCommand<Unit, QueryClassTypeViewModel> OnSubmitCommand { get; }

    /// <summary>
    /// Constructor for class QueryClassTypeViewModel
    /// </summary>
    public QueryClassTypeViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }

}
