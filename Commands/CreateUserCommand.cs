using System;
using MediatR;

namespace CQSSample.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}