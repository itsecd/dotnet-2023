using Avalonia.Controls;
using System.Net.Http;

namespace SocialNetwork.Dekstop;
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		var client = new SocialNetworkClient("https://localhost:7299", new HttpClient());
	}
}