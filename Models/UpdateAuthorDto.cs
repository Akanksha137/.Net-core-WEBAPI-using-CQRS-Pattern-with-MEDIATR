using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Demo.Models
{
    public class UpdateAuthorDto
    {
        //public Guid Id { get; set; }
        [Required(ErrorMessage ="First name should  not be null")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name should  not be null")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of Birth should  not be null")]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required(ErrorMessage = "Main cataegory should  not be null")]
        [MaxLength(50)]
        public string MainCategory { get; set; }
    }
}
