using Microsoft.EntityFrameworkCore;
using TestTask.DataBase;
using TestTask.Models;
using TestTask.Services.Interface;

namespace TestTask.Services
{
    public class IncidentService : ICrudService<Incident>, ICreateValidator<Incident>
    {
        private readonly AppDbContext _db;
        public IncidentService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<Incident> CreateAsync(Incident model)
        {
            if (model != null && ValidateCreate(model) == true)
            {
                _db.Incidents.Add(model);
                await _db.SaveChangesAsync();
            }

            return model;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            Incident model = await _db.Incidents.FirstOrDefaultAsync(m => m.Name == id);

            if (model != null)
            {
                _db.Incidents.Remove(model);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await _db.Incidents.ToListAsync();
        }

        public async Task<Incident> GetByIdAsync(string id)
        {
            Incident model = await _db.Incidents.FirstOrDefaultAsync(m => m.Name == id);

            if (model == null)
            {
                throw new NullReferenceException();
            }

            return model;
        }

        public async Task<Incident> UpdateAsync(Incident model)
        {
            if (model != null)
            {
                _db.Incidents.Update(model);
                await _db.SaveChangesAsync();

            }
            return model;
        }

        public bool ValidateCreate(Incident model)
        {
            if (model.Accounts.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
