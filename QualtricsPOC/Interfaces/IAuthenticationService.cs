using System.Threading.Tasks;

namespace QualtricsPOC.Interfaces
{
    public interface IAuthenticationService
    {
        Task GenerateAccessToken(string scope);
    }
}
