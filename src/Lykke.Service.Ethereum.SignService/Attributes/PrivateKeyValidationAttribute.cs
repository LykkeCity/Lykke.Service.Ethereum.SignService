using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lykke.Service.Ethereum.SignService.Core.Services;

namespace Lykke.Service.Ethereum.SignService.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class PrivateKeyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));

            if (value is string privateKey)
            {
                if (!validationService.IsValidPrivateKey(privateKey).Result)
                {
                    return new ValidationResult($"Given value for ({validationContext.DisplayName}) is not a valid private key");
                }
            }
            else if (value is IEnumerable<string> pkArray)
            {
                if (pkArray.Count() > 1)
                {
                    return new ValidationResult($"Ethereum supports only one key signing. Given array is {pkArray.Count()} length.");
                }

                int num = 0;
                foreach (var key in pkArray)
                {
                    if (!validationService.IsValidPrivateKey(key).Result)
                    {
                        return new ValidationResult($"Given value for ({validationContext.DisplayName}[{num}]) is not a valid private key");
                    }

                    num++;
                }
            }

            return null;
        }
    }
}
