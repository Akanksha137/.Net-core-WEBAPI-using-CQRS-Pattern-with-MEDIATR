using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.DbContexts;
using WebAPI_Demo.Entities;

namespace WebAPI_Demo.Services
{
    public class AuthorServices : IAuthorServices
    {
        private DatabaseContext _context;
        public AuthorServices(DatabaseContext context)
        {
            _context = context ??  throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await Task.FromResult(_context.Authors.ToList());
        }

        public void AddAuthor(Author author)
        {
            author.Id = new Guid();
             _context.Authors.Add(author);
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var author =  _context.Authors.FirstOrDefault(a => a.Id == id);
            return await Task.FromResult(author);
        }

        public void UpdateAuthor(Author author)
        {
             _context.Update(author);
        }

        public void  DeleteAuthor(Guid id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);

             _context.Authors.Remove(author);

        }
        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
            
        }
    }
}
