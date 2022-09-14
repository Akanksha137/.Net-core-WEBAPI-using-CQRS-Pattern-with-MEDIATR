using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Demo.Models;
using WebAPI_Demo.Queries;
using WebAPI_Demo.Services;

namespace WebAPI_Demo.Handler
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        private IAuthorServices _services;
        private IMapper _mapper;
        public GetAuthorsQueryHandler(IAuthorServices services,IMapper mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors =  await _services.GetAuthors();
            var authorsToReturn = _mapper.Map< IEnumerable<AuthorDto>>(authors);

            return authorsToReturn;
        }

    }
}
