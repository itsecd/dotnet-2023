using ReactiveUI;

namespace PonrfClient.ViewModels;
public class CustomerModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged( ref _id, value );
    }

    private string _fio = string.Empty;
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }
}
