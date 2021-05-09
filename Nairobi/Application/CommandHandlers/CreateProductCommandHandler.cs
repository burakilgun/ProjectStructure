using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nairobi.Application.Commands;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;
using Nairobi.Entities;
using Nairobi.Helpers;

namespace Nairobi.Application.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,BaseResponse<ProductDto>>
    {
        private readonly IProductRespository _productRespository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRespository productRespository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRespository = productRespository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                response.AddError("Category not found.", "404");
                return response;
            }

            var product = _mapper.Map<Product>(request);
            product.Category = category;
            product.CreatedAt = DateTime.Now;
            product.IsActive = true;
            product.IsDeleted = false;

            await _productRespository.AddAsync(product);

            response.Data = _mapper.Map<ProductDto>(product);

            return response;
        }
    }
}
