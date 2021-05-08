using System.Collections.Generic;
using MediatR;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.Requests
{
    public class GetProductsRequest : IRequest<BaseResponse<List<ProductDto>>>
    {
    }
}
