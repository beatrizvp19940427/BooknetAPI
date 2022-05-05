using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Services.Exceptions.NotFound
{
    public class AuthorNotFoundException : BaseNotFoundException
    {
        public AuthorNotFoundException(IStringLocalizer<object> localizer) : base()
        {
            CustomCode = 404005;
            CustomMessage = localizer.GetString(CustomCode.ToString());
        }
    }
}
