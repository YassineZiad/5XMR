using System.Collections.Generic;
using System.Threading.Tasks;
using gestion_contacts.Models;
using SQLite;

namespace gestion_contacts.Data
{
	public class ContactDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ContactDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Contact>().Wait();
		}

		public Task<List<Contact>> GetAllAsync()
		{
			return database.Table<Contact>().OrderBy(c => c.FirstName).ToListAsync();
		}

		public Task<Contact> GetByIdAsync(int id)
		{
			return database.Table<Contact>().FirstOrDefaultAsync(c => c.Id == id);
		}

		public Task<int> SaveAsync(Contact contact)
		{
			return contact.Id == 0 ? database.InsertAsync(contact) : database.UpdateAsync(contact);
		}

		public Task<int> DeleteAsync(Contact contact)
		{
			return database.DeleteAsync(contact);
		}
	}
}