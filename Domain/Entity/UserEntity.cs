using CQSSample.Commands;

namespace CQSSample.Domain.Entity
{
    public class UserEntity : CreateUserCommand
    {
        public int Id { get; set; }
    }
}