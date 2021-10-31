using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Infrasctructure.Models
{
    public class HttpResponseDTO<T>
    {
        public T Data { get; set; }

        public HttpResponseDTO(T data)
        {
            Data = data;
        }
    }
}
