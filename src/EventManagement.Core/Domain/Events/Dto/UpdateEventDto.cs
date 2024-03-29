using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.Events.Dto
{
    public class UpdateEventDto : CreateEventDto, IEntityDto
    {
        [Required]
        public int Id { get; set; }
    }
}
