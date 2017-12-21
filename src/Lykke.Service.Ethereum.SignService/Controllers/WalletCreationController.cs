using System.Net;
using System.Threading.Tasks;
using Lykke.Service.Ethereum.SignService.Core.Services;
using Lykke.Service.Ethereum.SignService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.Ethereum.SignService.Controllers
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    [Route("api/wallet")]
    public class WalletController : Controller
    {
        private readonly IWalletCreationService _walletCreationService;

        public WalletController(IWalletCreationService walletCreationService)
        {
            _walletCreationService = walletCreationService;
        }

        /// <summary>
        /// Checks service is alive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("CreateWallet")]
        [ProducesResponseType(typeof(SignedTransactionResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateWallet()
        {
            var keyModel = await _walletCreationService.CreateKeyModelAsync();

            return Ok(new KeyModelResponse()
            {
                PrivateKey = keyModel.PrivateKey,
                PublicAddress = keyModel.PublicAddress
            });
        }
    }
}
