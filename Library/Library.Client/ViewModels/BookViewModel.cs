using ReactiveUI;

namespace Library.Client.ViewModels;
public class BookViewModel : ViewModelBase
{
    private int _id;
    public int Id 
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _cipher = string.Empty;
    public string Cipher 
    { 
        set => this.RaiseAndSetIfChanged(ref _cipher, value);
        get => _cipher;
    }

    private string _author = string.Empty;
    public string Author 
    { 
        set => this.RaiseAndSetIfChanged(ref _author, value);
        get => _author;
    } 

    private string _name = string.Empty;
    public string Name 
    { 
        set => this.RaiseAndSetIfChanged(ref _name, value);
        get => _name;
    } 

    private string _placeEdition = string.Empty;
    public string PlaceEdition 
    { 
        set => this.RaiseAndSetIfChanged(ref _placeEdition, value);
        get => _placeEdition;
    }

    private int _yearEdition;
    public int YearEdition 
    { 
        set => this.RaiseAndSetIfChanged(ref _yearEdition, value);
        get => _yearEdition;
    }

    private int _typeEditionId;
    public int TypeEditionId 
    { 
        set => this.RaiseAndSetIfChanged(ref _typeEditionId, value);
        get => _typeEditionId;
    }
}