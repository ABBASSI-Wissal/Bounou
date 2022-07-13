using System;
namespace BridgeLibrary.Entities
{
    public class CustomError : Exception
    {
        public string ErrorCode { get; set; }
        public string MessageError { get; set; }

        public CustomError(string errorCode, string messageError)
        {
            this.ErrorCode = errorCode;
            this.MessageError = messageError;
        }
    }
}