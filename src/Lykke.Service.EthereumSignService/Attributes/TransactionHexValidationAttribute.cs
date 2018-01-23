using System;
using System.ComponentModel.DataAnnotations;
using Lykke.Service.EthereumSignService.Core.Services;

namespace Lykke.Service.EthereumSignService.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class TransactionHexValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var transactionHex = value as string;

            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));
            if (!validationService.IsValidTransactionHex(transactionHex).Result)
            {
                return new ValidationResult($"Given value for ({validationContext.DisplayName}) is not a valid transactionHex");
            }

            return null;
        }
    }
}
