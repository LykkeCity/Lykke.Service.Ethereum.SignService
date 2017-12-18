using System;
using System.ComponentModel.DataAnnotations;
using Lykke.Service.Ethereum.SignService.Core.Services;

namespace Lykke.Service.Ethereum.SignService.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class PrivateKeyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var privateKey = value as string;

            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));

            if (!validationService.IsValidPrivateKey(privateKey).Result)
            {
                return new ValidationResult($"Given value for ({validationContext.DisplayName}) is not a valid private key");
            }

            return null;
        }
    }
}
