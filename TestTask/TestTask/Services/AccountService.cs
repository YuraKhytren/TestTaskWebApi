using Microsoft.EntityFrameworkCore;
using TestTask.DataBase;
using TestTask.Models;
using TestTask.Services.Interface;

namespace TestTask.Services
{
    public class AccountService : ICrudService<Account>
    {
        private readonly AppDbContext _db;
        public AccountService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<Account> CreateAsync(Account model)
        {
            if (model != null)
            {
                _db.Accounts.Add(model);
                await _db.SaveChangesAsync();
            }

            return model;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Account model = await _db.Accounts.FirstOrDefaultAsync(m => m.Id == id);

            if (model != null)
            {
                _db.Accounts.Remove(model);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _db.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(string id)
        {
            Account model = await _db.Accounts.FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                throw new NullReferenceException();
            }

            return model;
        }

        public async Task<Account> UpdateAsync(Account model)
        {
            if (model != null)
            {
                _db.Accounts.Update(model);
                await _db.SaveChangesAsync();

            }
            return model;
        }
    }
}
