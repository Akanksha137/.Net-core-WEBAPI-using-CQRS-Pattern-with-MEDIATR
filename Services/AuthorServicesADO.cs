using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebAPI_Demo.Entities;

namespace WebAPI_Demo.Services
{
    public class AuthorServicesADO : IAuthorServices
    {
        public IConfiguration _configuration { get; }
        public AuthorServicesADO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        int RowsAffected = 0;
        public async void AddAuthor(Author author)
        {
            string sql = "INSERT INTO Authors(Id,FirstName,LastName,DateOfBirth,MainCategory)";
            sql += " VALUES(@FirstName,@LastName,@DateOfBirth,@MainCategory)";
            using(SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("serverName")))
            {
                await cnn.OpenAsync();
                using(SqlCommand cmd = new SqlCommand(sql,cnn))
                {
                    author.Id = new Guid();
                    cmd.Parameters.Add(new SqlParameter("@Id", author.Id));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", author.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", author.LastName));
                    cmd.Parameters.Add(new SqlParameter("@DateOfBirth", author.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@MainCategory", author.MainCategory));
                    RowsAffected = await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public void DeleteAuthor(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            string sql = "SELECT * FROM Authors";
            sql += " WHERE Id = @id";
            Author author = new Author();
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("serverName")))
            {
                await cnn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        author = new Author
                        {
                            Id = dr.GetFieldValue<Guid>("Id"),
                            FirstName = dr.GetFieldValue<string>("FirstName"),
                            LastName = dr.GetFieldValue<string>("LastName"),
                            DateOfBirth = dr.GetFieldValue<DateTimeOffset>("DateOfBirth"),
                            MainCategory = dr.GetFieldValue<string>("MainCategory")
                        };


                    }
                }
            }
            return author;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            string sql = "SELECT * FROM Authors";
            
            var  Authors = new List<Author>();
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("serverName")))
            {
                await cnn.OpenAsync().ConfigureAwait(false) ;
                using(SqlCommand cmd = new SqlCommand(sql, cnn))
                {

                    SqlDataReader dr = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await dr.ReadAsync().ConfigureAwait(false))
                    {
                        Authors.Add( new Author
                        {
                            Id = dr.GetFieldValue<Guid>("Id"),
                            FirstName = dr.GetFieldValue<string>("FirstName"),
                            LastName = dr.GetFieldValue<string>("LastName"),
                            DateOfBirth = dr.GetFieldValue<DateTimeOffset>("DateOfBirth"),
                            MainCategory = dr.GetFieldValue<string>("MainCategory")
                        });

                        
                    }
                }
               
            }
            return Authors as IEnumerable<Author>;
        }
    

        public Task<bool> Save()
        {
            return Task.FromResult(RowsAffected >= 0);
        }

        public void UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
