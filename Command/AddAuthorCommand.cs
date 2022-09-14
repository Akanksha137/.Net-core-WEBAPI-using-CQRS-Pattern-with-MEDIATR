using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Command
{
    public class AddAuthorCommand : IRequest
    {
        public CreateAuthorDto _author;
        public AddAuthorCommand(CreateAuthorDto author)
        {
            _author = author;
        }
    }
}
