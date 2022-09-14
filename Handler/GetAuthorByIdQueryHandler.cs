using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Demo.Entities;
using WebAPI_Demo.Models;
using WebAPI_Demo.Queries;
using WebAPI_Demo.Services;

namespace WebAPI_Demo.Handler
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private readonly IAuthorServices _services;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryHandler(IAuthorServices services,IMapper mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            if (request._id == null)
            {
                throw new ArgumentNullException(nameof(request._id));
            }
            var author = await _services.GetAuthorById(request._id);
            var authorToReturn = _mapper.Map<AuthorDto>(author);
            return authorToReturn;
        }
    }
}
