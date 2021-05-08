using MediatR;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.Requests
{
    public class GetProductByIdRequest : IRequest<BaseResponse<ProductDto>>
    {
        public string Id { get; set; }
    }
}
