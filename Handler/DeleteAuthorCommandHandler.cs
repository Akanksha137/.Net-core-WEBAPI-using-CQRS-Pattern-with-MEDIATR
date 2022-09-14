using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Demo.Command;
using WebAPI_Demo.Services;

namespace WebAPI_Demo.Handler
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorServices _services;

        public DeleteAuthorCommandHandler(IAuthorServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request._id == null)
            {
                throw new ArgumentNullException(nameof(request._id));
            }
            _services.DeleteAuthor(request._id);
            await _services.Save();
            return Unit.Value;
        }
    }
}
