using System.ComponentModel.DataAnnotations;

namespace CURSO_ASP_.NET.Models
{
    public class Pessoa
    {

        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string City { get; set; }

        public int Age { get; set; }
    }
}