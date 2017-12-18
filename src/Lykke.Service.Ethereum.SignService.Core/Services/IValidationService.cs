using System.Threading.Tasks;

namespace Lykke.Service.Ethereum.SignService.Core.Services
{
    public interface IValidationService
    {
        Task<bool> IsValidPrivateKey(string privateKey);

        Task<bool> IsValidTransactionHex(string transactionHex);
    }
}
