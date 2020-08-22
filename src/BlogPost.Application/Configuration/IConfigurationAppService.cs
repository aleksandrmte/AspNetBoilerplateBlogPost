using System.Threading.Tasks;
using BlogPost.Configuration.Dto;

namespace BlogPost.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
