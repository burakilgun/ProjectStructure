using MediatR;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.Commands
{
    public class DeleteProductCommand : IRequest<BaseResponse<bool>>
    {
        public string Id { get; set; }
    }
}
