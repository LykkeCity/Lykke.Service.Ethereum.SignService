using System.Threading.Tasks;

namespace Lykke.Service.Ethereum.SignService.Core.Services
{
    public interface ISignService
    {
        Task<string> SignTransactionAsync(string privateKey, string transactionHex);
    }
}
