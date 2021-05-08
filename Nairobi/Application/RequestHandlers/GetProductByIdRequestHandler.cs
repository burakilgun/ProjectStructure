using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nairobi.Application.Requests;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;
using Nairobi.Helpers;

namespace Nairobi.Application.RequestHandlers
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest,BaseResponse<ProductDto>>
    {
        private readonly IProductRespository _productRespository;
        private readonly IMapper _mapper;

        public GetProductByIdRequestHandler(IProductRespository productRespository, IMapper mapper)
        {
            _productRespository = productRespository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();

            var product = await _productRespository.GetByIdAsync(request.Id);
            if (product == null)
            {
                response.AddError("Product not found.", "404");
                return response;
            }

            response.Data = _mapper.Map<ProductDto>(product);
            return response;
        }
    }
}
