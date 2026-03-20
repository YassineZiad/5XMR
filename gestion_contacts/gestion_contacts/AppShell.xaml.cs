using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gestion_contacts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell
	{
		public AppShell()
		{
			InitializeComponent();
			// Enregistrement de la route pour la page de formulaire
			Routing.RegisterRoute("ContactForm", typeof(ContactForm));
		}
	}
}