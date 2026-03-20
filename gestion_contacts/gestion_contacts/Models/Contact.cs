using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace gestion_contacts.Models
{
	public class Contact
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string GSMNumber { get; set; }
		public string Email { get; set; }
		public string Note { get; set; }
	}
}