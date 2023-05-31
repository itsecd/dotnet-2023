using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace TransportMgmt.Client.ViewModels;

public class ModelViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _modelName = string.Empty;
    [Required]
    public string ModelName
    {
        get => _modelName;
        set => this.RaiseAndSetIfChanged(ref _modelName, value);
    }

    private string _floorLevel = string.Empty;
    [Required]
    public string FloorLevel
    {
        get => _floorLevel;
        set => this.RaiseAndSetIfChanged(ref _floorLevel, value);
    }

    private int _maxCapacity;
    [Required]
    public int MaxCapacity
    {
        get => _maxCapacity;
        set => this.RaiseAndSetIfChanged(ref _maxCapacity, value);
    }
    public ReactiveCommand<Unit, ModelViewModel> ModelOnSubmitCommand { get; }

    public ModelViewModel()
    {
        ModelOnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
