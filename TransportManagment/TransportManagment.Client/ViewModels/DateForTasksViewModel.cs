using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportManagment.Client.ViewModels;
public class DateForTasksViewModel : ViewModelBase
{
    private double _timeTo = 0;
    public double TimeTo
    {
        get => _timeTo;
        set => this.RaiseAndSetIfChanged(ref _timeTo, value);
    }
    private double _timeFrom = 0;
    public double TimeFrom
    {
        get => _timeFrom;
        set => this.RaiseAndSetIfChanged(ref _timeFrom, value);
    }
    public ReactiveCommand<Unit, DateForTasksViewModel> OnSubmitCommand { get; }
    public DateForTasksViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
