

using System.Collections.Generic;
using System.Threading.Tasks;
using CQSSample.Domain.Entity;

namespace CQSSample.Infra.Repository {
    public interface IUserRepository {
        Task Save (UserEntity customer);
        Task Update (int id, UserEntity customer);
        Task Delete (int id);
        Task<UserEntity> GetById (int id);
        Task<IEnumerable<UserEntity>> GetAll ();
        Task<IEnumerable<UserEntity>> GetPaged (int page, int pageSize);
    }
}