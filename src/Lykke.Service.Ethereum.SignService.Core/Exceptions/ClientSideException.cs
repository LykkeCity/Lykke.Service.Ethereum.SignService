using System;

namespace Lykke.Service.Ethereum.SignService.Core.Exceptions
{
    public class ClientSideException : Exception
    {
        public enum ClientSideExceptionType
        {
            ValidationError,
            SignError
        }

        public ClientSideExceptionType Type { get; }

        public ClientSideException(string message, ClientSideExceptionType type) : base(message)
        {
            Type = type;
        }
    }
}
