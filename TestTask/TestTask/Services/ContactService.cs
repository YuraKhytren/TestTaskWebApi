using Microsoft.EntityFrameworkCore;
using TestTask.DataBase;
using TestTask.Models;
using TestTask.Services.Interface;

namespace TestTask.Services
{
    public class ContactService : ICrudService<Contact>
    {
        private readonly AppDbContext _db;
        public ContactService(AppDbContext appDbContext) 
        { 
            _db = appDbContext;
        }
        public async Task<Contact> CreateAsync(Contact model)
        {
            if (model != null)
            {
                _db.Contacts.Add(model);
                await _db.SaveChangesAsync();
            }
            return model;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Contact model = await _db.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (model != null)
            {
                _db.Contacts.Remove(model);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _db.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(string id)
        {
            Contact model = await _db.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                throw new NullReferenceException();
            }

            return model;
        }

        public async Task<Contact> UpdateAsync(Contact model)
        {
            if (model != null)
            {
                _db.Contacts.Update(model);
                await _db.SaveChangesAsync();

            }
            return model;
        }
    }
}
