using System;
using gestion_contacts.Models;
using System.Linq;
using Xamarin.Forms;

namespace gestion_contacts
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			ContactsList.ItemsSource = await App.ContactDb.GetAllAsync();
		}

		protected async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.CurrentSelection != null)
			{
				Contact contact = (Contact)e.CurrentSelection.FirstOrDefault();
				await Shell.Current.GoToAsync($"ContactForm?ContactId={contact.Id}");
			}
		}

		private async void OnNewContactClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("ContactForm?ContactId=0");
		}
	}
}
