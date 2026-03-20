using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestion_contacts.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gestion_contacts
{
	[QueryProperty(nameof(ContactId), nameof(ContactId))]
	public partial class ContactForm : ContentPage
	{
		public ContactForm()
		{
			InitializeComponent();
			BindingContext = new Contact();
		}

		public string ContactId
		{
			set => LoadContact(value);
		}

		private async void LoadContact(string id)
		{
			try
			{
				var contact = await App.ContactDb.GetByIdAsync(Convert.ToInt32(id));

				BindingContext = contact;
			}
			catch (Exception)
			{
				Console.WriteLine("Failed to load contact.");
			}
		}

		private async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var contact = (Contact)BindingContext;
			if (!string.IsNullOrWhiteSpace(contact.FirstName) && !string.IsNullOrWhiteSpace(contact.LastName) && !string.IsNullOrWhiteSpace(contact.GSMNumber))
			{
				await App.ContactDb.SaveAsync(contact);
			}

			await Shell.Current.GoToAsync("..");
		}

		private async void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			var contact = (Contact)BindingContext;
			await App.ContactDb.DeleteAsync(contact);

			await Shell.Current.GoToAsync("..");
		}
	}
}