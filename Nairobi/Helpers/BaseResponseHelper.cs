using Nairobi.Dtos.Core;

namespace Nairobi.Helpers
{
    public static class BaseResponseHelper
    {
        public static BaseResponse<T> AddError<T>(this BaseResponse<T> response, string message, string code = null) where T : new()
        {
            response.HasError = true;
            response.Errors.Add(new ServiceResult(message, code));
            return response;
        }
    }
}
