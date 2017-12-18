﻿using System.Net;
using System.Threading.Tasks;
using Lykke.Service.Ethereum.SignService.Core.Services;
using Lykke.Service.Ethereum.SignService.Models;
using Lykke.Service.Ethereum.SignService.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.Ethereum.SignService.Controllers
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    [Route("api/[controller]")]
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
        public async Task<IActionResult> SignAsync(SignRequest signRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.Create(ModelState));
            }

            var signedTransactionRaw = await _signService.SignTransactionAsync(signRequest.PrivateKey, signRequest.TransactionHex);

            return Ok(new SignedTransactionResponse()
            {
                SignedTransaction = signedTransactionRaw
            });
        }
    }
}
