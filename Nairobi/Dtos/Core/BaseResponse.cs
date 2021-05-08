using System.Collections.Generic;

namespace Nairobi.Dtos.Core
{
    public class BaseResponse<T> where T : new()
    {
        public BaseResponse()
        {
            Data = new T();
            Errors = new List<ServiceResult>();
        }

        public bool HasError { get; set; }

        public List<ServiceResult> Errors { get; set; }

        public T Data { get; set; }

    }
}
