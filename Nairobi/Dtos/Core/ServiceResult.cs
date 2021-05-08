namespace Nairobi.Dtos.Core
{
    public class ServiceResult
    {
        public string Code { get; set; }
        public string Message { get;  set; }

        public ServiceResult(string message, string code = null)
        {
            Message = message;
            Code = code;
        }

        protected ServiceResult()
        {
        }
    }
}
