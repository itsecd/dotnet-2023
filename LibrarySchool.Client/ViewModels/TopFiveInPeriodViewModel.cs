using ReactiveUI;
using System;
using System.Reactive;

namespace LibrarySchool.Client.ViewModels;

/// <summary>
/// ViewModel of window get period
/// </summary>
public class TopFiveInPeriodViewModel : ViewModelBase
{

    private DateTimeOffset? _settedStartPeriod;
    /// <summary>
    /// Begin period
    /// </summary>
    public DateTimeOffset? SettedStartPeriod
    {
        get => _settedStartPeriod;
        set => this.RaiseAndSetIfChanged(ref _settedStartPeriod, value);
    }

    private DateTimeOffset? _settedEndPeriod;
    /// <summary>
    /// End period
    /// </summary>
    public DateTimeOffset? SettedEndPeriod
    {
        get => _settedEndPeriod;
        set => this.RaiseAndSetIfChanged(ref _settedEndPeriod, value);
    }

    /// <summary>
    /// Button submit is avalible or not
    /// </summary>
    public IObservable<bool> CanSubmit { get; set; }

    /// <summary>
    /// Command binding for button Submit
    /// </summary>
    public ReactiveCommand<Unit, TopFiveInPeriodViewModel> OnSubmitCommand { get; }

    /// <summary>
    /// Constructor of class TopFiveInPeriodViewModel
    /// </summary>
    public TopFiveInPeriodViewModel()
    {
        CanSubmit = this.WhenAnyValue(
            vm => vm.SettedStartPeriod,
            vm => vm.SettedEndPeriod,
            (start, end) => start != null && end != null);
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}
