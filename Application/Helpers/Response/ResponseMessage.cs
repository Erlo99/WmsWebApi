using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class ResponseMessage
    {
        public const string BadRequestForId = "Could not find data with provided ID or you don't have permissions";
    }
}
