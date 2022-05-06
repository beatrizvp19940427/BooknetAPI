using APICore.Common.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Common.DTO.Response
{
    public class BookResponse
    {
        public int Id { get; set; }
        public AuthorResponse Author { get; set; }
        public CategoryResponse Category { get; set; }
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public string ISBN { get; set; }
    }
}
