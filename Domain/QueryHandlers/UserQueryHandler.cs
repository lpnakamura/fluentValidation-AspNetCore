using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQSSample.Domain.Entity;
using CQSSample.Domain.Queries;
using CQSSample.Infra.Repository;
using MediatR;

namespace CQSSample.Domain.QueryHandlers {
    public class UserQueryHandler : IRequestHandler<GetPagedUsersQuery, IEnumerable<UserEntity>> {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler (IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserEntity>> Handle (GetPagedUsersQuery request, CancellationToken cancellationToken) {
            return await _userRepository.GetPaged(request.Page, request.PageSize);
        }
    }
}