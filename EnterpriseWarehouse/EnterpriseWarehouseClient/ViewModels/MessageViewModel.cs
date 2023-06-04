namespace EnterpriseWarehouseClient.ViewModels;
public class MessageViewModel : ViewModelBase
{
    public string Message { get; }

    public MessageViewModel(string message)
    {
        Message = message;
    }
}
