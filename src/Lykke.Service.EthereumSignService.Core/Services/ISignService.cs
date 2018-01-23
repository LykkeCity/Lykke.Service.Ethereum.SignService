using System.Threading.Tasks;

namespace Lykke.Service.EthereumSignService.Core.Services
{
    public interface ISignService
    {
        Task<string> SignTransactionAsync(string privateKey, string transactionHex);
    }
}
