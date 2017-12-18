﻿using Lykke.Service.Ethereum.SignService.Services;
using Xunit;

namespace Lykke.Service.Ethereum.SignService.Tests
{
    public class WalletCreationTest
    {
        [Fact]
        public void CreateWallet_PrivateWalletGenerated()
        {
            var validationService = new ValidationService();
            var walletCrationLogic = new WalletCreationService();
            var generatedInstance = walletCrationLogic.CreateKeyModelAsync().Result;

            var isValidKey = validationService.IsValidPrivateKey(generatedInstance.PrivateKey).Result;

            Assert.True(isValidKey);
        }
    }

}
