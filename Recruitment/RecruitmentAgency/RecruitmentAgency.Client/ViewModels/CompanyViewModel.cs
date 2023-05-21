using ReactiveUI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace RecruitmentAgency.Client.ViewModels;
public class CompanyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _companyName = string.Empty;
    [Required]
    public string CompanyName { 
        get => _companyName;
        set => this.RaiseAndSetIfChanged(ref _companyName, value);
    }
    private string _contactName = string.Empty;
    [Required]
    public string ContactName {
        get => _contactName;
        set => this.RaiseAndSetIfChanged(ref _contactName, value); 
    }
    private string _telephone = string.Empty;
    public string Telephone {
        get => _telephone; 
        set => this.RaiseAndSetIfChanged(ref _telephone, value);
    } 
    public ReactiveCommand<Unit, CompanyViewModel> OnSubmitCommand { get; }
    public CompanyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
