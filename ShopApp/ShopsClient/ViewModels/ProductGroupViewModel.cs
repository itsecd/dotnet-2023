using ReactiveUI;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ProductGroupViewModel : ViewModelBase
{
    private int _id;
    public int Id { 
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value); 
    }
    private string _groupName = string.Empty;
    public string GroupName { 
        get => _groupName; 
        set => this.RaiseAndSetIfChanged(ref _groupName, value); 
    }
    public ReactiveCommand<Unit, ProductGroupViewModel> OnSubmitCommand { get; }

    public ProductGroupViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
