using System.Collections.Generic;
using CQSSample.Domain.Entity;
using MediatR;

namespace CQSSample.Domain.Queries {
    public class GetPagedUsersQuery : IRequest<IEnumerable<UserEntity>> {
        public GetPagedUsersQuery (int page, int pageSize) {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; protected set; }
        public int PageSize { get; protected set; }

        public static GetPagedUsersQuery Create (int page, int pageSize) => new GetPagedUsersQuery (page, pageSize);

    }
}