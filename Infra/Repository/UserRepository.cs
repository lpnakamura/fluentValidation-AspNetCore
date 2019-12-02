using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQSSample.Data;
using CQSSample.Domain.Entity;

namespace CQSSample.Infra.Repository {
    public class UserRepository : IUserRepository {
        private readonly DataContext _context;
        public UserRepository (DataContext dataContext) {
            _context = dataContext;
        }
        public async Task Delete (int id) {
            var userToRemove = _context.Users.FirstOrDefault (w => w.Id == id);

            if (userToRemove != null)
                await Task.Run (() => {
                    _context.Users.Remove (userToRemove);
                    _context.SaveChanges ();
                });
        }

        public async Task<IEnumerable<UserEntity>> GetAll () {
            return await Task.FromResult (_context.Users);
        }

        public async Task<UserEntity> GetById (int id) {
            var user = _context.Users.FirstOrDefault (w => w.Id == id);
            return await Task.FromResult (user);
        }

        public async Task<IEnumerable<UserEntity>> GetPaged (int page, int pageSize) {
            var pagedUsers = _context.Users.Skip (page * pageSize).Take (pageSize);
            return await Task.FromResult (pagedUsers);
        }

        public async Task Save (UserEntity user) {
            await Task.Run (() => {
                _context.Users.Add (user);
                _context.SaveChanges ();
            });
        }

        public async Task Update (int id, UserEntity user) {
            _context.Attach (user);
            _context.SaveChanges ();

            await Task.Run (() => {
                _context.Users.Update (user);
                _context.SaveChanges ();
            });
        }
    }
}