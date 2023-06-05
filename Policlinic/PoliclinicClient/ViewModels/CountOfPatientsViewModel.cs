using ReactiveUI;

namespace PoliclinicClient.ViewModels;
public class CountOfPatientsViewModel : ViewModelBase
{
    private int _count;
    public int Count
    {
        get => _count;
        set => this.RaiseAndSetIfChanged(ref _count, value);
    }

    private string _fioDoctor = string.Empty;
    public string Fio
    {
        get => _fioDoctor;
        set => this.RaiseAndSetIfChanged(ref _fioDoctor, value);
    }
}
