using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using System;
using System.Threading.Tasks;
using Lykke.Service.EthereumSignService.Core.Services;

namespace Lykke.Service.EthereumSignService.Services
{
    public class ValidationService : IValidationService
    {
        public Task<bool> IsValidPrivateKey(string privateKey)
        {
            if (string.IsNullOrEmpty(privateKey))
                return Task.FromResult(false);

            var withPrefix = privateKey.EnsureHexPrefix();
            var bytes = withPrefix.HexToByteArray();
            var arrayLength = bytes.Length;

            return Task.FromResult(arrayLength == 32);
        }

        public Task<bool> IsValidTransactionHex(string transactionHex)
        {
            if (string.IsNullOrEmpty(transactionHex))
                return Task.FromResult(false);

            try
            {
                var transaction = new Nethereum.Signer.Transaction(transactionHex.HexToByteArray());
            }
            catch (Exception e)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
