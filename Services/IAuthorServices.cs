using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Entities;

namespace WebAPI_Demo.Services
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Author>> GetAuthors();
        void AddAuthor(Author author);

        Task<Author> GetAuthorById(Guid id);

        void UpdateAuthor(Author author);

        void DeleteAuthor(Guid id);

        Task<bool> Save();
    }
}
