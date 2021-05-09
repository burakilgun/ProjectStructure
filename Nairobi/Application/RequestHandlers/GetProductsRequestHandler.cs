using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nairobi.Application.Requests;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Application.RequestHandlers
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, BaseResponse<List<ProductDto>>>
    {
        private readonly IProductRespository _productRespository;
        private readonly IMapper _mapper;

        public GetProductsRequestHandler(IProductRespository productRespository, IMapper mapper)
        {
            _productRespository = productRespository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ProductDto>>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<ProductDto>>();

            var products = await _productRespository.GetList(p => !p.IsDeleted && p.IsActive);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            response.Data = productDtos;

            return response;
        }
    }
}
