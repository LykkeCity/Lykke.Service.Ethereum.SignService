using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using System;
using System.Threading.Tasks;
using Lykke.Service.Ethereum.SignService.Core.Exceptions;
using Lykke.Service.Ethereum.SignService.Core.Services;

namespace Lykke.Service.Ethereum.SignService.Services
{

    public class SignService : ISignService
    {

        public SignService()
        {
        }


        public async Task<string> SignTransactionAsync(string privateKey, string transactionHex)
        {
            var transaction = new Transaction(transactionHex.HexToByteArray());
            var ethECKey = new EthECKey(privateKey);

            try
            {
                transaction.Sign(ethECKey);
            }
            catch (Exception e)
            {
                throw new ClientSideException($"{e.Message} - {transactionHex}", ClientSideException.ClientSideExceptionType.SignError);
            }

            return transaction.GetRLPEncoded().ToHex();
        }
    }
}
