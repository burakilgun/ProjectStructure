using System.Collections.Generic;
using MediatR;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.Requests
{
    public class GetCategoriesRequest : IRequest<BaseResponse<List<CategoryDto>>>
    {
    }
}
