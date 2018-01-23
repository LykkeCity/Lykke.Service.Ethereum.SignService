using System.Net;
using System.Threading.Tasks;
using Lykke.Service.EthereumSignService.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using Lykke.Service.EthereumSignService.Core.Services;
using Lykke.Service.EthereumSignService.Models;

namespace Lykke.Service.EthereumSignService.Controllers
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    [Route("api/sign")]
    public class SignController : Controller
    {
        private readonly ISignService _signService;

        public SignController(ISignService signService)
        {
            _signService = signService;
        }

        /// <summary>
        /// Checks service is alive
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("Sign")]
        [ProducesResponseType(typeof(SignedTransactionResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SignAsync([FromBody]SignRequest signRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.Create("ValidationError", ModelState));
            }

            var signedTransactionRaw = await _signService.SignTransactionAsync(signRequest.PrivateKeys?.FirstOrDefault(), signRequest.TransactionContext);

            return Ok(new SignedTransactionResponse()
            {
                SignedTransaction = signedTransactionRaw
            });
        }
    }
}
