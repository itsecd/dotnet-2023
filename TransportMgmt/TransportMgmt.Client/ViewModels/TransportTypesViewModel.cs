using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace TransportMgmt.Client.ViewModels;

public class TransportTypesViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _typeName = string.Empty;
    [Required]
    public string TypeName
    {
        get => _typeName;
        set => this.RaiseAndSetIfChanged(ref _typeName, value);
    }
}
