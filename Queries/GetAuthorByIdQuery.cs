using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Queries
{
    public class GetAuthorByIdQuery:IRequest<AuthorDto>
    {
        public Guid _id;
        public GetAuthorByIdQuery(Guid id)
        {
            _id = id;
        }
    }
}
