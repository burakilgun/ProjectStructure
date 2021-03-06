using MediatR;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse<ProductDto>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}
