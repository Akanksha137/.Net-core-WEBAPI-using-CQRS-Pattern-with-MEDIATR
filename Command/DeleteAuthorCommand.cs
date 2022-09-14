using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Demo.Command
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid _id;
        public DeleteAuthorCommand(Guid id)
        {
            _id = id;
        }
    }
}
