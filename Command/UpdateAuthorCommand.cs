using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Command
{
    public class UpdateAuthorCommand:IRequest
    {
        public UpdateAuthorDto _author;
        public UpdateAuthorCommand(UpdateAuthorDto author)
        {
            _author = author;
        }
    }
}
