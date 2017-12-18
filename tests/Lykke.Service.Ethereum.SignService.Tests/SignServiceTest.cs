using Lykke.Service.Ethereum.SignService.Services;
using Xunit;

namespace Lykke.Service.Ethereum.SignService.Tests
{
    public class SignServiceTest
    {
        [Fact]
        public void SignTransaction_TransactionSigned()
        {
            var validationService = new ValidationService();
            var signService = new Services.SignService();

            var privateKey = "0x1b9eff325b9ef1f5fab7fb369b740d1e6336efbac582c3cc3eccbe06586eb42f";
            var transactionHex = "ed82ee25850ba43b7400827530949ee9509a41faf2e27fca5a3016031e3105c265d687b1a2bc2ec5000080808080";
            var expectedResult = "f86d82ee25850ba43b7400827530949ee9509a41faf2e27fca5a3016031e3105c265d687b1a2bc2ec50000801ba0ef3d1275192d9c8cf0051ba8555b22448b4a40ecf473bb8b91ec1e62a2a21ef2a0120c5507d78b84bd0f113e4ea9b1a660e03538bd61945a1de6ac74acadbbc256";

            var signedTransaction =  signService.SignTransactionAsync(privateKey, transactionHex).Result;
            Assert.Equal(expectedResult, signedTransaction);
            var isValidKey = validationService.IsValidTransactionHex(transactionHex).Result;
            var adadas = "3qr4ewdf4wtfe";
            var isNotValidKey = validationService.IsValidTransactionHex(adadas).Result;
            //Assert.True(isValidKey);
        }
    }

}
