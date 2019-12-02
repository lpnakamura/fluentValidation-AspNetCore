using System.Linq;
using System.Threading.Tasks;
using CQSSample.Commands;
using CQSSample.Domain.Notification;
using CQSSample.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQSSample.Controllers
{
    [Route ("api/users")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly IDomainNotificationContext _notificationContext;

        public UserController (IMediator mediator, IDomainNotificationContext notificationContext) {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser ([FromBody] CreateUserCommand command) {
            await _mediator.Send (command);
            
            if (_notificationContext.HasErrorNotifications) {
                var notifications = _notificationContext.GetErrorNotifications ();
                var message = string.Join (", ", notifications.Select (failure => failure));
                return BadRequest (message);
            }

            return Ok ();
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync ([FromQuery] int page = 1, [FromQuery] int pageSize = 10) {
            var query = GetPagedUsersQuery.Create (page, pageSize);
            var pagedUsers = await _mediator.Send (query);
            return Ok (pagedUsers);
        }
    }
}