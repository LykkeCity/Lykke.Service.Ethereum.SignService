using System.Threading.Tasks;

namespace Lykke.Service.EthereumSignService.Core.Services
{
    public interface IValidationService
    {
        Task<bool> IsValidPrivateKey(string privateKey);

        Task<bool> IsValidTransactionHex(string transactionHex);
    }
}
