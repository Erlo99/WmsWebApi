using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class Response <T>
    {
        public Response(Response<DTO.Users.UserDto> user)
        {

        }

        public Response(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
