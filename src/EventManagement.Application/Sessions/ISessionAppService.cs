using System.Threading.Tasks;
using Abp.Application.Services;
using EventManagement.Sessions.Dto;

namespace EventManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
