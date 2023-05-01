
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SocialNetwork.Client.ViewModels;
using System;

namespace SocialNetwork.Client.Views;
public partial class UserWindow : ReactiveWindow<UserViewModel>
{
	public UserWindow()
	{
		InitializeComponent();

		this.WhenActivated(disposableElement 
			=> disposableElement(ViewModel!.OnSubmitCommand.Subscribe(Close)));
	}

	public void CancelButton_OnClick(object? sender, RoutedEventArgs e)
	{
		Close();
	}

	public void ChangedUserBirthDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
	{
		ViewModel!.BirthDate = new DateTime(userBirthDate.SelectedDate!.Value.Year,
			userBirthDate.SelectedDate.Value.Month, userBirthDate.SelectedDate.Value.Day);
	}

	public void ChangedUserRegistrationDateEvent(object sender, DatePickerSelectedValueChangedEventArgs e)
	{
		ViewModel!.RegistrationDate = new DateTime(userRegistrationDate.SelectedDate!.Value.Year,
			userRegistrationDate.SelectedDate.Value.Month, userRegistrationDate.SelectedDate.Value.Day);
	} 
}
