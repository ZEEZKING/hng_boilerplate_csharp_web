using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hng.Application.Features.Faq.Dtos
{
    public class GetAllFaqsResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<FaqResponseDto> Data { get; set; }
    }

}
