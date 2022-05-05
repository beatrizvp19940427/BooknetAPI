using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Common.DTO.Request
{
    class BookRequest
    {
        [Required]
        public AuthorRequest Author { get; set; }
        [Required]
        public CategoryRequest Category { get; set; }
        [Required] 
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
