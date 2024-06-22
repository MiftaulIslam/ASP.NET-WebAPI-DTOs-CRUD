using dtos_practice.Data;
using dtos_practice.Models.Domains;
using dtos_practice.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dtos_practice.Repositories.Services
{
    public class UserRepository : IGenericCrud<UserModel>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException($"User with Id {id} not found");
            return user;
        }
        public async Task CreateAsync(UserModel entity)
        {
            var existingUser = await _context.Users
    .Where(u => u.Email.ToUpper() == entity.Email.ToUpper())
    .FirstOrDefaultAsync();
            if (existingUser != null) throw new Exception("User Already Exists");

            if (entity == null) throw new ArgumentNullException(nameof(entity), "The entity cannot be null");
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException($"User with Id {id} not found");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id,UserModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "The entity cannot be null");

            if (id<0) throw new Exception("Invalid Id");
            var user = await GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException($"User with id{id} not available");
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Contact = entity.Contact;
           _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}