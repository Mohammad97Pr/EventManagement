using System.Threading.Tasks;
using Abp.Application.Services;
using EventManagement.Authorization.Accounts.Dto;

namespace EventManagement.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
