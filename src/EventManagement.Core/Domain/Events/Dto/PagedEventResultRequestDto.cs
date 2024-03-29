using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Events.Dto
{
    public class PagedEventResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
