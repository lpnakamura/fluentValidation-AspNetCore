using System.Threading;
using System.Threading.Tasks;
using CQSSample.Commands;
using CQSSample.Domain.Entity;
using CQSSample.Infra.Repository;
using MediatR;

namespace CQSSample.CommandHandlers
{
    public class UserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Save(new UserEntity()
            {
                Gender = request.Gender,
                Age = request.Age,
                Birthday = request.Birthday,
                Email = request.Email,
                Name = request.Name
            });
        }
    }
}