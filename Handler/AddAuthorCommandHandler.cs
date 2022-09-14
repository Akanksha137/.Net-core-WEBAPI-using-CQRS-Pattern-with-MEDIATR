using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Demo.Command;
using WebAPI_Demo.Entities;
using WebAPI_Demo.Services;

namespace WebAPI_Demo.Handler
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Unit>
    {
        private readonly IAuthorServices _services;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAuthorServices services,IMapper mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if(request._author == null)
            {
                throw new ArgumentNullException(nameof(request._author));
            }
            var author = _mapper.Map<Author>(request._author);
             _services.AddAuthor(author);
            await _services.Save();
            return Unit.Value;
        }
    }
}
