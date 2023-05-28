using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class UniversityViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _number = string.Empty;

    [Required]
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    private string _name = string.Empty;

    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _address = string.Empty;

    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private int _rectorId;

    public int RectorId
    {
        get => _rectorId;
        set => this.RaiseAndSetIfChanged(ref _rectorId, value);
    }

    private int _universityPropertyId;
    public int UniversityPropertyId
    {
        get => _universityPropertyId;
        set => this.RaiseAndSetIfChanged(ref _universityPropertyId, value);
    }

    private int _constructionPropertyId;
    public int ConstructionPropertyId
    {
        get => _constructionPropertyId;
        set => this.RaiseAndSetIfChanged(ref _constructionPropertyId, value);
    }
}
