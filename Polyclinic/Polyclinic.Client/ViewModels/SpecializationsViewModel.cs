using System.Reactive;
using ReactiveUI;

namespace Polyclinic.Client.ViewModels;
public class SpecializationsViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _nameSpecialization = string.Empty;
    public string NameSpecialization
    {
        get => _nameSpecialization;
        set => this.RaiseAndSetIfChanged(ref _nameSpecialization, value);
    }
    public ReactiveCommand<Unit, SpecializationsViewModel> OnSumbitCommand { get; }
    public SpecializationsViewModel()
    {
        OnSumbitCommand = ReactiveCommand.Create(() => this);
    }
}
