using ReactiveUI;

namespace PoliclinicClient.ViewModels;
public class Top5DiseasesViewModel : ViewModelBase
{
    private string _nameDisease = string.Empty;
    public string Conclusion
    {
        get => _nameDisease;
        set => this.RaiseAndSetIfChanged(ref _nameDisease, value);
    }
}
