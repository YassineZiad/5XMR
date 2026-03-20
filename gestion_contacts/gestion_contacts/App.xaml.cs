using System;
using System.IO;
using gestion_contacts.Data;
using Xamarin.Forms;

namespace gestion_contacts
{
	public partial class App : Application
	{
		static ContactDatabase db;
		public static ContactDatabase ContactDb
		{
			get
			{
				if (db == null)
				{
					db = new ContactDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.db3"));
				}
				return db;
			}
		}

		public App()
		{
			InitializeComponent();
			MainPage = new AppShell();
		}
	}
}
