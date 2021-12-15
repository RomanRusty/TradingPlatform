using System.Threading.Tasks;

namespace TradingPlatform.ClientService.Domain.Tokens
{
    public interface ITokenManager
    {
        Task<string> GenerateToken(string userName);
    }
}