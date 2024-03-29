using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Tickets.Dto
{
    public class UpdateTicketDto : CreateTicketDto, IEntityDto
    {
        public int Id { get; set; }
    }
}
