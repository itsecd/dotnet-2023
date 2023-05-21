using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Client.ViewModels;
public class OwnershipFormViewModel : ViewModelBase
{
    private int _id;
    public int OwnershipFormID
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public ReactiveCommand<Unit, OwnershipFormViewModel> OnSubmitCommand { get; }
    public OwnershipFormViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
