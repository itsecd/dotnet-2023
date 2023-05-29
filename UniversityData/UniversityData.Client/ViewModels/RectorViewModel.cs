using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class RectorViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _name = string.Empty;

    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _surname = string.Empty;

    [Required]
    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }

    private string _patronymic = string.Empty;

    [Required]
    public string Patronymic
    {
        get => _patronymic;
        set => this.RaiseAndSetIfChanged(ref _patronymic, value);
    }

    private string _degree = string.Empty;

    [Required]
    public string Degree
    {
        get => _degree;
        set => this.RaiseAndSetIfChanged(ref _degree, value);
    }

    private string _title = string.Empty;

    [Required]
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    private string _position = string.Empty;

    [Required]
    public string Position
    {
        get => _position;
        set => this.RaiseAndSetIfChanged(ref _position, value);
    }

    public ReactiveCommand<Unit, RectorViewModel> OnSubmitCommand { get; }

    public RectorViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
