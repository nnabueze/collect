using System;
namespace ErcasCollect.Responses
{
    public class SuccessfulResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public object Data { get; set; }
    }
}
