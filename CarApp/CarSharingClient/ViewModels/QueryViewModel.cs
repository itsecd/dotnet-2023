using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace CarSharingClient.ViewModels;
public class QueryViewModel : ViewModelBase
{
    private int _rating;
    public int Rating
    {
        get => _rating;
        set => this.RaiseAndSetIfChanged(ref _rating, value);
    }
    
    private string _model = string.Empty;
    [Required]
    public string Model
    {
        get => _model;
        set => this.RaiseAndSetIfChanged(ref _model, value);
    }

    public ReactiveCommand<Unit, QueryViewModel> OnSubmitCommand { get; }

    public QueryViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
