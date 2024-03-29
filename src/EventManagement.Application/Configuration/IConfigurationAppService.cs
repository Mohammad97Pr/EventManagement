using System.Threading.Tasks;
using EventManagement.Configuration.Dto;

namespace EventManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
