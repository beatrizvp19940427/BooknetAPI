using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Common.DTO.Request
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
