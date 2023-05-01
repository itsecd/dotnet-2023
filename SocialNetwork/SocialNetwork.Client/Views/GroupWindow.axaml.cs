
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SocialNetwork.Client.ViewModels;
using System;

namespace SocialNetwork.Client.Views;
public partial class GroupWindow : ReactiveWindow<GroupViewModel>
{

	public GroupWindow()
	{
		InitializeComponent();

		this.WhenActivated(disposableElement
			=> disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
	}

	public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
	{
		Close();
	}
	
	public void ChangedGroupCreationDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
	{
		ViewModel!.CreationDate = new DateTime(groupCreationDate.SelectedDate!.Value.Year,
			groupCreationDate.SelectedDate.Value.Month, groupCreationDate.SelectedDate.Value.Day);
	}
}
