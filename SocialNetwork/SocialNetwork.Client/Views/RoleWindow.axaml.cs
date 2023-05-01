
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SocialNetwork.Client.ViewModels;
using System;

namespace SocialNetwork.Client.Views;
public partial class RoleWindow : ReactiveWindow<RoleViewModel>
{
	public RoleWindow()
	{
		InitializeComponent();

		this.WhenActivated(disposableElement 
			=> disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
	}

	public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
	{
		Close();
	}
}
